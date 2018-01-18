using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolBBS.DataAccessLibrary;
using SchoolBBS.Models;

namespace SchoolBBS.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult PublishPost(int communityID,string title,string content,string postUserID,int hasPicture,string picPath)
		{
			if (postUserID == "")
				return Json("nouser");
			else
			{
				Post post = new Post(communityID, title, content, postUserID, hasPicture, picPath);
				PostDataAccess pda = new PostDataAccess();
				bool addsuccess = pda.AddPost(post);
				if (addsuccess)
				{
					new LogDataAccess().AddLog(postUserID, new UserDataAccess().GetUserByID(postUserID).NickName, "发表了帖子，标题："+title);
					return Json("success");
				}
				else
					return Json("error");
			}
		}
    }
}