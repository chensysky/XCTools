using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using JumpKick.HttpLib;
using Html = HtmlAgilityPack;

namespace xctool
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, EventArgs e)
        {
            tab_xc.Controls.Add(new Drive());
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        { 
            
        }

    }
}
