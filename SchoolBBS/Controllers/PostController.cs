using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolBBS.Models;

namespace SchoolBBS.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult PostPage()
        {
            return View();
        }

		public ActionResult AddPostAction()
		{
			Post p = new Post();
			return Json("ab");
		}
    }
}