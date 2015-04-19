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
    public class ChangeService
    {
        /// <summary>
        /// 页面的表单
        /// </summary>
        Html.HtmlNodeCollection _inputs;
        Html.HtmlNodeCollection _selects;

          /// <summary>
        /// 加载
        /// </summary>
        public void Init(Action success)
        {
            Http.Get(ServiceConfig.GetConfig(ServiceConfigType.DriveServiceGetUrl)).OnSuccess(content =>
            {
                Html.HtmlDocument document = new Html.HtmlDocument();
                document.LoadHtml(content);
                _inputs = document.DocumentNode.SelectNodes("//input[@type='password' or @type='hidden' or @type='text']");
                _selects = document.DocumentNode.SelectNodes("//select");
                success();
            }).Go();
        }

        //http://211.144.78.162:8802/PupilWeb/logging/BookingCNStudy.aspx?coachName=9114046088&date=2015-04-25&beginTime=20%3a00&trainType=%u573a%u5185&timeLine=22


        /// <summary>
        /// 查询
        /// </summary>
        public void Query(string type, string date, Action<DataTable, bool> success)
        {
        }


    }
}
