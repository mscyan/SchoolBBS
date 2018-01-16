using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolBBS.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult RegisterIndex()
        {
            return View();
        }
    }
}