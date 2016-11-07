using Menu_Control.App_Start;
using MP.Entity.Models;
using MP.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Menu_Control.Controllers
{
    [MyActionFilterAttribute()]
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        UserInfoService userService = new UserInfoService();//用户表
        UserRoleInfoService userRoleService = new UserRoleInfoService();//用户角色表
        RoleActionInfoService roleActionService = new RoleActionInfoService();//角色权限表
        UserActionInfoService userActionService = new UserActionInfoService();//用户权限表
        ActionInfoService actionInfoService = new ActionInfoService();//权限列表
        //根据登陆用户获取用户菜单    
        public ActionResult GetMenuData()
        {
            List<ActionInfo> list = new List<ActionInfo>();
            List<int> actionIdList = new List<int>();
            string userName = "";
            if(Session["UserName"]!=null)
            {
                userName = Session["UserName"].ToString();
            }
            if (userName != "")//确定用户登录了
            {
                //根据用户查找用户ID
                UserInfo userModel=userService.FirstOrDefault(c => c.UserName == userName);
                 int userId = userModel.UserID;
                if (userModel!=null)
                {
                    UserRoleInfo userRoleInfo = userRoleService.FirstOrDefault(c => c.UserID == userId);
                    if (userRoleInfo!=null)
                    {
                        string roleId = userRoleInfo.RoleID;//根据用户求出角色来
                        if (roleId!=null)
                        {
                            string[] roleIdSum=roleId.Split(',');                          
                            for (int i = 0; i < roleIdSum.Length; i++)//根据角色求出权限来
                            {
                               int nRoleId=int.Parse(roleIdSum[i]);
                               var model2= roleActionService.FirstOrDefault(c => c.RoleID ==nRoleId);
                               if (model2!=null)
                               {
                                   string actionId = model2.ActionID;
                                   if (actionId!=null)
                                   {
                                       string[] actionIdSum = actionId.Split(',');
                                       for (int j = 0; j < actionIdSum.Length; j++)
                                       {
                                           int nActionId= int.Parse(actionIdSum[j]);
                                           if (!actionIdList.Contains(nActionId))
                                           {
                                               actionIdList.Add(nActionId);
                                           }
                                       }
                                   }

                               }
                            }
                        }
                    }
                }
                //开始获取特殊权限
                List<UserActionInfo> userActionList=userActionService.Find(c => c.UserID == userId).ToList();
                for (int i = 0; i < userActionList.Count; i++)
                {
                    if (userActionList[i].IsTrue)
                    {
                        if(userActionList[i].ActionID!=null)
                        {
                            int actionId =(int)userActionList[i].ActionID;
                            if (!actionIdList.Contains(actionId))
                            {
                                actionIdList.Add(actionId);
                            }
                        }
                    }
                    else if(userActionList[i].IsTrue==false)
                    {
                          if(userActionList[i].ActionID!=null)
                          {
                              int actionId = (int)userActionList[i].ActionID;
                              if (actionIdList.Contains(actionId))
                              {
                                  actionIdList.Remove(actionId);
                              }
                          }
                    }
                }
                //if (actionIdList.Contains(1))
                //{
                //    actionIdList.Remove(1);
                //}
                //开始求actionID列表
                for (int i = 0; i < actionIdList.Count; i++)
                {
                    int n = actionIdList[i];
                    ActionInfo model = actionInfoService.FirstOrDefault(c => c.ActionID==n);
                    list.Add(model);
                }
               
            }
            if (list.Count>0)
            {
                var sendData =new{msg=1,title=userName,list=list};
                return Json(sendData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var sendData = new { msg=0};
                return Json(sendData, JsonRequestBehavior.AllowGet);
            }
            //return Json(list, JsonRequestBehavior.AllowGet);
        }
        //根据主菜单获取子菜单
        public ActionResult GetChildMenu(int id)
        {
            List<ActionInfo> actInfo = new List<ActionInfo>();
            actInfo= actionInfoService.Find(c => c.ParID == id).ToList();         
            return Json(actInfo, JsonRequestBehavior.AllowGet);
        }
        //退出登录
        public ActionResult SignOut()
        {
            Session.Clear();
            Response.Redirect(Url.Action("Index", "Login"),true);
            return Content("ok");
        }
    }
}
