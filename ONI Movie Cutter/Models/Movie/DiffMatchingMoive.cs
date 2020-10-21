using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace ONI_Movie_Cutter.Models.Movie
{
    class DiffMatchingMoive:MatchMovie
    {
        Mat diffBaseMat;
        int startX, startY, endX, endY;
        int diffBaseFrame = 0;
        int frameThreshold = 20;
        bool useUnderThreshold = true;

        public DiffMatchingMoive(string filePath):base(filePath)
        {
            
        }

        #region 差分取得

        /// <summary>
        /// 差分を取り、useUnderThresholdがtrueなら差分が設定値以下でTrueを返す
        /// </summary>
        /// <param name="frameCount"></param>
        /// <returns></returns>
        protected override bool FrameIsMatch(int frameCount)
        {
            return GetFrameDiffPoint(frameCount) < frameThreshold ^ useUnderThreshold;
        }

        /// <summary>
        /// 処理前に基準値を設定する。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="baseFrame"></param>
        public void SetMovieDiffArea(int startXPoint, int startYPoint, int endXPoint, int endYPoint, int baseFrame)
        {
            startX = startXPoint;
            startY = startYPoint;
            endX = endXPoint;
            endY = endYPoint;
            diffBaseFrame = baseFrame;
            diffBaseMat = GetTargetFrameMat(baseFrame).SubMat(startY, endY, startX, endX);
        }

        public void SetMovieDiffProperties(int threshold, int maxSkipFrames)
        {
            frameThreshold = threshold;
            MaxSkipFrames = maxSkipFrames;
        }

        /// <summary>
        /// 対象フレームと現在のフレームの間の差分を取る
        /// </summary>
        /// <param name="frame"></param>
        /// <returns></returns>
        private int GetFrameDiffPoint(int frame)
        {
            Mat diffMat = GetTargetFrameMat(frame).SubMat(startY, endY, startX, endX);
            Mat absmat = (diffBaseMat - diffMat).Abs();
            return (int)getScalarMean(absmat.Mean());
        }

        private double getScalarMean(Scalar sc)
        {
            return (sc.Val0 + sc.Val1 + sc.Val2) / 3;
        }

        #endregion

        #region 事前確認用

        private int[] diff_values = null;
        public int[] DiffHistrgram
        {
            get
            {
                if (diff_values == null)
                {
                    diff_values = new int[256];
                }
                return diff_values;
            }
        }

        /// <summary>
        /// チャートコントロール用のヒストグラムのデータを作成。
        /// </summary>
        /// <param name="dataPoint"></param>
        public void PreviewDiffHistgram(int dataPoint, BackgroundWorker reportWorker)
        {
            diff_values = new int[256];
            Random r = new Random();
            for (int i = 0; i < dataPoint; i++)
            {
                diff_values[GetFrameDiffPoint(r.Next(0, Frames))] += 1;
                if (reportWorker != null)
                {
                    reportWorker.ReportProgress(100 * i / dataPoint);
                }
            }
        }

        public Bitmap GetDiffBitmap()
        {
            return BitmapConverter.ToBitmap(diffBaseMat);
        }

        #endregion

    }
}
