using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Drawing;
using System.Data;
using JumpKick.HttpLib;
using Html = HtmlAgilityPack;
using xctool.Model;

namespace xctool.Service
{
    public class OrderService
    {

        /// <summary>
        /// 页面的表单
        /// </summary>
        Html.HtmlNodeCollection _inputs;
        Html.HtmlNodeCollection _selects;
        //
        OrderInfo _info;

        public OrderService(OrderInfo info)
        {
            _info = info;
        }

        
        /// <summary>
        /// 加载
        /// </summary>
        public void Init(Action success)
        {
            Http.Get(ServiceConfig.GetConfig(ServiceConfigType.DriveServicePostUrl)+GetUrlGetArgs()).OnSuccess(content =>
            {
                Html.HtmlDocument document = new Html.HtmlDocument();
                document.LoadHtml(content);
                _inputs = document.DocumentNode.SelectNodes("//input[@type='password' or @type='hidden' or @type='text' or @type='radio']");
                _selects = document.DocumentNode.SelectNodes("//select");
                success();
            }).Go();
        }

        /// <summary>
        /// 得到班车信息
        /// </summary>
        public void GetRegBus(Action subMit)
        {
            string ddlineControlName = "";
            Dictionary<string, string> form = new Dictionary<string, string>();
            foreach (Html.HtmlNode node in _inputs)
            {
                string name = node.Attributes["name"].Value;
                if (name.IndexOf("time") != -1)
                {
                    if (!form.ContainsKey(name))
                    {
                        form.Add(name, "radio4");
                    }
                }
                else
                {
                    if (node.Attributes["disabled"] == null)
                        form.Add(name, node.Attributes["value"].Value);
                }
            }
            foreach (Html.HtmlNode node in _selects)
            {
                string name = node.Attributes["name"].Value;
                if (name.IndexOf("ddlLine") != -1)
                {
                    form.Add(name, "班车");
                    ddlineControlName = name;
                }
                else if (name.IndexOf("ddlStationAndTime") != -1)
                {
                    form.Add(name, "---请选择---");
                }
            }
            form.Add("__EVENTARGUMENT", "");
            form.Add("__EVENTTARGET", ddlineControlName);
            string url=ServiceConfig.GetConfig(ServiceConfigType.DriveServicePostUrl) + GetUrlGetArgs();
            Http.Post(url).Referer(url).Form(form).OnSuccess(result =>
            {
                Html.HtmlDocument document = new Html.HtmlDocument();
                document.LoadHtml(result);
                _inputs = document.DocumentNode.SelectNodes("//input[@type='password' or @type='hidden' or @type='submit' or @type='text' or @type='radio']");
                _selects = document.DocumentNode.SelectNodes("//select");
                //
                subMit();
            }).Go();
        }


        /// <summary>
        /// 提交
        /// </summary>
        public void Submit(Action<string> success)
        {
            this.GetRegBus(() =>
            {
                Dictionary<string, string> form = new Dictionary<string, string>();
                foreach (Html.HtmlNode node in _inputs)
                {
                    string name = node.Attributes["name"].Value;
                    if (name.IndexOf("time") != -1)
                    {
                        if (!form.ContainsKey(name))
                        {
                            form.Add(name, "radio4");
                        }
                    }
                    else
                    {
                        if (node.Attributes["disabled"] == null)
                            form.Add(name, node.Attributes["value"].Value);
                    }
                }
                foreach (Html.HtmlNode node in _selects)
                {
                    string name = node.Attributes["name"].Value;
                    if (name.IndexOf("ddlLine") != -1)
                    {
                        form.Add(name, "班车");
                    }
                    else if (name.IndexOf("ddlStationAndTime") != -1)
                    {
                        form.Add(name, node.SelectSingleNode("./option[2]").GetAttributeValue("value", "国际赛车场  " + (_info.Time - 1) + ":40"));
                    }
                }
                form.Add("__EVENTARGUMENT", "");
                form.Add("__EVENTTARGET", "");

                string h = GetUrlGetArgs();
                Http.Post(ServiceConfig.GetConfig(ServiceConfigType.DriveServicePostUrl) + GetUrlGetArgs()).Form(form).OnSuccess(result =>
                {
                     Html.HtmlDocument document = new Html.HtmlDocument();
                     document.LoadHtml(result);
                     Html.HtmlNodeCollection trs = document.DocumentNode.SelectNodes("/html[1]/body[1]/table[1]/tr[2]/td[1]/table[1]/tr[1]/td[2]/table[2]/tr[5]/td[1]/div[1]/fieldset[1]/div[1]/table[1]/tr[position()>1]");
                     foreach (Html.HtmlNode tr in trs)
                     {
                         string date = tr.SelectSingleNode("./td[1]/span").InnerText;
                         string time = tr.SelectSingleNode("./td[2]/span").InnerText;
                         string techer = tr.SelectSingleNode("./td[3]/span").InnerText;
                         if (_info.TecherName == techer && time.Substring(0, 2) == _info.Time.ToString("D2") && date == _info.Date)
                         {
                            success(result);
                             break;
                         }
                     }
                    
                  
                }).Go();
            });
        }

        

        /// <summary>
        /// 得到URL参数
        /// </summary>
        /// <returns></returns>
        private string GetUrlGetArgs()
        {
            return string.Format("?coachName={0}&date={1}&beginTime={2}%3a00&trainType={3}&timeLine={4}",
                        _info.TechNo,
                        _info.Date,
                        _info.Time,
                        _info.Type,
                        _info.Timeline);
        }
    }
}
