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
		public ActionResult AddCom(string com_Name,string desc)
		{
			CommunityDataAccess cda = new CommunityDataAccess();
			var addresult = cda.AddCommunity(com_Name,"1408054113",desc);
			if (addresult)
				return Json("success");
			else
				return Json("error");
		}
		public ActionResult DeleteComByID(int com_id)
		{
			CommunityDataAccess cda = new CommunityDataAccess();
			var deleteresult = cda.DeleteCommunityByID(com_id);
			if (deleteresult)
				return Json("success");
			else
				return Json("error");
		}
		public ActionResult AlterDeclareByID(string declare,int com_id)
		{
			CommunityDataAccess cda = new CommunityDataAccess();
			bool alterresult = cda.UpdateDeclareByID(com_id, declare);
			if (alterresult)
				return Json("success");
			else
				return Json("error");
		}
		public ActionResult AlterMasterByID(string master,int com_id)
		{
			UserDataAccess uda = new UserDataAccess();
			bool exist = uda.isUserExist(master);
			if (exist)
			{
				CommunityDataAccess cda = new CommunityDataAccess();
				bool result = cda.UpdateMasterByID(com_id, master);
				if (result)
					return Json("success");
				else
					return Json("error");
			}
			return Json("error");
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
		public ActionResult DeleteReplyByID(int reply_id)
		{
			ReplyDataAccess rda = new ReplyDataAccess();
			var deleteresult = rda.DeleteReplyByReplyID(reply_id);
			if (deleteresult)
				return Json("success");
			else
				return Json("error");
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