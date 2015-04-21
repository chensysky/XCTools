namespace xctool
{
    partial class Order
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
            this.group_order = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_msg = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lab_del = new System.Windows.Forms.Label();
            this.lab_type = new System.Windows.Forms.Label();
            this.lab_techer = new System.Windows.Forms.Label();
            this.lab_date = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lab_stop = new System.Windows.Forms.Label();
            this.group_order.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // group_order
            // 
            this.group_order.Controls.Add(this.panel2);
            this.group_order.Controls.Add(this.panel1);
            this.group_order.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_order.Location = new System.Drawing.Point(0, 0);
            this.group_order.Name = "group_order";
            this.group_order.Size = new System.Drawing.Size(293, 278);
            this.group_order.TabIndex = 0;
            this.group_order.TabStop = false;
            this.group_order.Text = "预约";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txt_msg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(287, 204);
            this.panel2.TabIndex = 3;
            // 
            // txt_msg
            // 
            this.txt_msg.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_msg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_msg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_msg.Location = new System.Drawing.Point(0, 0);
            this.txt_msg.Multiline = true;
            this.txt_msg.Name = "txt_msg";
            this.txt_msg.ReadOnly = true;
            this.txt_msg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_msg.Size = new System.Drawing.Size(285, 202);
            this.txt_msg.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lab_stop);
            this.panel1.Controls.Add(this.lab_del);
            this.panel1.Controls.Add(this.lab_type);
            this.panel1.Controls.Add(this.lab_techer);
            this.panel1.Controls.Add(this.lab_date);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 54);
            this.panel1.TabIndex = 2;
            // 
            // lab_del
            // 
            this.lab_del.AutoSize = true;
            this.lab_del.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lab_del.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_del.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lab_del.Location = new System.Drawing.Point(265, 3);
            this.lab_del.Name = "lab_del";
            this.lab_del.Size = new System.Drawing.Size(16, 16);
            this.lab_del.TabIndex = 2;
            this.lab_del.Text = "X";
            this.lab_del.Click += new System.EventHandler(this.lab_del_Click);
            // 
            // lab_type
            // 
            this.lab_type.AutoSize = true;
            this.lab_type.Location = new System.Drawing.Point(199, 30);
            this.lab_type.Name = "lab_type";
            this.lab_type.Size = new System.Drawing.Size(53, 12);
            this.lab_type.TabIndex = 1;
            this.lab_type.Text = "lab_type";
            // 
            // lab_techer
            // 
            this.lab_techer.AutoSize = true;
            this.lab_techer.Location = new System.Drawing.Point(64, 30);
            this.lab_techer.Name = "lab_techer";
            this.lab_techer.Size = new System.Drawing.Size(65, 12);
            this.lab_techer.TabIndex = 1;
            this.lab_techer.Text = "lab_techer";
            // 
            // lab_date
            // 
            this.lab_date.AutoSize = true;
            this.lab_date.Location = new System.Drawing.Point(63, 7);
            this.lab_date.Name = "lab_date";
            this.lab_date.Size = new System.Drawing.Size(53, 12);
            this.lab_date.TabIndex = 1;
            this.lab_date.Text = "lab_date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "教练：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "类型：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期：";
            // 
            // lab_stop
            // 
            this.lab_stop.AutoSize = true;
            this.lab_stop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lab_stop.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_stop.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lab_stop.Location = new System.Drawing.Point(219, 3);
            this.lab_stop.Name = "lab_stop";
            this.lab_stop.Size = new System.Drawing.Size(40, 16);
            this.lab_stop.TabIndex = 2;
            this.lab_stop.Text = "STOP";
            this.lab_stop.Click += new System.EventHandler(this.lab_stop_Click);
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.group_order);
            this.Name = "Order";
            this.Size = new System.Drawing.Size(293, 278);
            this.group_order.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox group_order;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_msg;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lab_type;
        private System.Windows.Forms.Label lab_techer;
        private System.Windows.Forms.Label lab_date;
        private System.Windows.Forms.Label lab_del;
        private System.Windows.Forms.Label lab_stop;
    }
}
