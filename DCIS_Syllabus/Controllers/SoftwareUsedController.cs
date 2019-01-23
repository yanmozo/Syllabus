using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCIS_Syllabus.Controllers
{
    public class SoftwareUsedController : Controller
    {
        // GET: SoftwareUsed
        public ActionResult Index()
        {
            return View();
        }

        // Add/Edit Software Used
        public ActionResult SoftwareUsed()
        {
            return View();
        }
    }
}