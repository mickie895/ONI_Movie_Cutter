using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ONI_Movie_Cutter.Control
{
    public partial class DragInputPictureBox : PictureBox
    {
        public DragInputPictureBox() : base()
        {
            StartPoint = new Point(0, 0);
            EndPoint = new Point(0, 0);
        }

        Image BaseImage;
        private Pen redPen = new Pen(Color.Red);

        private void UpdateBaseImage()
        {
            if (BaseImage != null)
            {
                base.Image = BaseImage;
            }
        }

        new Image Image
        {
            set
            {
                BaseImage = value;

            }
            get
            {
                return BaseImage;
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            pe.Graphics.DrawRectangle(redPen, Math.Min(StartPoint.X, EndPoint.X), Math.Min(StartPoint.Y, EndPoint.Y)
                , Math.Abs(StartPoint.X - EndPoint.X), Math.Abs(StartPoint.Y - EndPoint.Y));
        }

        #region ドラッグ処理

        private bool ImageIsValid
        {
            get
            {
                return BaseImage != null;
            }
        }

        public Point StartPoint
        {
            get;
            private set;
        }

        public Point EndPoint
        {
            get;
            private set;
        }

        public bool AreaIsValid
        {
            get
            {
                return StartPoint != EndPoint;
            }
        }

        private bool mousePressing = false;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            StartPoint = e.Location;
            mousePressing = true;
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (mousePressing)
            {
                EndPoint = e.Location;
                Invalidate();
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            mousePressing = false;
            EndPoint = e.Location;
            base.OnMouseUp(e);
        }

        #endregion

    }
}
