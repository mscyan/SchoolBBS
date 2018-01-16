using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolBBS.DataAccessLibrary;

namespace SchoolBBS.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult RegisterIndex()
        {
            return View();
        }

		public ActionResult RegisterAction(string userNumber,string nickname,string password,string age,string subject)
		{
			UserDataAccess uda = new UserDataAccess();
			bool isexist = uda.isUserExist(userNumber);
			if (isexist == false)
			{
				bool addsuccess = uda.AddUser(userNumber, nickname, password, age, subject);
				if (addsuccess)
					return Json("注册成功");
				else
					return Json("注册失败");
			}
			else
				return Json("该用户已注册");
		}
    }
}