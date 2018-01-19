using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolBBS.DataAccessLibrary;
using SchoolBBS.Models;

namespace SchoolBBS.Controllers
{
    public class ReplyController : Controller
    {
        // GET: Reply
        public ActionResult AddReplyAction(int replyOfPost,string replyUser,string content,int hasPicture,string picturePath)
        {
			if (Request.Cookies["LoginUser"] == null)
			{
				return Json("您未登录");
			}

			ReplyDataAccess rda = new ReplyDataAccess();
			Reply reply = new Reply();
			reply.ReplyOfPost = replyOfPost;
			reply.ReplyUser = replyUser;
			reply.ReplyTime = DateTime.Now;
			int floor = new PostDataAccess().GetPostByID(replyOfPost).ReplyCount;
			reply.ReplyFloor = floor+1;
			reply.ReplyContent = content;
			reply.HasPicture = hasPicture;
			reply.PicturePath = picturePath;

			bool addresult = rda.AddReply(reply);
			if (addresult)
				return Json("success");
			else
				return Json("failed");
        }
    }
}