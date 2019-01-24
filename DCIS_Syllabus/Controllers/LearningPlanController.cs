using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DCIS_Syllabus.Models;

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

            //connect to db
            Syllabus_ManagementEntities4 syllabus = new Syllabus_ManagementEntities4();
            //retrieve table details (firstName, lastName, etc.)
            Learning_Plan d = new Learning_Plan();

            //from the table friends, select all in descending order by age
            var learningList = (from u in syllabus.Learning_Plan
                                join qrter in syllabus.Quarters on u.quarter_FK equals qrter.quarter_ID
                                select new LearningPlan { LearningId = u.learning_ID,
                                                          CourseOutcomeFK = u.courseOutcome_FK.Value,
                                                          CourseIdFK = u.course_id_fk,
                                                          QuarterIdFK = u.quarter_FK,
                                                          SyllabusIdFK = u.syllabus_FK,
                                                          LODesc = u.learningOutcomeDesc,
                                                          hrs = u.hours,
                                                          topics = u.topics,
                                                          teacherAct = u.teacherActivity,
                                                          learnerAct = u.learnerActivity,
                                                          assessAct = u.assessmentActivity,
                                                          QuarterName = qrter.quarter_name
                                                        }).ToList();

            //converting all the retrieved data (friends) into a list object
            ViewData["LearningPlanList"] = learningList;
            return View(learningList);
        }

        // Teacher and Coordinator Learning Plan
        public ActionResult LearningPlanAdd()
        {
            //connect to db
            Syllabus_ManagementEntities4 term = new Syllabus_ManagementEntities4();
            //retrieve table details (firstName, lastName, etc.)
            Quarter q = new Quarter();

            //from the table friends, select all in descending order by age
            var quarterList = (from u in term.Quarters
                              select u);

            //converting all the retrieved data (friends) into a list object
            ViewData["QuarterList"] = quarterList.ToList();
            return View();
        }

        // Teacher and Coordinator Learning Plan
        public ActionResult LearningPlanAddData()
        {
            //connect to db
            Syllabus_ManagementEntities4 term = new Syllabus_ManagementEntities4();
            
            return View();
        }
    }
}