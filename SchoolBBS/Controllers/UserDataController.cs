using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}