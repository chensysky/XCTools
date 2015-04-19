namespace xctool
{
    partial class Main
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_xc = new System.Windows.Forms.TabPage();
            this.tab_change = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_xc);
            this.tabControl1.Controls.Add(this.tab_change);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(966, 499);
            this.tabControl1.TabIndex = 0;
            // 
            // tab_xc
            // 
            this.tab_xc.Location = new System.Drawing.Point(4, 22);
            this.tab_xc.Name = "tab_xc";
            this.tab_xc.Padding = new System.Windows.Forms.Padding(3);
            this.tab_xc.Size = new System.Drawing.Size(958, 473);
            this.tab_xc.TabIndex = 0;
            this.tab_xc.Text = "学车预约";
            this.tab_xc.UseVisualStyleBackColor = true;
            // 
            // tab_change
            // 
            this.tab_change.Location = new System.Drawing.Point(4, 22);
            this.tab_change.Name = "tab_change";
            this.tab_change.Padding = new System.Windows.Forms.Padding(3);
            this.tab_change.Size = new System.Drawing.Size(958, 473);
            this.tab_change.TabIndex = 1;
            this.tab_change.Text = "切换教练";
            this.tab_change.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 499);
            this.Controls.Add(this.tabControl1);
            this.Name = "Main";
            this.Text = "学车预约";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_xc;
        private System.Windows.Forms.TabPage tab_change;

    }
}

