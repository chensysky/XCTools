namespace xctool
{
    partial class OrderList
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
            this.panel_content = new System.Windows.Forms.Panel();
            this.panel_order = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_num = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel_content.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel_content);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(885, 264);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "预约工作区";
            // 
            // panel_content
            // 
            this.panel_content.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_content.Controls.Add(this.panel_order);
            this.panel_content.Controls.Add(this.panel1);
            this.panel_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_content.Location = new System.Drawing.Point(3, 17);
            this.panel_content.Name = "panel_content";
            this.panel_content.Size = new System.Drawing.Size(879, 244);
            this.panel_content.TabIndex = 0;
            // 
            // panel_order
            // 
            this.panel_order.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_order.Location = new System.Drawing.Point(0, 37);
            this.panel_order.Name = "panel_order";
            this.panel_order.Size = new System.Drawing.Size(877, 205);
            this.panel_order.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_num);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.btn_start);
            this.panel1.Controls.Add(this.btn_add);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(877, 37);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(396, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "数据提交频率：";
            // 
            // txt_num
            // 
            this.txt_num.BackColor = System.Drawing.SystemColors.Control;
            this.txt_num.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_num.Location = new System.Drawing.Point(488, 7);
            this.txt_num.Name = "txt_num";
            this.txt_num.Size = new System.Drawing.Size(46, 21);
            this.txt_num.TabIndex = 1;
            this.txt_num.Text = "3";
            this.txt_num.TextChanged += new System.EventHandler(this.txt_num_TextChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(190, 7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "添加并直接开始";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(100, 7);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "开始预约";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(19, 7);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 0;
            this.btn_add.Text = "添加预约";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(541, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(311, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "（单位：1秒几次，注：手下留情，不要把服务器搞挂了）";
            // 
            // OrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "OrderList";
            this.Size = new System.Drawing.Size(885, 264);
            this.groupBox1.ResumeLayout(false);
            this.panel_content.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel_content;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.FlowLayoutPanel panel_order;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_num;
        private System.Windows.Forms.Label label2;
    }
}
