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

        public ActionResult insert_revisionHistory()
        {
            return View(); 
        }

        public ActionResult insert_revision(FormCollection getRevisionDetails)
        {
            int number = Convert.ToInt32(getRevisionDetails["revision_number"]);
            string items = getRevisionDetails["revision_items"].ToString();
            string revisedBy = getRevisionDetails["revision_revisedBy"].ToString();
            string revisionDate = getRevisionDetails["revision_revisionDate"].ToString();
            string approvedBy = getRevisionDetails["revision_approvedBy"].ToString();
            string approvedDate = getRevisionDetails["revision_approvedDate"].ToString();
            Syllabus_ManagementEntities4 fe = new Syllabus_ManagementEntities4();

            Revision getTable = new Revision();
            getTable.syllabus_FK = 1;
            getTable.versionNum = number;
            getTable.fieldsRevised = items;
            getTable.dateRevised = revisionDate;
            getTable.approvedDate = approvedDate;
            getTable.revisedBy = revisedBy;
            getTable.approvedBy = approvedBy;
            try
            {
                fe.Revisions.Add(getTable);
                fe.SaveChanges();
                ViewBag.Result = "Save Changes";
            }
            catch (Exception e)
            {
                ViewBag.Result = "Error! ";
            }
            return RedirectToAction("revision_history", "Teacher");
        }
    }
}