using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCIS_Syllabus.Controllers
{
    public class ChairmanController : Controller
    {
        // GET: Chairman
        public ActionResult ViewAllChSyllabus()
        {
            return View();
        }

        public ActionResult ViewSyllabus()
        {
            return View();
        }

        public ActionResult ViewSyllabus_Draft()
        {
            return View();
        }

        public ActionResult ProgramObj()
        {
            return View();
        }
    }
}