using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace QForm
{
    public partial class FormSysSetting : Form
    {
        NavigationBar naviBar1 = new NavigationBar();
        NavigationBar2 naviBar2 = new NavigationBar2();
        NavigationBar3 naviBar3 = new NavigationBar3();

        List<UserControl> uclst = new List<UserControl> { };

        public FormSysSetting()
        {
            InitializeComponent();
            //窗体显示阴影效果
            SetShadow();
            //窗体最大化后不会遮挡任务栏
            this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
        }

        #region 无边框窗体阴影效果
        private const int CS_DropSHADOW = 0x20000;
        private const int GCL_STYLE = (-26);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);

        private void SetShadow()
        {
            SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DropSHADOW);
        }
        #endregion

        #region 无边框窗体拖动
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        private void FormMove()
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            FormMove();
        }
        #endregion

        #region 无边框窗体改变大小
        const int HTLEFT = 10;
        const int HTRIGHT = 11;
        const int HTTOP = 12;
        const int HTTOPLEFT = 13;
        const int HTTOPRIGHT = 14;
        const int HTBOTTOM = 15;
        const int HTBOTTOMLEFT = 0x10;
        const int HTBOTTOMRIGHT = 17;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0084:
                    base.WndProc(ref m);
                    Point vPoint = new Point((int)m.LParam & 0xFFFF,
                        (int)m.LParam >> 16 & 0xFFFF);
                    vPoint = PointToClient(vPoint);
                    if (vPoint.X <= 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOPLEFT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOMLEFT;
                        else m.Result = (IntPtr)HTLEFT;
                    else if (vPoint.X >= ClientSize.Width - 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOPRIGHT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOMRIGHT;
                        else m.Result = (IntPtr)HTRIGHT;
                    else if (vPoint.Y <= 5)
                        m.Result = (IntPtr)HTTOP;
                    else if (vPoint.Y >= ClientSize.Height - 5)
                        m.Result = (IntPtr)HTBOTTOM;
                    break;
                case 0x0201://鼠标左键按下的消息 
                    m.Msg = 0x00A1;//更改消息为非客户区按下鼠标 
                    m.LParam = IntPtr.Zero;//默认值 
                    m.WParam = new IntPtr(2);//鼠标放在标题栏内 
                    base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        #endregion

        #region 窗体的关闭、最大化、最小化
        private void buttonClose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonClose2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void buttonClose3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region 窗体绘制
        //窗体边框
        private void FormSysSetting_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Gray);
            g.DrawRectangle(pen, 0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.LightGray);
            g.DrawLine(p, new Point(0, 44), new Point(ClientRectangle.Width, 44));
        }
        #endregion

        private void FormSysSetting_Load(object sender, EventArgs e)
        {
            //添加多个导航栏
            uclst.Add(naviBar1); uclst.Add(naviBar2); uclst.Add(naviBar3);
            for (int i = 0; i < uclst.Count; i++)
            {
                this.panel3.Controls.Add(uclst[i]);
            }
        }

        private void FormSysSetting_Resize(object sender, EventArgs e)
        {
            
        }

        private void iconBar1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < uclst.Count; i++)
            {
                if (i == this.iconBar1.SelectedIndex) uclst[i].Show();
                else uclst[i].Hide();
            }
        }

        private void mTextBox1_Click(object sender, EventArgs e)
        {
            if (this.mTextBox1.Text == "搜索设置项")
            { 
                this.mTextBox1.Text = "";
            }
        }

        private void mTextBox1_Leave(object sender, EventArgs e)
        {
            this.mTextBox1.Text = "搜索设置项";
        }   
    }
}
