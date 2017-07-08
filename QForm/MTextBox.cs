using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace QForm
{
    public partial class MTextBox : TextBox
    {
        bool isMouseEnter = false;

        public MTextBox()
        {
            InitializeComponent();
        }

        public MTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
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

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0xf || m.Msg == 0x133)
            {
                IntPtr hDC = GetWindowDC(m.HWnd);
                if (hDC.ToInt32() == 0) return;

                System.Drawing.Graphics g = Graphics.FromHdc(hDC);
                if (isMouseEnter)
                {
                    g.DrawRectangle(new Pen(Color.Blue), new Rectangle(0, 0, this.Width - 1, this.Height - 1));
                }
                else
                {
                    g.DrawRectangle(new Pen(Color.Gray), new Rectangle(0, 0, this.Width - 1, this.Height - 1));
                }
                m.Result = IntPtr.Zero;
                ReleaseDC(m.HWnd, hDC);
            }
        }
    }
}
