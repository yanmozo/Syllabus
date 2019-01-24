using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCIS_Syllabus.Controllers
{
    public class LearningPlanController : Controller
    {
        // GET: LearningPlan
        public ActionResult Index()
        {
            return View();
        }

        // Teacher and Coordinator Learning Plan
        public ActionResult LearningPlan()
        {
            return View();
        }

        // Teacher and Coordinator Learning Plan
        public ActionResult LearningPlanAdd()
        {
            //connect to db
            Syllabus_ManagementEntities3 term = new Syllabus_ManagementEntities3();
            //retrieve table details (firstName, lastName, etc.)
            Quarter q = new Quarter();

            //from the table friends, select all in descending order by age
            var quarterList = (from u in term.Quarters
                              select u);

            //converting all the retrieved data (friends) into a list object
            ViewData["QuarterList"] = quarterList.ToList();
            return View();
        }
    }
}