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
    public partial class ButtonClose : UserControl
    {
        public ButtonClose()
        {
            InitializeComponent();
            this.Size = new Size(32, 32);
            this.DoubleBuffered = true;
        }

        //按钮类型：0--关闭，1--最小化，2--最大化
        private int typeIndex = 0;
        public int TypeIndex
        {
            get
            {
                return typeIndex;
            }
            set
            {
                typeIndex = value;
                this.Invalidate();
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (typeIndex == 0)
            {
                base.BackColor = Color.FromArgb(210, 66, 32);
            }
            else
            {
                base.BackColor = Color.FromArgb(107, 193, 218);
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            base.BackColor = Color.Transparent;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (typeIndex == 0)
            {
                base.BackColor = Color.FromArgb(176, 38, 17);
            }
            else
            { 
                base.BackColor = Color.FromArgb(53, 150, 230);
            }
        }

        private bool isMaxBtnClicked = false;
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (typeIndex == 2)
            {
                isMaxBtnClicked = !isMaxBtnClicked;
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Pen writepen = new Pen(Color.White, 2f);
            if (typeIndex == 0)
            {
                g.DrawLine(writepen, new Point(10, 10), new Point(20, 20));
                g.DrawLine(writepen, new Point(10, 20), new Point(20, 10));
            }
            if (typeIndex == 1)
            {
                g.DrawLine(writepen, new Point(10, 20), new Point(20, 20));
            }
            if (typeIndex == 2)
            {
                if (isMaxBtnClicked == false)
                {
                    g.DrawRectangle(writepen, new Rectangle(12, 12, 8, 8));
                }
                else
                {
                    g.DrawRectangle(writepen, new Rectangle(11, 15, 7, 6));
                    g.DrawLine(writepen, new Point(13, 12), new Point(22, 12));
                    g.DrawLine(writepen, new Point(21, 12), new Point(21, 19));
                }
            } 
        }
    }
}
