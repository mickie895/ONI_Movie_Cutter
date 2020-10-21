namespace ONI_Movie_Cutter
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.imagePathTextbox = new System.Windows.Forms.TextBox();
            this.movieOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.quarterRatioButton = new System.Windows.Forms.RadioButton();
            this.halfRatioButton = new System.Windows.Forms.RadioButton();
            this.normalRatioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.randomFrameButton = new System.Windows.Forms.Button();
            this.frameNumeric = new System.Windows.Forms.NumericUpDown();
            this.checkSourceButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.movieCheckWorker = new System.ComponentModel.BackgroundWorker();
            this.previewWorker = new System.ComponentModel.BackgroundWorker();
            this.startProcessButton = new System.Windows.Forms.Button();
            this.resultSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.skipFrameNumeric = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.mainPictureBox = new ONI_Movie_Cutter.Control.DragInputPictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.diffThresholdNumeric = new System.Windows.Forms.NumericUpDown();
            this.openKeyDialog = new System.Windows.Forms.OpenFileDialog();
            this.sendKeyButton = new System.Windows.Forms.Button();
            this.keyWaitTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frameNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skipFrameNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diffThresholdNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(704, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "動画選択";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "動画ファイル";
            // 
            // imagePathTextbox
            // 
            this.imagePathTextbox.Location = new System.Drawing.Point(16, 24);
            this.imagePathTextbox.Name = "imagePathTextbox";
            this.imagePathTextbox.Size = new System.Drawing.Size(680, 19);
            this.imagePathTextbox.TabIndex = 3;
            this.imagePathTextbox.TextChanged += new System.EventHandler(this.imagePathTextbox_TextChanged);
            // 
            // movieOpenDialog
            // 
            this.movieOpenDialog.DefaultExt = "mp4";
            this.movieOpenDialog.Filter = "すべての動画ファイル|*.*";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.quarterRatioButton);
            this.groupBox1.Controls.Add(this.halfRatioButton);
            this.groupBox1.Controls.Add(this.normalRatioButton);
            this.groupBox1.Location = new System.Drawing.Point(672, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(112, 96);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "拡大率";
            // 
            // quarterRatioButton
            // 
            this.quarterRatioButton.AutoSize = true;
            this.quarterRatioButton.Location = new System.Drawing.Point(16, 72);
            this.quarterRatioButton.Name = "quarterRatioButton";
            this.quarterRatioButton.Size = new System.Drawing.Size(41, 16);
            this.quarterRatioButton.TabIndex = 0;
            this.quarterRatioButton.Text = "25%";
            this.quarterRatioButton.UseVisualStyleBackColor = true;
            this.quarterRatioButton.CheckedChanged += new System.EventHandler(this.ratioChecked);
            // 
            // halfRatioButton
            // 
            this.halfRatioButton.AutoSize = true;
            this.halfRatioButton.Location = new System.Drawing.Point(16, 48);
            this.halfRatioButton.Name = "halfRatioButton";
            this.halfRatioButton.Size = new System.Drawing.Size(41, 16);
            this.halfRatioButton.TabIndex = 0;
            this.halfRatioButton.Text = "50%";
            this.halfRatioButton.UseVisualStyleBackColor = true;
            this.halfRatioButton.CheckedChanged += new System.EventHandler(this.ratioChecked);
            // 
            // normalRatioButton
            // 
            this.normalRatioButton.AutoSize = true;
            this.normalRatioButton.Checked = true;
            this.normalRatioButton.Location = new System.Drawing.Point(16, 24);
            this.normalRatioButton.Name = "normalRatioButton";
            this.normalRatioButton.Size = new System.Drawing.Size(47, 16);
            this.normalRatioButton.TabIndex = 0;
            this.normalRatioButton.TabStop = true;
            this.normalRatioButton.Text = "原寸";
            this.normalRatioButton.UseVisualStyleBackColor = true;
            this.normalRatioButton.CheckedChanged += new System.EventHandler(this.ratioChecked);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(672, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "プレビュー中";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(720, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "/ 0フレーム";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // randomFrameButton
            // 
            this.randomFrameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.randomFrameButton.Location = new System.Drawing.Point(688, 216);
            this.randomFrameButton.Name = "randomFrameButton";
            this.randomFrameButton.Size = new System.Drawing.Size(91, 23);
            this.randomFrameButton.TabIndex = 8;
            this.randomFrameButton.Text = "ランダム表示";
            this.randomFrameButton.UseVisualStyleBackColor = true;
            this.randomFrameButton.Click += new System.EventHandler(this.randomFrameButton_Click);
            // 
            // frameNumeric
            // 
            this.frameNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.frameNumeric.Location = new System.Drawing.Point(680, 168);
            this.frameNumeric.Name = "frameNumeric";
            this.frameNumeric.Size = new System.Drawing.Size(104, 19);
            this.frameNumeric.TabIndex = 9;
            this.frameNumeric.ValueChanged += new System.EventHandler(this.frameNumeric_ValueChanged);
            // 
            // checkSourceButton
            // 
            this.checkSourceButton.Location = new System.Drawing.Point(688, 248);
            this.checkSourceButton.Name = "checkSourceButton";
            this.checkSourceButton.Size = new System.Drawing.Size(91, 23);
            this.checkSourceButton.TabIndex = 11;
            this.checkSourceButton.Text = "テスト切り出し";
            this.checkSourceButton.UseVisualStyleBackColor = true;
            this.checkSourceButton.Click += new System.EventHandler(this.checkSourceButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 454);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(785, 23);
            this.progressBar1.TabIndex = 12;
            // 
            // movieCheckWorker
            // 
            this.movieCheckWorker.WorkerReportsProgress = true;
            this.movieCheckWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.movieCheckWorker_DoWork);
            this.movieCheckWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.movieCheckWorker_ProgressChanged);
            this.movieCheckWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.movieCheckWorker_RunWorkerCompleted);
            // 
            // previewWorker
            // 
            this.previewWorker.WorkerReportsProgress = true;
            this.previewWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.previewWorker_DoWork);
            this.previewWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.previewWorker_ProgressChanged);
            this.previewWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.previewWorker_RunWorkerCompleted);
            // 
            // startProcessButton
            // 
            this.startProcessButton.Location = new System.Drawing.Point(688, 280);
            this.startProcessButton.Name = "startProcessButton";
            this.startProcessButton.Size = new System.Drawing.Size(91, 23);
            this.startProcessButton.TabIndex = 13;
            this.startProcessButton.Text = "作業開始";
            this.startProcessButton.UseVisualStyleBackColor = true;
            this.startProcessButton.Click += new System.EventHandler(this.startProcessButton_Click);
            // 
            // resultSaveDialog
            // 
            this.resultSaveDialog.Filter = "csvファイル|*.csv|すべてのファイル|*.*";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(672, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "最長チェック間隔";
            // 
            // skipFrameNumeric
            // 
            this.skipFrameNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.skipFrameNumeric.Location = new System.Drawing.Point(680, 328);
            this.skipFrameNumeric.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.skipFrameNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.skipFrameNumeric.Name = "skipFrameNumeric";
            this.skipFrameNumeric.Size = new System.Drawing.Size(104, 19);
            this.skipFrameNumeric.TabIndex = 9;
            this.skipFrameNumeric.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.skipFrameNumeric.ValueChanged += new System.EventHandler(this.frameNumeric_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(736, 352);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "フレーム";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPictureBox.Location = new System.Drawing.Point(0, 48);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(664, 403);
            this.mainPictureBox.TabIndex = 10;
            this.mainPictureBox.TabStop = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(672, 376);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "判定境界値";
            // 
            // diffThresholdNumeric
            // 
            this.diffThresholdNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.diffThresholdNumeric.Location = new System.Drawing.Point(680, 392);
            this.diffThresholdNumeric.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.diffThresholdNumeric.Name = "diffThresholdNumeric";
            this.diffThresholdNumeric.Size = new System.Drawing.Size(104, 19);
            this.diffThresholdNumeric.TabIndex = 9;
            this.diffThresholdNumeric.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.diffThresholdNumeric.ValueChanged += new System.EventHandler(this.frameNumeric_ValueChanged);
            // 
            // openKeyDialog
            // 
            this.openKeyDialog.FileName = "openFileDialog1";
            this.openKeyDialog.Filter = "csvファイル|*.csv|すべてのファイル|*.*";
            // 
            // sendKeyButton
            // 
            this.sendKeyButton.Location = new System.Drawing.Point(688, 424);
            this.sendKeyButton.Name = "sendKeyButton";
            this.sendKeyButton.Size = new System.Drawing.Size(88, 23);
            this.sendKeyButton.TabIndex = 14;
            this.sendKeyButton.Text = "切り出し作業";
            this.sendKeyButton.UseVisualStyleBackColor = true;
            this.sendKeyButton.Click += new System.EventHandler(this.sendKeyButton_Click);
            // 
            // keyWaitTimer
            // 
            this.keyWaitTimer.Interval = 3000;
            this.keyWaitTimer.Tick += new System.EventHandler(this.keyWaitTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 477);
            this.Controls.Add(this.sendKeyButton);
            this.Controls.Add(this.startProcessButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.checkSourceButton);
            this.Controls.Add(this.mainPictureBox);
            this.Controls.Add(this.diffThresholdNumeric);
            this.Controls.Add(this.skipFrameNumeric);
            this.Controls.Add(this.frameNumeric);
            this.Controls.Add(this.randomFrameButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imagePathTextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "ONI用動画カッター";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frameNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skipFrameNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diffThresholdNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox imagePathTextbox;
        private System.Windows.Forms.OpenFileDialog movieOpenDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton quarterRatioButton;
        private System.Windows.Forms.RadioButton halfRatioButton;
        private System.Windows.Forms.RadioButton normalRatioButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button randomFrameButton;
        private System.Windows.Forms.NumericUpDown frameNumeric;
        private Control.DragInputPictureBox mainPictureBox;
        private System.Windows.Forms.Button checkSourceButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker movieCheckWorker;
        private System.ComponentModel.BackgroundWorker previewWorker;
        private System.Windows.Forms.Button startProcessButton;
        private System.Windows.Forms.SaveFileDialog resultSaveDialog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown skipFrameNumeric;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown diffThresholdNumeric;
        private System.Windows.Forms.OpenFileDialog openKeyDialog;
        private System.Windows.Forms.Button sendKeyButton;
        private System.Windows.Forms.Timer keyWaitTimer;
    }
}

