using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolBBS.DataAccessLibrary;
using SchoolBBS.Models;

namespace SchoolBBS.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult LoginIndex()
        {
            return View();
        }

		public ActionResult LoginAction(string userNumber,string password)
		{
			UserDataAccess uda = new UserDataAccess();
			if(uda.isUserExist(userNumber)==true)
			{
				if (uda.isUserExist(userNumber, password) == true)
				{
					HttpCookie cook = new HttpCookie("LoginUser", userNumber);
					Response.Cookies.Add(cook);
					new LogDataAccess().AddLog(userNumber, new UserDataAccess().GetUserByID(userNumber).NickName, "登录了系统");
					return Json("登录正确");
				}
				else
				{
					return Json("密码错误");
				}
			}
			return Json("用户不存在");
		}

		public ActionResult SignOutAction()
		{
			Response.Cookies["LoginUser"].Expires = DateTime.Now ;
			return Json("success");
		}
    }
}