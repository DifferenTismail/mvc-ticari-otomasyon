using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult PageError()
        {
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
        public ActionResult Page400() {
            Response.StatusCode = 400;
            Response.TrySkipIisCustomErrors = true;
            return View("PageError");
        }
        public ActionResult Page403()
        {
            Response.StatusCode = 403;
            Response.TrySkipIisCustomErrors = true;
            return View("PageError");
        }
        public ActionResult Page404()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View("PageError");
        }
    }
}