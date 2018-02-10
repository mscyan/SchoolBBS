using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolBBS.Models;
using SchoolBBS.DataAccessLibrary;

namespace SchoolBBS.Controllers
{
    public class BackSystemController : Controller
    {
        // GET: BackSystem
        public ActionResult BackSystemIndex()
        {
            return View();
        }

		//社区管理界面
		public ActionResult CommunityManage()
		{
			return View();
		}

		//帖子管理界面
		public ActionResult PostManage()
		{
			return View();
		}
		public ActionResult DeletePostByID(string post_id)
		{
			PostDataAccess pda = new PostDataAccess();
			var deleteresult = pda.DeletePostByID(post_id);
			if (deleteresult)
				return Json("success");
			else
				return Json("error");
		}


		//回复管理界面
		public ActionResult ReplyManage()
		{
			return View();
		} 

		//用户管理界面
		public ActionResult UserManage()
		{
			return View();
		}

		public ActionResult WelcomePage()
		{
			return View();
		}

	}
}