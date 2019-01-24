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

        Syllabus_ManagementEntities4 sm = new Syllabus_ManagementEntities4();

        public ActionResult ViewAllTSyllabus()
        {
            // Get all syllabus of all handled courses here.
            Syllabu s = new Syllabu();

            var syllabusList = (from u in sm.Syllabus
                                where u.madeBy_FK == 1
                                select u);
            ViewData["ListofSyllabus"] = syllabusList.ToList();

            return View();
        }

        public ActionResult Creation()
        {
            return View("Creation");
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
            // Get all classroom policies this courses here.
            //int syllabusID = Convert.ToInt32(Request.QueryString["SyllabusID"]);
            int syllabusID = 1;
            Syllabu s = new Syllabu();

            var policyList = (from u in sm.Class_Policy
                                where u.syllabus_FK == syllabusID
                                select u);
            ViewData["ListofPolicies"] = policyList.ToList();
            ViewBag.syllabusID = syllabusID;
            return View();
        }

        public ActionResult Bibliography()
        {
            var bookList = (from u in sm.Books
                              select u);
            ViewData["ListofBooks"] = bookList.ToList();

            var weblinkList = (from u in sm.Online_Sources
                               select u);
            ViewData["ListofOS"] = weblinkList.ToList();

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