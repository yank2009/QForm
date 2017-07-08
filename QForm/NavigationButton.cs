using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QForm
{
    public partial class NavigationButton : UserControl
    {
        StringFormat format = new StringFormat();
        bool isMouseEnter = false;

        public NavigationButton()
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

        string buttonText = "按钮";
        public string ButtonText
        {
            get { return buttonText; }
            set
            {
                buttonText = value;
                this.Invalidate();
            }
        }

        private Color clickedColor = Color.White; //鼠标按下后的颜色
        public Color ClickedColor
        {
            get
            {
                return clickedColor;
            }
            set
            {
                clickedColor = value;
            }
        }

        private Color defaultColor = Color.DarkCyan;  //默认按钮颜色
        public Color DefaultColor
        {
            get
            {
                return defaultColor;
            }
            set
            {
                defaultColor = value;
            }
        }

        private Color mouseInColor = Color.SkyBlue;  //鼠标进入时的颜色
        public Color MouseInColor
        {
            get
            {
                return mouseInColor;
            }
            set
            {
                mouseInColor = value;
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

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            isMouseEnter = true;
            if (btnStatus == false)
                this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isMouseEnter = false;
            if (btnStatus == false)
                this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            if (btnStatus == false)
            {
                if (isMouseEnter)
                {
                    this.BackColor = mouseInColor;
                }
                else
                {
                    this.BackColor = defaultColor;
                }
            }
            else
            {
                this.BackColor = clickedColor;
            }
            g.DrawString("      " + buttonText, Font, Brushes.Black, ClientRectangle, format);
        }
    }
}
