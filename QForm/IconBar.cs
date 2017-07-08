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
    public partial class IconBar : UserControl
    {
        private IconButton nbtn = null;
        
        public IconBar()
        {
            InitializeComponent();
            nbtn = this.iconButton1;
            this.iconButton1.BtnStatus = true;
        }

        private int selectedIndex = 0;
        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                selectedIndex = value;
            }
        }

        private void iconButton_Click(object sender, EventArgs e)
        {
            if (nbtn == sender) return;
            nbtn.BtnStatus = false;
            nbtn = sender as IconButton;
            SelectedIndex = Convert.ToInt32(nbtn.Tag);
            SelectedIndexChanged(sender, new EventArgs());
        }

        //定义委托
        public delegate void SelectedIndexChangedHandle(object sender, EventArgs e);
        //定义事件
        public event SelectedIndexChangedHandle SelectedIndexChanged;
    }
}
