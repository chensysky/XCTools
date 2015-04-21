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
        public void Init(Action success, Action<string> fail)
        {
            string url = ServiceConfig.GetConfig(ServiceConfigType.DriveServicePostUrl) + GetUrlGetArgs();
            Http.Get(ServiceConfig.GetConfig(ServiceConfigType.DriveServicePostUrl)+GetUrlGetArgs()).OnSuccess(content =>
            {
                Html.HtmlDocument document = new Html.HtmlDocument();
                document.LoadHtml(content);
                _inputs = document.DocumentNode.SelectNodes("//input[@type='password' or @type='hidden' or @type='text' or @type='radio']");
                _selects = document.DocumentNode.SelectNodes("//select");

                if (ServiceError.TestServiceError(document.DocumentNode))
                    fail("服务器出错！");
                else
                {
                    //
                    var msgnode = document.DocumentNode.SelectSingleNode("/html[1]/body[1]/table[1]/tr[2]/td[1]/table[1]/tr[1]/td[2]/table[2]/tr[1]/td[1]/table[1]/tr[1]/td[2]/div[1]/span[1]");
                    if (msgnode != null && !String.IsNullOrEmpty(msgnode.InnerText) && msgnode.InnerText.IndexOf("您已约过班车") == -1)
                    {
                        fail(msgnode.InnerText);
                        return;
                    }
                    success();
                }
            }).TimeOut(5000).OnFail(new Action<WebException>((exp) =>
            {
                fail(exp.ToString());
            })).Go();
        }

        /// <summary>
        /// 得到班车信息
        /// </summary>
        public void GetRegGoWay(Action subMit, Action<string> fail)
        {
            string ddlineControlName = "";
            Dictionary<string, string> form = new Dictionary<string, string>();
            if (_inputs != null)
            {
                foreach (Html.HtmlNode node in _inputs)
                {
                    string name = node.Attributes["name"].Value;
                    if (name.IndexOf("time") != -1)
                    {
                        if (!form.ContainsKey(name))
                        {
                            form.Add(name, "radio3");
                        }
                    }
                    else
                    {
                        if (node.Attributes["disabled"] == null)
                            form.Add(name, node.Attributes["value"].Value);
                    }
                }
            }
            if (_selects != null)
            {
                foreach (Html.HtmlNode node in _selects)
                {
                    string name = node.Attributes["name"].Value;
                    if (name.IndexOf("ddlLine") != -1)
                    {
                        form.Add(name, "---请选择---");
                        ddlineControlName = name;
                    }
                    else if (name.IndexOf("ddlStationAndTime") != -1)
                    {
                        form.Add(name, "---请选择---");
                    }
                }
            }
            form.Add("__EVENTARGUMENT", "");
            form.Add("__EVENTTARGET", ddlineControlName);
            string url = ServiceConfig.GetConfig(ServiceConfigType.DriveServicePostUrl) + GetUrlGetArgs();
            Http.Post(url).Referer(url).Form(form).OnSuccess(result =>
            {
                Html.HtmlDocument document = new Html.HtmlDocument();
                document.LoadHtml(result);
                _inputs = document.DocumentNode.SelectNodes("//input[@type='password' or @type='hidden' or @type='submit' or @type='text' or @type='radio']");
                //
                if (ServiceError.TestServiceError(document.DocumentNode))
                    fail("服务器出错！");
                else
                    subMit();
            }).TimeOut(5000).OnFail(new Action<WebException>((exp) =>
            {
                fail(exp.ToString());
            })).Go();
        }


        /// <summary>
        /// 提交
        /// </summary>
        public void Submit(Action success,Action<string> fail)
        {
            this.GetRegGoWay(() =>
            {
                #region success
                Dictionary<string, string> form = new Dictionary<string, string>();
                if (_inputs != null)
                {
                    foreach (Html.HtmlNode node in _inputs)
                    {
                        string name = node.Attributes["name"].Value;
                        if (name.IndexOf("time") != -1)
                        {
                            if (!form.ContainsKey(name))
                            {
                                form.Add(name, "radio3");
                            }
                        }
                        else
                        {
                            if (node.Attributes["disabled"] == null)
                                form.Add(name, node.Attributes["value"].Value);
                        }
                    }
                }
                form.Add("__EVENTARGUMENT", "");
                form.Add("__EVENTTARGET", "");

                Http.Post(ServiceConfig.GetConfig(ServiceConfigType.DriveServicePostUrl) + GetUrlGetArgs()).Form(form).OnSuccess(result =>
                {
                    Html.HtmlDocument document = new Html.HtmlDocument();
                    document.LoadHtml(result);
                    if (ServiceError.TestServiceError(document.DocumentNode))
                        fail("服务器出错！");
                    else
                    {
                        Html.HtmlNodeCollection trs = document.DocumentNode.SelectNodes("/html[1]/body[1]/table[1]/tr[2]/td[1]/table[1]/tr[1]/td[2]/table[2]/tr[5]/td[1]/div[1]/fieldset[1]/div[1]/table[1]/tr[position()>1]");
                        foreach (Html.HtmlNode tr in trs)
                        {
                            string date = tr.SelectSingleNode("./td[1]/span").InnerText;
                            string time = tr.SelectSingleNode("./td[2]/span").InnerText;
                            string techer = tr.SelectSingleNode("./td[3]/span").InnerText;
                            if (_info.TecherName == techer && time.Substring(0, 2) == _info.Time.ToString("D2") && date == _info.Date)
                            {
                                success();
                                return;
                            }
                        }
                        fail("提交失败！");
                    }
                }).TimeOut(5000).OnFail(new Action<WebException>((exp) =>
                {
                    fail(exp.ToString());
                })).Go();
                #endregion
            },fail);
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
                        _info.Time.ToString("D2"),
                        _info.Type,
                        _info.Timeline);
        }
    }
}
