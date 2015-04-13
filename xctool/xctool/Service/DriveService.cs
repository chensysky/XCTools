using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Drawing;
using JumpKick.HttpLib;
using Html = HtmlAgilityPack;

namespace xctool.Service
{
    public  class DriveService
    {
        /// <summary>
        /// 页面的表单
        /// </summary>
        List<Html.HtmlNode> _inputs;

        /// <summary>
        /// 加载
        /// </summary>
        public void Init()
        {
            Http.Get(ServiceConfig.GetConfig(ServiceConfigType.DriveServiceGetUrl)).OnSuccess(content =>
            {
                Html.HtmlDocument document = new Html.HtmlDocument();
                document.LoadHtml(content);
                _inputs = document.DocumentNode.SelectNodes("//input[@type='password' or @type='hidden' or @type='text'] or select").ToList();
            }).Go();
        }


        /// <summary>
        /// 查询
        /// </summary>
        public void Query(string type, string date, Action<string> success)
        {
            string dateControlName = "";
            Dictionary<string, string> form = new Dictionary<string, string>();
            foreach (Html.HtmlNode node in _inputs)
            {
                string name = node.Attributes["name"].Value;
                if (name.IndexOf("ddlTrainType") != -1)
                {
                    form.Add(name, type);
                }
                else if (name.IndexOf("txtBookingClassDate") != -1)
                {
                    form.Add(name, date);
                    dateControlName = name;
                }
                else
                {
                    form.Add(name, node.Attributes["value"].Value);
                }
            }
            form.Add("__EVENTARGUMENT", "");
            form.Add("__EVENTTARGET", dateControlName);


            Http.Post(ServiceConfig.GetConfig(ServiceConfigType.DriveServiceQueryUrl)).Form(form).OnSuccess(result =>
            {
                success(result);
                //Html.HtmlDocument document = new Html.HtmlDocument();
                //document.LoadHtml(result);
               
            }).Go();
        
        }
    }
}
