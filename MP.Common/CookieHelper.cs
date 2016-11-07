using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MP.Common
{
    public class CookieHelper
    {
        //  public string DomainName = "zjigou.com";
        public static string DefaultDomainName = "zjigou.com";

        #region  功能描述：检测cookie是否存在
        /// <summary>
        /// 检测cookie是否存在
        /// </summary>
        /// <param name="CookieName">cookie名称(可以包含子键，用“/”分隔)</param>
        /// <returns></returns>
        public static bool ExistCookie(string CookieName, HttpRequest Request, string DomainName = "")
        {
            string[] ArrCookie;
            HttpCookie HC;
            bool ValueRtn;
            switch (CookieName.IndexOf("/"))
            {
                case -1:
                    HC = new HttpCookie(CookieName);
                    HC.Domain = DomainName;
                    HC = Request.Cookies[CookieName];

                    break;
                default:
                    ArrCookie = CookieName.Split("/".ToCharArray());
                    HC = new HttpCookie(ArrCookie[0]);
                    HC.Domain = DomainName;
                    HC = Request.Cookies[ArrCookie[0]];

                    break;
            }
            if (HC == null)
                ValueRtn = false;
            else
                ValueRtn = true;
            return ValueRtn;
        }
        #endregion

        #region 功能描述;读取Cookie
        /// <summary>
        /// 读取Cookie
        /// </summary>
        /// <param name="CookieName">CookieName:字符串，cookie名称(可以包含子键，用“/”分隔)</param>
        /// <returns></returns>
        public static string GetCookie(string CookieName, HttpRequest Request, string DomainName = "")
        {
            string[] ArrCookie;
            HttpCookie HC;

            string CookieValue;
            if (ExistCookie(CookieName, Request, DomainName))
            {
                switch (CookieName.IndexOf("/"))
                {
                    case -1:
                        HC = new HttpCookie(CookieName);
                        HC.Domain = DomainName;
                        HC = Request.Cookies[CookieName];
                        CookieValue = HC.Value;

                        break;
                    default:
                        ArrCookie = CookieName.Split("/".ToCharArray());
                        HC = new HttpCookie(ArrCookie[0]);
                        HC.Domain = DomainName;
                        HC.Values[ArrCookie[1]] = Request.Cookies[ArrCookie[0]][ArrCookie[1]];
                        CookieValue = HC.Values[ArrCookie[1]];

                        break;
                }
            }
            else
                CookieValue = "";
            return CookieValue;
        }
        #endregion

        #region 功能描述：编写Cookie

        /// <summary>
        /// 编写Cookie
        /// </summary>
        /// <param name="CookieName">CookieName:cookie名称(可以包含子键，用“/”分隔)</param>
        /// <param name="CookieValue">CookieValue:值</param>
        /// <param name="Request"></param>
        /// <param name="Response"></param>
        /// <param name="datetime">过期时间</param>
        public static void SetCookie(string CookieName, string CookieValue, HttpRequest Request, HttpResponse Response, DateTime? datetime, string DomainName = "")
        {
            string[] ArrCookie;
            HttpCookie HC;

            switch (CookieName.IndexOf("/"))
            {
                case -1:
                    if (ExistCookie(CookieName, Request))
                    {
                        HC = Request.Cookies[CookieName];
                        HC.Domain = DomainName;
                    }
                    else
                    {
                        HC = new HttpCookie(CookieName);
                        HC.Domain = DomainName;
                        HC.Value = CookieValue;
                    }
                    break;
                default:
                    ArrCookie = CookieName.Split("/".ToCharArray());
                    if (ExistCookie(CookieName, Request))
                    {
                        HC = Request.Cookies[ArrCookie[0]];
                        HC.Domain = DomainName;
                    }
                    else
                    {
                        HC = new HttpCookie(ArrCookie[0]);
                        HC.Values[ArrCookie[1]] = CookieValue;
                        HC.Domain = DomainName;
                    }
                    break;
            }
            if (datetime != null)
            {
                HC.Expires = Convert.ToDateTime(datetime);
            }

            Response.Cookies.Add(HC);
        }
        #endregion


        #region 功能描述：删除Cookie
        /// <summary>
        /// 删除Cookie
        /// </summary>
        /// <param name="CookieName">CookieName:cookie名称(可以包含子键，用“/”分隔)</param>
        /// <param name="Request"></param>
        /// <param name="Response"></param>
        public static void DeleteCookie(string CookieName, HttpRequest Request, HttpResponse Response, string DomainName = "")
        {
            HttpCookie HC;
            int i = CookieName.IndexOf("/");
            if (i != -1)
                CookieName = CookieName.Substring(0, i);
            if (ExistCookie(CookieName, Request))
            {
                HC = Request.Cookies[CookieName];
                HC.Expires = new DateTime(1900, 1, 1);
                HC.Domain = DomainName;
                HC.Value = string.Empty;
                Response.Cookies.Add(HC);
            }
        }

        #endregion
    }
}
