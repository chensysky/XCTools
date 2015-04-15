namespace xctool
{
    partial class Drive
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_query = new System.Windows.Forms.Button();
            this.datepicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.rbtn_kh = new System.Windows.Forms.RadioButton();
            this.rbtn_zc = new System.Windows.Forms.RadioButton();
            this.rbtn_df = new System.Windows.Forms.RadioButton();
            this.rbtn_cw = new System.Windows.Forms.RadioButton();
            this.rbtn_cn = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.xptable = new XPTable.Models.Table();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xptable)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_query);
            this.groupBox1.Controls.Add(this.datepicker);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rbtn_kh);
            this.groupBox1.Controls.Add(this.rbtn_zc);
            this.groupBox1.Controls.Add(this.rbtn_df);
            this.groupBox1.Controls.Add(this.rbtn_cw);
            this.groupBox1.Controls.Add(this.rbtn_cn);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(805, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // btn_query
            // 
            this.btn_query.Location = new System.Drawing.Point(634, 15);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(75, 23);
            this.btn_query.TabIndex = 3;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // datepicker
            // 
            this.datepicker.Location = new System.Drawing.Point(444, 17);
            this.datepicker.Name = "datepicker";
            this.datepicker.Size = new System.Drawing.Size(120, 21);
            this.datepicker.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(396, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "日期：";
            // 
            // rbtn_kh
            // 
            this.rbtn_kh.AutoSize = true;
            this.rbtn_kh.Location = new System.Drawing.Point(311, 20);
            this.rbtn_kh.Name = "rbtn_kh";
            this.rbtn_kh.Size = new System.Drawing.Size(47, 16);
            this.rbtn_kh.TabIndex = 1;
            this.rbtn_kh.TabStop = true;
            this.rbtn_kh.Text = "考核";
            this.rbtn_kh.UseVisualStyleBackColor = true;
            // 
            // rbtn_zc
            // 
            this.rbtn_zc.AutoSize = true;
            this.rbtn_zc.Location = new System.Drawing.Point(258, 20);
            this.rbtn_zc.Name = "rbtn_zc";
            this.rbtn_zc.Size = new System.Drawing.Size(47, 16);
            this.rbtn_zc.TabIndex = 1;
            this.rbtn_zc.TabStop = true;
            this.rbtn_zc.Text = "重车";
            this.rbtn_zc.UseVisualStyleBackColor = true;
            // 
            // rbtn_df
            // 
            this.rbtn_df.AutoSize = true;
            this.rbtn_df.Location = new System.Drawing.Point(205, 20);
            this.rbtn_df.Name = "rbtn_df";
            this.rbtn_df.Size = new System.Drawing.Size(47, 16);
            this.rbtn_df.TabIndex = 1;
            this.rbtn_df.TabStop = true;
            this.rbtn_df.Text = "单放";
            this.rbtn_df.UseVisualStyleBackColor = true;
            // 
            // rbtn_cw
            // 
            this.rbtn_cw.AutoSize = true;
            this.rbtn_cw.Location = new System.Drawing.Point(152, 20);
            this.rbtn_cw.Name = "rbtn_cw";
            this.rbtn_cw.Size = new System.Drawing.Size(47, 16);
            this.rbtn_cw.TabIndex = 1;
            this.rbtn_cw.TabStop = true;
            this.rbtn_cw.Text = "场外";
            this.rbtn_cw.UseVisualStyleBackColor = true;
            // 
            // rbtn_cn
            // 
            this.rbtn_cn.AutoSize = true;
            this.rbtn_cn.Checked = true;
            this.rbtn_cn.Location = new System.Drawing.Point(99, 20);
            this.rbtn_cn.Name = "rbtn_cn";
            this.rbtn_cn.Size = new System.Drawing.Size(47, 16);
            this.rbtn_cn.TabIndex = 1;
            this.rbtn_cn.TabStop = true;
            this.rbtn_cn.Text = "场内";
            this.rbtn_cn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "训练类型：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.xptable);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(805, 405);
            this.panel1.TabIndex = 1;
            // 
            // xptable
            // 
            this.xptable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xptable.Location = new System.Drawing.Point(0, 0);
            this.xptable.Name = "xptable";
            this.xptable.Size = new System.Drawing.Size(805, 405);
            this.xptable.TabIndex = 0;
            this.xptable.Text = "table1";
            // 
            // Drive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Drive";
            this.Size = new System.Drawing.Size(805, 452);
            this.Load += new System.EventHandler(this.Drive_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xptable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.DateTimePicker datepicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbtn_kh;
        private System.Windows.Forms.RadioButton rbtn_zc;
        private System.Windows.Forms.RadioButton rbtn_df;
        private System.Windows.Forms.RadioButton rbtn_cw;
        private System.Windows.Forms.RadioButton rbtn_cn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private XPTable.Models.Table xptable;
    }
}
