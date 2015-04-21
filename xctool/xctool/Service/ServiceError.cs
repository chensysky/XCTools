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
    public  class ServiceError
    {
        /// <summary>
        /// 检测服务器是否存在错误
        /// </summary>
        /// <returns></returns>
        public static bool TestServiceError(Html.HtmlNode doucmentNode)
        {
            var node = doucmentNode.SelectSingleNode("/html[1]/body[1]/strong[1]/span[1]");
            if (node != null && node.InnerText.IndexOf("网站忙") != -1)
            {
                return true;
            }
            return false;
        }
    }
}
