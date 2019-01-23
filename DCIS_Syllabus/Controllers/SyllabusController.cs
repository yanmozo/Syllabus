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
            string policy = fc["PolicyString"].ToString();
            Syllabus_ManagementEntities3 s = new Syllabus_ManagementEntities3();
            Class_Policy cp = new Class_Policy();
            cp.policyItem = policy;


            return RedirectToAction("ClassroomPolicy", "Teacher");
        }
    }
}