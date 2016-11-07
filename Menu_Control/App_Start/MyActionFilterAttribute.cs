using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Menu_Control.App_Start
{
    public class MyActionFilterAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["UserName"]==null)
            {
                filterContext.HttpContext.Response.Redirect("/Login/Index");
            }
        }
    }
}