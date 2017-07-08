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
    public partial class NavigationBar : UserControl
    {
        private NavigationButton nbtn = null;

        public NavigationBar()
        {
            InitializeComponent();
            nbtn = this.navigationButton1;
            this.navigationButton1.BtnStatus = true;
        }

        private void navigationButton_Click(object sender, EventArgs e)
        {
            if (nbtn == sender) return;
            nbtn.BtnStatus = false;
            nbtn = sender as NavigationButton;
        }
    }
}
