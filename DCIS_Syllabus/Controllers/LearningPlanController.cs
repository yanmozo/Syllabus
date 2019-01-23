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
    }
}