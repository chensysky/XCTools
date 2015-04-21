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
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_query = new System.Windows.Forms.Panel();
            this.btn_query = new System.Windows.Forms.Button();
            this.rbtn_cw = new System.Windows.Forms.RadioButton();
            this.datepicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbtn_cn = new System.Windows.Forms.RadioButton();
            this.rbtn_kh = new System.Windows.Forms.RadioButton();
            this.rbtn_df = new System.Windows.Forms.RadioButton();
            this.rbtn_zc = new System.Windows.Forms.RadioButton();
            this.panel_msg = new System.Windows.Forms.Panel();
            this.lab_msg = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.xptable = new XPTable.Models.Table();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            this.panel_query.SuspendLayout();
            this.panel_msg.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xptable)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1056, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Controls.Add(this.panel_query);
            this.flowLayoutPanel.Controls.Add(this.panel_msg);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(1050, 36);
            this.flowLayoutPanel.TabIndex = 4;
            // 
            // panel_query
            // 
            this.panel_query.Controls.Add(this.btn_query);
            this.panel_query.Controls.Add(this.rbtn_cw);
            this.panel_query.Controls.Add(this.datepicker);
            this.panel_query.Controls.Add(this.label1);
            this.panel_query.Controls.Add(this.label2);
            this.panel_query.Controls.Add(this.rbtn_cn);
            this.panel_query.Controls.Add(this.rbtn_kh);
            this.panel_query.Controls.Add(this.rbtn_df);
            this.panel_query.Controls.Add(this.rbtn_zc);
            this.panel_query.Location = new System.Drawing.Point(0, 0);
            this.panel_query.Margin = new System.Windows.Forms.Padding(0);
            this.panel_query.Name = "panel_query";
            this.panel_query.Size = new System.Drawing.Size(693, 39);
            this.panel_query.TabIndex = 0;
            // 
            // btn_query
            // 
            this.btn_query.Location = new System.Drawing.Point(579, 6);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(75, 23);
            this.btn_query.TabIndex = 3;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // rbtn_cw
            // 
            this.rbtn_cw.AutoSize = true;
            this.rbtn_cw.Location = new System.Drawing.Point(157, 10);
            this.rbtn_cw.Name = "rbtn_cw";
            this.rbtn_cw.Size = new System.Drawing.Size(47, 16);
            this.rbtn_cw.TabIndex = 1;
            this.rbtn_cw.TabStop = true;
            this.rbtn_cw.Text = "场外";
            this.rbtn_cw.UseVisualStyleBackColor = true;
            // 
            // datepicker
            // 
            this.datepicker.Location = new System.Drawing.Point(437, 6);
            this.datepicker.Name = "datepicker";
            this.datepicker.Size = new System.Drawing.Size(120, 21);
            this.datepicker.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "训练类型：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(390, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "日期：";
            // 
            // rbtn_cn
            // 
            this.rbtn_cn.AutoSize = true;
            this.rbtn_cn.Checked = true;
            this.rbtn_cn.Location = new System.Drawing.Point(104, 10);
            this.rbtn_cn.Name = "rbtn_cn";
            this.rbtn_cn.Size = new System.Drawing.Size(47, 16);
            this.rbtn_cn.TabIndex = 1;
            this.rbtn_cn.TabStop = true;
            this.rbtn_cn.Text = "场内";
            this.rbtn_cn.UseVisualStyleBackColor = true;
            // 
            // rbtn_kh
            // 
            this.rbtn_kh.AutoSize = true;
            this.rbtn_kh.Location = new System.Drawing.Point(316, 10);
            this.rbtn_kh.Name = "rbtn_kh";
            this.rbtn_kh.Size = new System.Drawing.Size(47, 16);
            this.rbtn_kh.TabIndex = 1;
            this.rbtn_kh.TabStop = true;
            this.rbtn_kh.Text = "考核";
            this.rbtn_kh.UseVisualStyleBackColor = true;
            // 
            // rbtn_df
            // 
            this.rbtn_df.AutoSize = true;
            this.rbtn_df.Location = new System.Drawing.Point(210, 10);
            this.rbtn_df.Name = "rbtn_df";
            this.rbtn_df.Size = new System.Drawing.Size(47, 16);
            this.rbtn_df.TabIndex = 1;
            this.rbtn_df.TabStop = true;
            this.rbtn_df.Text = "单放";
            this.rbtn_df.UseVisualStyleBackColor = true;
            // 
            // rbtn_zc
            // 
            this.rbtn_zc.AutoSize = true;
            this.rbtn_zc.Location = new System.Drawing.Point(263, 10);
            this.rbtn_zc.Name = "rbtn_zc";
            this.rbtn_zc.Size = new System.Drawing.Size(47, 16);
            this.rbtn_zc.TabIndex = 1;
            this.rbtn_zc.TabStop = true;
            this.rbtn_zc.Text = "重车";
            this.rbtn_zc.UseVisualStyleBackColor = true;
            // 
            // panel_msg
            // 
            this.panel_msg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_msg.Controls.Add(this.lab_msg);
            this.panel_msg.Font = new System.Drawing.Font("新宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel_msg.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.panel_msg.Location = new System.Drawing.Point(696, 9);
            this.panel_msg.Name = "panel_msg";
            this.panel_msg.Size = new System.Drawing.Size(351, 20);
            this.panel_msg.TabIndex = 1;
            // 
            // lab_msg
            // 
            this.lab_msg.AutoSize = true;
            this.lab_msg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lab_msg.Location = new System.Drawing.Point(0, 0);
            this.lab_msg.Name = "lab_msg";
            this.lab_msg.Size = new System.Drawing.Size(47, 11);
            this.lab_msg.TabIndex = 0;
            this.lab_msg.Text = "lab_msg";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.xptable);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1056, 477);
            this.panel1.TabIndex = 1;
            // 
            // xptable
            // 
            this.xptable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xptable.Location = new System.Drawing.Point(0, 0);
            this.xptable.Name = "xptable";
            this.xptable.Size = new System.Drawing.Size(1056, 477);
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
            this.Size = new System.Drawing.Size(1056, 533);
            this.Load += new System.EventHandler(this.Drive_Load);
            this.Resize += new System.EventHandler(this.Drive_Resize);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel.ResumeLayout(false);
            this.panel_query.ResumeLayout(false);
            this.panel_query.PerformLayout();
            this.panel_msg.ResumeLayout(false);
            this.panel_msg.PerformLayout();
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Panel panel_query;
        private System.Windows.Forms.Panel panel_msg;
        private System.Windows.Forms.Label lab_msg;
    }
}
