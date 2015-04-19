using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;


namespace xctool.Service
{
    /// <summary>
    /// 配置文件
    /// </summary>
    public class ServiceConfig
    {
        /// <summary>
        /// 得到配置
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConfig(string type)
        {
            return ConfigurationManager.AppSettings[type];
        }
    }

    public struct ServiceConfigType
    { 
        public const string UserNo="UserNo";
        public const string UserPwd = "UserPwd";
        //
        public const string LoginServiceUrl = "LoginServiceUrl";
        public const string LoginServiceRndUrl = "LoginServiceRndUrl";
        public const string LoginServicePostUrl = "LoginServicePostUrl";
        //
        public const string DriveServiceGetUrl = "DriveServiceGetUrl";
        public const string DriveServiceQueryUrl = "DriveServiceQueryUrl";
        public const string DriveServicePostUrl = "DriveServicePostUrl";
        
        
    }
}
