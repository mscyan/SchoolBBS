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
					Session["LoginUser"] = new User(userNumber);
					return Json("登录正确");
				}
				else
				{
					return Json("密码错误");
				}
			}
			return Json("用户不存在");
		}
    }
}