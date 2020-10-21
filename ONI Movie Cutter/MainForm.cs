using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ONI_Movie_Cutter.Models.Movie;
using ONI_Movie_Cutter.Forms;

using OpenCvSharp;

namespace ONI_Movie_Cutter
{
    public partial class MainForm : Form
    {
        DiffMatchingMoive EditTargetMovie;

        int PreviewMaxFrame
        {
            get
            {
                if (EditTargetMovie == null)
                {
                    return 0;
                }
                else
                {
                    return EditTargetMovie.Frames;
                }
            }
        }

        Bitmap fullSizePreview = null;

        Bitmap previewImage
        {
            set
            {
                fullSizePreview = value;
                if (fullSizePreview != null)
                {
                    OnImageChanged();
                }
            }
        }

        int imageSmallRatio = 1;

        public MainForm()
        {
            InitializeComponent();
        }

        #region 画像選択・表示系

        private void OnImageChanged()
        {
            Bitmap preview = new Bitmap(fullSizePreview, fullSizePreview.Width / imageSmallRatio, fullSizePreview.Height / imageSmallRatio);
            mainPictureBox.Image = preview;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (movieOpenDialog.ShowDialog() == DialogResult.OK)
            {
                imagePathTextbox.Text = movieOpenDialog.FileName;
            }
        }

        private void SetPreviewFrame(int frame = 0)
        {
            if (EditTargetMovie == null)
            {
                return;
            }
            fullSizePreview = EditTargetMovie.CreateImage(frame);
            OnImageChanged();
        }

        private void imagePathTextbox_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(imagePathTextbox.Text))
            {
                EditTargetMovie = new DiffMatchingMoive(imagePathTextbox.Text);
                SetPreviewFrame();
                label3.Text = String.Format("/ {0}フレーム", EditTargetMovie.Frames);
                frameNumeric.Maximum = EditTargetMovie.Frames;
            }
        }

        private void ratioChecked(object sender, EventArgs e)
        {
            ratioCheck();
        }

        private void ratioCheck()
        {
            imageSmallRatio = 1;
            if (halfRatioButton.Checked)
            {
                imageSmallRatio = 2;
            }
            else if (quarterRatioButton.Checked)
            {
                imageSmallRatio = 4;
            }

            if (fullSizePreview != null)
            {
                OnImageChanged();
            }
        }

        private void frameNumeric_ValueChanged(object sender, EventArgs e)
        {
            SetPreviewFrame((int)frameNumeric.Value);
        }

        private void randomFrameButton_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            frameNumeric.Value = r.Next(0, PreviewMaxFrame);
        }


        #endregion


        private bool CheckBeforeProcess()
        {
            if (!mainPictureBox.AreaIsValid || EditTargetMovie == null)
            {
                return false;
            }

            System.Drawing.Point start = mainPictureBox.StartPoint;
            System.Drawing.Point end = mainPictureBox.EndPoint;

            start.X *= imageSmallRatio;
            start.Y *= imageSmallRatio;
            end.X *= imageSmallRatio;
            end.Y *= imageSmallRatio;

            EditTargetMovie.SetMovieDiffArea(start.X, start.Y, end.X, end.Y, (int)frameNumeric.Value);

            return true;
        }

        #region 切り出し画像プレビュー系

        PreviewHistgramForm PreviewForm;

        private void checkSourceButton_Click(object sender, EventArgs e)
        {
            if (!CheckBeforeProcess())
            {
                return;
            }
            this.Enabled = false;
            previewWorker.RunWorkerAsync();
        }

        private void previewWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            EditTargetMovie.PreviewDiffHistgram(200, previewWorker);
        }

        private void previewWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void previewWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Enabled = true;
            PreviewForm = new PreviewHistgramForm(EditTargetMovie.DiffHistrgram, EditTargetMovie.GetDiffBitmap());
            PreviewForm.ShowDialog();
        }

        #endregion

        #region 実作業系

        private void startProcessButton_Click(object sender, EventArgs e)
        {
            if (!CheckBeforeProcess())
            {
                return;
            }

            if (resultSaveDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            this.Enabled = false;
            movieCheckWorker.RunWorkerAsync();

        }

        private void movieCheckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            EditTargetMovie.SetMovieDiffProperties((int)diffThresholdNumeric.Value, (int)skipFrameNumeric.Value);
            EditTargetMovie.GetMatchedFrames(movieCheckWorker);
            this.Enabled = false;
        }

        private void movieCheckWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = 100 * e.ProgressPercentage / EditTargetMovie.Frames;
            this.Text = string.Format("{0}フレーム / {1}フレーム {2}箇所切り出し済", e.ProgressPercentage, EditTargetMovie.Frames, EditTargetMovie.SkipFrameResult.Count);
        }

        private void movieCheckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            using (TextWriter writer = new StreamWriter(resultSaveDialog.FileName, false))
            {
                foreach (MatchMovie.MatchedFramePair pair in EditTargetMovie.SkipFrameResult)
                {
                    writer.WriteLine("{0},{1}", pair.StartFrame, pair.EndFrame);
                }
            }
            this.Enabled = true;
            this.Text = "ONI用動画カッター";
        }

        #endregion

        private void sendKeyButton_Click(object sender, EventArgs e)
        {
            if (openKeyDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("規定のショートカットキーを割り当てたことを確認してください。\r\nこのダイアログを閉じてから3秒後にショートカットキーを送ります。");
                keyWaitTimer.Start();
            }
        }

        private void keyWaitTimer_Tick(object sender, EventArgs e)
        {
            keyWaitTimer.Stop();
            List<string[]> inputFrames = new List<string[]>();
            using (StreamReader reader = new StreamReader(openKeyDialog.FileName))
            {
                string line;
                while((line = reader.ReadLine()) != null){
                    inputFrames.Insert(0, line.Split(','));
                }
            }

            foreach (string[] keyFramesPair in inputFrames)
            {
                SendKeys.SendWait("+^E");
                System.Threading.Thread.Sleep(10);
                SendKeys.SendWait("{TAB}{TAB}");
                System.Threading.Thread.Sleep(10);
                SendKeys.SendWait(keyFramesPair[0]);
                System.Threading.Thread.Sleep(10);
                SendKeys.SendWait("{TAB}");
                System.Threading.Thread.Sleep(10);
                SendKeys.SendWait(keyFramesPair[1]);
                System.Threading.Thread.Sleep(10);
                SendKeys.SendWait("~");
                System.Threading.Thread.Sleep(10);
                SendKeys.SendWait("+^D");
                System.Threading.Thread.Sleep(10);
            }

            MessageBox.Show("完了");
        }
    }
}
