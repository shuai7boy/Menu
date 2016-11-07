using MP.Common;
using MP.Entity.Models;
using MP.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Providers.Entities;

namespace Menu_Control.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }
        UserInfoService service = new UserInfoService();
        [HttpPost]
        public ActionResult CheckLogin(string UserName,string Pwd)
        {            
            Pwd=Md5Helper.GetMd5Str(Pwd);
            UserInfo model=service.FirstOrDefault(c => c.UserName ==UserName & c.Pwd ==Pwd);
            if (model!=null)
            {
                Session["UserName"] = UserName;
                return Content(JsonConvert.SerializeObject(new { msg = "ok", data = UserName }));
            }
            else
            {
                return Content(JsonConvert.SerializeObject(new { msg = "no"}));
            }
        }
    }
}
