using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCIS_Syllabus.Controllers
{
    public class TeacherController : Controller
    {
        // GET: ViewAllSyllabus
        public ActionResult ViewAllTSyllabus()
        {
            // Get all syllabus of all handled courses here.
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

        public ActionResult ClassroomPolicy()
        {
            return View();
        }

        public ActionResult Bibliography()
        {
            return View();
        }

        public ActionResult revision_history()
        {
            return View();
        }

        public ActionResult course_outcomes()
        {
            return View();
        }
        public ActionResult grading_system()
        {
            return View();
        }

        public ActionResult title_syllabus()
        {
            return View();
        }

        public ActionResult outputs_requirements()
        {
            return View();
        }
    }
}