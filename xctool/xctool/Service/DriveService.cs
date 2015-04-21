using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Drawing;
using System.Data;
using JumpKick.HttpLib;
using Html = HtmlAgilityPack;

namespace xctool.Service
{
    public  class DriveService
    {
        /// <summary>
        /// 页面的表单
        /// </summary>
        Html.HtmlNodeCollection _inputs;
        Html.HtmlNodeCollection _selects;

        /// <summary>
        /// 加载
        /// </summary>
        public void Init(Action success,Action<string> fail)
        {
            Http.Get(ServiceConfig.GetConfig(ServiceConfigType.DriveServiceGetUrl)).OnSuccess(content =>
            {
                Html.HtmlDocument document = new Html.HtmlDocument();
                document.LoadHtml(content);
                _inputs = document.DocumentNode.SelectNodes("//input[@type='password' or @type='hidden' or @type='text']");
                _selects = document.DocumentNode.SelectNodes("//select");

                if (ServiceError.TestServiceError(document.DocumentNode))
                    fail("服务器出错！");
                else
                    success();
            }).TimeOut(5000).OnFail(new Action<WebException>((exp) =>
            {
                fail(exp.ToString());
            })).Go();
        }


        /// <summary>
        /// 查询
        /// </summary>
        public void Query(string type, string date, Action<DataTable, bool> success, Action<string> fail)
        {
            string dateControlName = "";
            Dictionary<string, string> form = new Dictionary<string, string>();
            foreach (Html.HtmlNode node in _inputs)
            {
                string name = node.Attributes["name"].Value;
                if (name.IndexOf("txtBookingClassDate") != -1)
                {
                    form.Add(name, date);
                    dateControlName = name;
                }
                else
                {
                    form.Add(name, node.Attributes["value"].Value);
                }
            }
            foreach (Html.HtmlNode node in _selects)
            {
                string name = node.Attributes["name"].Value;
                if (name.IndexOf("ddlTrainType") != -1)
                {
                    form.Add(name, type);
                }
            }
            form.Add("__EVENTARGUMENT", "");
            form.Add("__EVENTTARGET", dateControlName);

            int s = (DateTime.Now - Convert.ToDateTime(date)).Days;
            bool istech = (Math.Abs((DateTime.Now - Convert.ToDateTime(date)).Days)+1) >= 6 ? true : false;

            Http.Post(ServiceConfig.GetConfig(ServiceConfigType.DriveServiceQueryUrl)).Form(form).OnSuccess(result =>
            {
                try
                {
                    Html.HtmlDocument document = new Html.HtmlDocument();
                    document.LoadHtml(result);
                    if (ServiceError.TestServiceError(document.DocumentNode))
                        fail("服务器出错！");
                    else
                        success(GetDataTable(document, istech), istech);
                }
                catch(Exception exp)
                {
                    fail(exp.ToString());
                }
            }).TimeOut(5000).OnFail(new Action<WebException>((exp) =>
            {
                fail(exp.ToString());
            })).Go();
        
        }

        /// <summary>
        /// 分析得到数据表
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private DataTable GetDataTable(Html.HtmlDocument content, bool istech)
        {
            DataTable dt = new DataTable();
            //
            Html.HtmlDocument document = content;
            Html.HtmlNode table = document.DocumentNode.SelectSingleNode("/html/body/table/tr[2]/td/table/tr/td[2]/table[2]/tr[" + (istech ? "3" : "2") + "]/td/div/div/table");

            //列
            DataColumn dc;
            dc = new DataColumn("教练员");  //姓名
            dt.Columns.Add(dc);
            dc = new DataColumn("车型");  //姓名
            dt.Columns.Add(dc);
            Html.HtmlNodeCollection trTime = table.SelectNodes("./tr[1]/th[1]/font/b/th");
            foreach (Html.HtmlNode tr in trTime)
            {
                dc = new DataColumn(tr.InnerText);
                dt.Columns.Add(dc);
            }
            dc = new DataColumn("教练号");
            dt.Columns.Add(dc);
         
            //数据区
            Html.HtmlNodeCollection trs = table.SelectNodes("./tr[position()>1]");
            DataRow dr;
            foreach (Html.HtmlNode tr in trs)
            {
                Html.HtmlNodeCollection tds = tr.SelectNodes("./td");
                dr = dt.NewRow();
                int index = 0;
                foreach (Html.HtmlNode td in tds)
                {
                    if (index == 0)
                    {
                        string name = td.SelectSingleNode("./font/span/child::text()[position()=1]").InnerText;
                        string car = td.SelectSingleNode("./font/span/span").InnerText;
                        dr[index] = name;
                        index++;
                        dr[index] = car;
                    }
                    else 
                    {
                        if (td.InnerText == "可预约")
                        {
                            dr[index] = "yunyue";
                        }
                        else
                        {
                            if (istech && index ==2)
                            {
                                dr[index] = td.SelectSingleNode("./font/span").InnerText;
                            }
                            else
                            {
                                dr[index] = td.InnerText;
                            }
                        }
                    }
 
                    index++;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
