using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCIS_Syllabus.Controllers
{
    public class SyllabusController : Controller
    {
        // GET: Syllabus
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNewPolicyToDB(FormCollection fc)
        {
            //int syllabusID = Convert.ToInt32(Request.QueryString["SyllabusID"]);
            int syllabusID = 1;
            string policy = fc["PolicyString"].ToString();
            Syllabus_ManagementEntities4 s = new Syllabus_ManagementEntities4();
            Class_Policy cp = new Class_Policy();
            cp.policyItem = policy;
            cp.syllabus_FK = syllabusID;

            try
            {
                s.Class_Policy.Add(cp);
                s.SaveChanges();
                ViewBag.Result = "Saved";
            }
            catch
            {
                ViewBag.Result = "Not saved";
            }

            return RedirectToAction("ClassroomPolicy", "Teacher"); ;
        }
    }
}