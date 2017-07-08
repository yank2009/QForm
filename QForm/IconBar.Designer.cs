namespace QForm
{
    partial class IconBar
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IconBar));
            this.iconButton3 = new QForm.IconButton();
            this.iconButton2 = new QForm.IconButton();
            this.iconButton1 = new QForm.IconButton();
            this.SuspendLayout();
            // 
            // iconButton3
            // 
            this.iconButton3.BtnStatus = false;
            this.iconButton3.ButtonImage = ((System.Drawing.Icon)(resources.GetObject("iconButton3.ButtonImage")));
            this.iconButton3.ButtonText = "权限设置";
            this.iconButton3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.iconButton3.Location = new System.Drawing.Point(190, 0);
            this.iconButton3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Size = new System.Drawing.Size(85, 32);
            this.iconButton3.TabIndex = 2;
            this.iconButton3.Tag = "2";
            this.iconButton3.Click += new System.EventHandler(this.iconButton_Click);
            // 
            // iconButton2
            // 
            this.iconButton2.BtnStatus = false;
            this.iconButton2.ButtonImage = ((System.Drawing.Icon)(resources.GetObject("iconButton2.ButtonImage")));
            this.iconButton2.ButtonText = "安全设置";
            this.iconButton2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.iconButton2.Location = new System.Drawing.Point(97, 0);
            this.iconButton2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(85, 32);
            this.iconButton2.TabIndex = 1;
            this.iconButton2.Tag = "1";
            this.iconButton2.Click += new System.EventHandler(this.iconButton_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.BtnStatus = false;
            this.iconButton1.ButtonImage = ((System.Drawing.Icon)(resources.GetObject("iconButton1.ButtonImage")));
            this.iconButton1.ButtonText = "基本设置";
            this.iconButton1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.iconButton1.Location = new System.Drawing.Point(4, 0);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(85, 32);
            this.iconButton1.TabIndex = 0;
            this.iconButton1.Tag = "0";
            this.iconButton1.Click += new System.EventHandler(this.iconButton_Click);
            // 
            // IconBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.iconButton3);
            this.Controls.Add(this.iconButton2);
            this.Controls.Add(this.iconButton1);
            this.Name = "IconBar";
            this.Size = new System.Drawing.Size(300, 32);
            this.ResumeLayout(false);

        }

        #endregion

        private IconButton iconButton1;
        private IconButton iconButton2;
        private IconButton iconButton3;
    }
}
