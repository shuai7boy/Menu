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
    public class PowerController : Controller
    {
        //给用户设置角色界面
        public ActionResult SetRole()
        {
            return View();
        }
        UserInfoService userServer = new UserInfoService();//用户
        UserRoleInfoService userRoleServer = new UserRoleInfoService();//用户角色
        RoleInfoService roleService = new RoleInfoService();//角色
        ActionInfoService actService = new ActionInfoService();//权限
        RoleActionInfoService roleActService=new RoleActionInfoService();//角色权限
        UserActionInfoService userActService = new UserActionInfoService();//用户权限
        //获取所有的用户信息
         public ActionResult GetUserMsg()
        {
            List<UserInfo> model = new List<UserInfo>();
            model=userServer.Find(c => true).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
          //根据选中用户获取指定的角色信息
          [HttpPost]
         public ActionResult GetCheckRoleMsg(int id)
         {
             List<int> list = new List<int>();
            UserRoleInfo model=userRoleServer.FirstOrDefault(c => c.UserID == id);
            if (model!=null)
            {
                string str = model.RoleID;
                if (str.Length>0)
                {
                    string[] strN = str.Split(',');
                    for (int i = 0; i < strN.Length; i++)
                    {
                        int n = int.Parse(strN[i]);
                        list.Add(n);
                    }
                }              
               
            }
             return Json(list, JsonRequestBehavior.AllowGet);
         }
          //获取所有的角色信息
          [HttpPost]
          public ActionResult GetRoleMsg()
          {
              List<RoleInfo> model = new List<RoleInfo>();
              var rec=roleService.Find(c => true).ToList();
              if (rec!=null)
              {
                  model = rec;
              }
              return Json(model, JsonRequestBehavior.AllowGet);
          }
          //给用户设置角色,首先判断是否存在，存在则更新，不存在则添加
          [HttpPost]
          public ActionResult SetUserRole(int UserID, string RoleID)
          {
              string result = "ok";
              var model=userRoleServer.FirstOrDefault(c => c.UserID == UserID);
              try { 
              if (model!=null)//更新
              {
                  model.RoleID = RoleID;
                  userRoleServer.Save();
              }
              else//添加
              {
                  UserRoleInfo model2 = new UserRoleInfo();
                  model2.UserID = UserID;
                  model2.RoleID = RoleID;
                  userRoleServer.Save();
              }
              }
              catch
              {
                  result = "no";
              }
              return Content(result);
          }
         //给角色设置权限界面
          public ActionResult SetAction()
          {
              return View();
          }
          //获取所有菜单栏的权限信息
          [HttpPost]
          public ActionResult GetActMsg()
          {
              List<ActionInfo> model = new List<ActionInfo>();
              var rec=actService.Find(c =>c.ParID==0).ToList();
              if (rec!=null)
              {
                  model = rec;
              }
              return Json(model, JsonRequestBehavior.AllowGet);
          }
               //根据选中用户获取指定的权限信息
          [HttpPost]
          public ActionResult GetCheckActMsg(int id)
          {
              List<int> list = new List<int>();
              RoleActionInfo model = roleActService.FirstOrDefault(c => c.RoleID == id);
              if (model != null)
              {
                  string str = model.ActionID;
                  if (str.Length > 0)
                  {
                      string[] strN = str.Split(',');
                      for (int i = 0; i < strN.Length; i++)
                      {
                          int n = int.Parse(strN[i]);
                          list.Add(n);
                      }
                  }
              }
              return Json(list, JsonRequestBehavior.AllowGet);
          }
          //给角色设置权限,首先判断是否存在，存在则更新，不存在则添加
          [HttpPost]
          public ActionResult SetRoleAction(int RoleID, string ActID)
          {
              string result = "ok";
              var model = roleActService.FirstOrDefault(c => c.RoleID == RoleID);
              try
              {
                  if (model != null)//更新
                  {
                      model.ActionID = ActID;
                      roleActService.Save();
                  }
                  else//添加
                  {
                      RoleActionInfo model2 = new RoleActionInfo();
                      model2.RoleID = RoleID;
                      model2.ActionID = ActID;
                      roleActService.Save();
                  }
              }
              catch
              {
                  result = "no";
              }
              return Content(result);
          }
          //给用户设置特殊权限
          public ActionResult SetSpecialAction()
          {
              return View();
          }
          //根据选中用户查询特殊的权限信息
          [HttpPost]
          public ActionResult GeUserActionMsg(int id)
          {
              List<UserActionInfo> model = new List<UserActionInfo>();
              var rec=userActService.Find(c => c.UserID == id).ToList();
              if (model!=null)
              {
                  model = rec;
              }
              return Json(model, JsonRequestBehavior.AllowGet);
          }
          //给用户设置特殊权限
         [HttpPost]
          public ActionResult SetUserAction(int id,string checkActName, string checkIsTrue)
          {
              string result = "ok";
              try { 
              if (!string.IsNullOrEmpty(checkActName))
              {
                  List<UserActionInfo> selModel=userActService.Find(c => c.UserID == id).ToList();
                  if (selModel!=null)//如果存在对应关系则删除 然后添加新的对应关系
                  {
                      for (int i = 0; i < selModel.Count; i++)
                      {
                          userActService.Delete(selModel[i]);
                      }
                      userActService.Save();
                  }
                  string[] checkActNameSum = checkActName.Split(',');
                  string[] checkIsTrueSum = checkIsTrue.Split(',');
                  for (int j = 0; j < checkActNameSum.Length; j++)
                  {
                      UserActionInfo model = new UserActionInfo();
                      model.UserID = id;
                      model.ActionID = int.Parse(checkActNameSum[j]);
                      model.IsTrue = Convert.ToBoolean(checkIsTrueSum[j]);                                                     
                      userActService.Insert(model);
                  }
                  userActService.Save();
              }
              }
              catch
              {
                  result = "no";
              }
              return Content(result);
          }
    }
}
