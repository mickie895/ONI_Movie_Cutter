using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.IO;
using System.Drawing;
using System.ComponentModel;

namespace ONI_Movie_Cutter.Models.Movie
{
    abstract class MatchMovie:IDisposable
    {
        public struct MatchedFramePair
        {
            public int StartFrame, EndFrame;
            public MatchedFramePair(int start,int end)
            {
                StartFrame = start;
                EndFrame = end;
            }
        }

        public int Frames
        {
            get; private set;
        }

        public MatchMovie()
        {
            Frames = 0;
        }

        public MatchMovie(string filePath):this()
        {
            moviePath = filePath;
        }

        protected int MaxSkipFrames;

        #region マッチ判定周り

        /// <summary>
        /// カット対象になるフレームにTrueを返す
        /// </summary>
        /// <param name="frameCount"></param>
        /// <returns></returns>
        abstract protected bool FrameIsMatch(int frameCount);

        public bool GetMatchedFrames(BackgroundWorker reportWorker)
        {
            SkipFrameResult = new List<MatchedFramePair>();

            int framePointer = 0;
            int lastCutStartFrame = 0;

            bool lastFrame = FrameIsMatch(framePointer);
            bool nextFrame = false;


            int nextFramePointer = Math.Min(framePointer + MaxSkipFrames, Frames);

            while(framePointer < Frames)
            {
                // 次の切り出しフレームまでに値が変更になっているかチェック
                nextFrame = FrameIsMatch(nextFramePointer);
                if (lastFrame != nextFrame)
                {
                    if (lastFrame)
                    {
                        // カット対象→非カット対象
                        MatchedFramePair pair = new MatchedFramePair(lastCutStartFrame, GetFrameBeforeChange(framePointer, nextFramePointer, lastFrame));
                        SkipFrameResult.Add(pair);
                    }
                    else
                    {
                        // 非カット対象→カット対象
                        lastCutStartFrame = GetFrameBeforeChange(framePointer, nextFramePointer, lastFrame) + 1;
                    }
                }
                if (reportWorker != null)
                {
                    reportWorker.ReportProgress(framePointer);
                }

                // 次の切り出しフレームの準備
                lastFrame = nextFrame;
                framePointer = nextFramePointer;
                nextFramePointer = Math.Min(framePointer + MaxSkipFrames, Frames);
            }

            if (lastFrame)
            {
                SkipFrameResult.Add(new MatchedFramePair(lastCutStartFrame, Frames));
            }

            return true;
        }

        private int GetFrameBeforeChange(int start, int end, bool startWith)
        {
            while (start + 1 < end)
            {
                int center = (start + end) / 2;
                if (FrameIsMatch(center) == startWith)
                {
                    start = center;
                }
                else
                {
                    end = center;
                }
            }
            return start;
        }

        public List<MatchedFramePair> SkipFrameResult
        {
            get;private set;
        }

        #endregion

        #region 動画加工周り
        private string moviePath = null;

        protected VideoCapture movieFileCapture = null;
        private bool disposedValue;

        protected VideoCapture MovieCapture
        {
            get
            {
                if (movieFileCapture == null)
                {
                    if (moviePath != null && File.Exists(moviePath))
                    {
                        movieFileCapture = new VideoCapture(moviePath);
                        Frames = MovieCapture.FrameCount;
                    }
                }
                return movieFileCapture;
            }
        }

        public Mat GetTargetFrameMat(int frame = 0)
        {
            int target = 0;

            if (0 <= frame && frame < Frames)
            {
                target = frame;
            }

            MovieCapture.PosFrames = target;

            Mat img = new Mat();
            MovieCapture.Read(img);

            return img;
        }

        public Bitmap CreateImage(int frame = 0)
        {
            return BitmapConverter.ToBitmap(GetTargetFrameMat(frame));
        }

        #endregion

        #region Disposeパターン

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // マネージドリソースの廃棄
                    if (MovieCapture != null && !MovieCapture.IsDisposed)
                        MovieCapture.Dispose();
                }

                // TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
                // TODO: 大きなフィールドを null に設定します
                disposedValue = true;
            }
        }

        // // TODO: 'Dispose(bool disposing)' にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします
        // ~MatchMovie()
        // {
        //     // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
