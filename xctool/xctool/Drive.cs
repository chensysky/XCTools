using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPTable;
using xctool.Service;

namespace xctool
{
    public partial class Drive : UserControl
    {

        DriveService _driveService = new DriveService();

        public Drive()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Drive_Load(object sender, EventArgs e)
        {
            _driveService.Init();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_query_Click(object sender, EventArgs e)
        {
            _driveService.Query(GetType(), datepicker.Value.ToString("yyy-MM-dd"), m =>
            {
                string content = m;
            });
        }

        /// <summary>
        /// 得到类型
        /// </summary>
        /// <returns></returns>
        private string GetType()
        {
            if (rbtn_cn.Checked)
            {
                return rbtn_cn.Text;
            }
            else if (rbtn_cw.Checked)
            {
                return rbtn_cw.Text;
            }
            else if (rbtn_df.Checked)
            {
                return rbtn_df.Text;
            }
            else if (rbtn_kh.Checked)
            {
                return rbtn_kh.Text;
            }
            else if (rbtn_zc.Checked)
            {
                return rbtn_zc.Text;
            }
            else
            {
                return rbtn_cn.Text;
            }
        }


    }
}
