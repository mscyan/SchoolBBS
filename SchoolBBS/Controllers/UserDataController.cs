using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolBBS.Models;
using SchoolBBS.DataAccessLibrary;

namespace SchoolBBS.Controllers
{
    public class UserDataController : Controller
    {
        // GET: UserData
        public ActionResult UserPage()
        {
            return View();
        }

		public ActionResult UserInfoPage()
		{
			return View();
		}

		public ActionResult AlterUserInfo(string usr,string nick,string gen,int age,string subject)
		{
			UserDataAccess uda = new UserDataAccess();
			bool alterresult = uda.AlterUserInfoByID(usr, nick, gen, age, subject);
			if (alterresult)
				return Json("success");
			else
				return Json("error");
		}
    }
}