using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnSystWebApp.Controllers
{
    public class Error404Controller : Controller
    {
        // GET: Error404
        public ActionResult Index()
        {
            return View();
        }
    }
}