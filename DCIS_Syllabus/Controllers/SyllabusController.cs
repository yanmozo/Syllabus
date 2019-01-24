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
        Syllabus_ManagementEntities4 sm = new Syllabus_ManagementEntities4();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNewPolicyToDB(FormCollection fc)
        {
            //int syllabusID = Convert.ToInt32(Request.QueryString["SyllabusID"]);
            int syllabusID = 1;
            string policy = fc["PolicyString"].ToString();
            Class_Policy cp = new Class_Policy();
            cp.policyItem = policy;
            cp.syllabus_FK = syllabusID;

            try
            {
                sm.Class_Policy.Add(cp);
                sm.SaveChanges();
                ViewBag.Result = "Saved";
            }
            catch
            {
                ViewBag.Result = "Not saved";
            }

            return RedirectToAction("ClassroomPolicy", "Teacher");
        }

        public ActionResult EditClassroomPolicies()
        {
            //int syllabusID = Convert.ToInt32(Request.QueryString["SyllabusID"]);
            int syllabusID = 1;
            Class_Policy cp = new Class_Policy();
            var policyList = (from u in sm.Class_Policy
                                where u.syllabus_FK == syllabusID
                                select u);
            ViewData["ListofPolicies"] = policyList.ToList();
            ViewBag.syllabusID = syllabusID;

            return View();
        }

        public ActionResult EditPolicy(FormCollection fc)
        {
            int policyID = Convert.ToInt32(fc["policyID_uneditable"]);
            string edited = fc["policyName"].ToString();

            Syllabus_ManagementEntities4 sm = new Syllabus_ManagementEntities4();
            var policy = sm.Class_Policy.SingleOrDefault(b => b.policy_ID == policyID);
            policy.policyItem = edited;
            var res = sm.SaveChanges();

            return RedirectToAction("EditClassroomPolicies", "Syllabus");
        }

        public ActionResult DeletePolicy(FormCollection fc)
        {
            Syllabus_ManagementEntities4 sm = new Syllabus_ManagementEntities4();
            int policyID = Convert.ToInt32(Request.QueryString["PolicyID"]);
            var c = (from p in sm.Class_Policy
                     where p.policy_ID == policyID
                     select p).FirstOrDefault();


            sm.Class_Policy.Remove(c);
            sm.SaveChanges();

            return RedirectToAction("EditClassroomPolicies", "Syllabus");

        }
    }
}