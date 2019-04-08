using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVCApplication.Areas.admin.Controllers
{
    public class AdminToolsController : Controller
    {
        // GET: admin/AdminTools
        public ActionResult GetTools()
        {
            return View();
        }
    }
}