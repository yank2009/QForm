using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace QForm
{
    public partial class IconButton : UserControl
    {
        StringFormat format = new StringFormat();
        bool isMouseEnter = false;
        Color backColor;
        GraphicsPath path = new GraphicsPath();
        public IconButton()
        {
            InitializeComponent();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Center;
            this.DoubleBuffered = true;
        }

        private bool btnStatus = false; //指示按钮的状态
        public bool BtnStatus
        {
            get
            {
                return btnStatus;
            }
            set
            {
                btnStatus = value;
                this.Invalidate();
            }
        }

        private string buttonText = "基本设置";
        public string ButtonText
        {
            get { return buttonText; }
            set
            {
                buttonText = value;
                this.Invalidate();
            }
        }

        private Icon buttonImage = new Icon(SystemIcons.Error, 16, 16);
        public Icon ButtonImage
        {
            get
            {
                return buttonImage;
            }
            set
            {
                buttonImage = value;
                this.Invalidate();
            }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (BtnStatus == false)
            {
                BtnStatus = true;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            backColor = this.BackColor;
            this.BackColor = Color.LightGray;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.BackColor = backColor;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            isMouseEnter = true;
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isMouseEnter = false;
            this.Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            path.Reset();
            Rectangle rectLeftTop = new Rectangle(0, 0, 5, 5);
            Rectangle rectLeftBottom = new Rectangle(0, Height - 6, 5, 5);
            Rectangle rectRightTop = new Rectangle(Width - 6, 0, 5, 5);
            Rectangle rectRightBottom = new Rectangle(Width - 6, Height - 6, 5, 5);
            path.AddArc(rectLeftTop, 180, 90);
            path.AddArc(rectRightTop, 270, 90);
            path.AddArc(rectRightBottom, 0, 90);
            path.AddArc(rectLeftBottom, 90, 90);
            path.CloseFigure();
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.DrawIcon(buttonImage, new Rectangle(2, 9, 16, 16));
            if (isMouseEnter)
            {
                g.DrawPath(new Pen(Color.Gray, 1f), path);
            }
            //else
            //{
            //    g.DrawPath(new Pen(this.backColor, 1f), path);
            //}

            if (btnStatus)
            {
                g.DrawString("     " + buttonText, Font, new SolidBrush(Color.FromArgb(0, 107, 176)), ClientRectangle, format);
            }
            else
            { 
                g.DrawString("     " + buttonText, Font, Brushes.Black, ClientRectangle, format);
            }
        } 
    }
}
