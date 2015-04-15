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
using xctool.Service;


namespace xctool
{
    public partial class Login : Form
    {

        LoginService _loginService = new LoginService();

        /// <summary>
        /// 加载
        /// </summary>
        public Login()
        {
            InitializeComponent();
          
        }


        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Load(object sender, EventArgs e)
        {
            txt_no.Text = ServiceConfig.GetConfig(ServiceConfigType.UserNo);
            txt_pwd.Text = ServiceConfig.GetConfig(ServiceConfigType.UserPwd);
            btn_login.Enabled = false;
            //
            LoadCode();
        }

        /// <summary>
        /// 更换验证码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picbox_code_Click(object sender, EventArgs e)
        {
            LoadCode();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_login_Click(object sender, EventArgs e)
        {
            _loginService.Login(txt_no.Text.Trim(), txt_pwd.Text.Trim(), txt_code.Text.Trim(), r => {
                if (r) {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.Invoke(new Action(() => { MessageBox.Show("大哥，登录失败！"); btn_login.Enabled = false; })); 
                    //
                    LoadCode();
                }
            });
        }

        /// <summary>
        /// 加载验证码
        /// </summary>
        private void LoadCode()
        {
            _loginService.Init(m => { this.Invoke(new Action(() => { this.picbox_code.Image = m; this.btn_login.Enabled = true; })); });
        }

    }
}
