using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Drawing;
using JumpKick.HttpLib;
using Html = HtmlAgilityPack;

namespace xctool.Service
{
    public  class LoginService
    {
        /// <summary>
        /// 页面的表单
        /// </summary>
        Html.HtmlNodeCollection _inputs;


        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="showCodeImg"></param>
        public void Init(Action<Bitmap> showCodeImg)
        {
            Http.Get(ServiceConfig.GetConfig(ServiceConfigType.LoginServiceUrl)).OnSuccess(content =>
            {
                Http.Get(ServiceConfig.GetConfig(ServiceConfigType.LoginServiceRndUrl)).OnSuccess((WebHeaderCollection h, Stream img) =>
                {
                    Bitmap codeImg = (Bitmap)Image.FromStream(img);
                    showCodeImg(codeImg);
                }
                ).Go();
                Html.HtmlDocument document = new Html.HtmlDocument();
                document.LoadHtml(content);
                _inputs = document.DocumentNode.SelectNodes("//input[@type='password' or @type='hidden' or @type='text']");
            }).Go();
        }

        /// <summary>
        /// 提交登录
        /// </summary>
        public void Login(string userNo, string userPwd, string code, Action<bool> success)
        {
            Dictionary<string, string> form = new Dictionary<string, string>();
            foreach (Html.HtmlNode node in _inputs)
            {
                string name = node.Attributes["name"].Value;
                if (name.IndexOf("txtPupilNo") != -1)
                {
                    form.Add(name, userNo);
                }
                else if (name.IndexOf("txtWebPwd") != -1)
                {
                    form.Add(name, userPwd);
                }
                else if (name.IndexOf("txtCode") != -1)
                {
                    form.Add(name, code);
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

            Http.Post(ServiceConfig.GetConfig(ServiceConfigType.LoginServicePostUrl)).Form(form).OnSuccess(result =>
            {
                Html.HtmlDocument document = new Html.HtmlDocument();
                document.LoadHtml(result);
                if (document.DocumentNode.SelectSingleNode("//title").InnerText.Trim() != "学员预约")
                {
                    success(true);
                }
                else
                {
                    success(false);
                }
            }).Go();
        }
    }
}
