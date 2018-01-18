using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolBBS.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult PostPage()
        {
            return View();
        }
    }
}