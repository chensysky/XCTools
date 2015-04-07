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
using System.Configuration;
using JumpKick.HttpLib;
using Html = HtmlAgilityPack;

namespace xctool
{
    public partial class Login : Form
    {
        /// <summary>
        /// 登录页面的表单
        /// </summary>
        List<Html.HtmlNode> _inputs;

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
            txt_no.Text = ConfigurationManager.AppSettings["userno"];
            txt_pwd.Text = ConfigurationManager.AppSettings["userpwd"];
            
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
            Dictionary<string, string> form = new Dictionary<string, string>();
            foreach (Html.HtmlNode node in _inputs)
            {
                string name = node.Attributes["name"].Value;
                if (name.IndexOf("txtPupilNo") != -1)
                {
                    form.Add(name, txt_no.Text.Trim());
                }
                else if (name.IndexOf("txtWebPwd") != -1)
                {
                    form.Add(name, txt_pwd.Text.Trim());
                }
                else if (name.IndexOf("txtCode") != -1)
                {
                    form.Add(name, txt_code.Text.Trim());
                }
                else
                {
                    form.Add(name, node.Attributes["value"].Value);
                }
            }
            form.Add("__EVENTARGUMENT", "");
            form.Add("__EVENTTARGET", "");
            form.Add("ctl00$ContentPlaceHolder1$ibtnLogin.x", new System.Random().Next(60).ToString());
            form.Add("ctl00$ContentPlaceHolder1$ibtnLogin.y", new System.Random().Next(60).ToString());

            Http.Post("http://211.144.78.162:8802/PupilWeb/logging/LoginUser.aspx").Form(form).OnSuccess(result =>
            {
                Html.HtmlDocument document = new Html.HtmlDocument();
                document.LoadHtml(result);
                if (document.DocumentNode.SelectSingleNode("//title").InnerText.Trim() == "理论预约")
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("大哥，登录失败啦！");
                    LoadCode();
                }
            }).Go();

        }

        /// <summary>
        /// 加载验证码
        /// </summary>
        private void LoadCode()
        {
            Http.Get("http://211.144.78.162:8802/PupilWeb/logging/LoginUser.aspx").OnSuccess(content =>
            {
                Http.Get("http://211.144.78.162:8802/PupilWeb/logging/Rnd.aspx").OnSuccess((WebHeaderCollection h, Stream img) =>
                {
                    Bitmap codeImg = (Bitmap)Image.FromStream(img);
                    picbox_code.Image = codeImg;
                }
                ).Go();
                Html.HtmlDocument document = new Html.HtmlDocument();
                document.LoadHtml(content);
                _inputs = document.DocumentNode.SelectNodes("//input[@type='password' or @type='hidden' or @type='text']").ToList();
                //
                txt_code.Text = "";
                txt_code.Focus();
            }).Go();
        }


  
    }
}
