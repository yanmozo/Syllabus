﻿using System;
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
        public ActionResult LearningPlanAddData(FormCollection lp_info)
        {
            //connect to db
            Syllabus_ManagementEntities4 syllabus = new Syllabus_ManagementEntities4();

            int syllabusIdFK = Convert.ToInt32(Request.QueryString["syllabusIdFK"]);
            int courseIdFK = Convert.ToInt32(Request.QueryString["courseIdFK"]);
            string quarter = lp_info["academicTerm"];
            
            //static as of the moment
            int co_IdFk = Convert.ToInt32("1");

            int quarterValue_FKRet = (from u in syllabus.Quarters
                                      where u.quarter_name == quarter
                                      select u.quarter_ID).FirstOrDefault();
            string lOutcome = lp_info["learningOutcome"];
            int hrs = Convert.ToInt32(lp_info["noOfHrs"]);
            string topics = lp_info["topics"];
            string teachAct = lp_info["teacherAct"];
            string learnAct = lp_info["learnAct"];
            string assessAct = lp_info["assessAct"];
            if(assessAct == " ")
            {
                assessAct = null;
            }

            Learning_Plan lp = new Learning_Plan();

            //assigning the table data through the input
            lp.courseOutcome_FK= co_IdFk;
            lp.course_id_fk = courseIdFK;
            lp.quarter_FK= quarterValue_FKRet;
            lp.syllabus_FK = syllabusIdFK;
            lp.learningOutcomeDesc = lOutcome.Replace(System.Environment.NewLine, "<br />");
            lp.hours = hrs;
            lp.topics = topics.Replace(System.Environment.NewLine, "<br />");
            lp.teacherActivity = teachAct.Replace(System.Environment.NewLine, "<br />");
            lp.learnerActivity = learnAct.Replace(System.Environment.NewLine, "<br />");
            lp.assessmentActivity = assessAct.Replace(System.Environment.NewLine, "<br />");

            try
            {
                //add data to db
                syllabus.Learning_Plan.Add(lp);

                //save data to db
                syllabus.SaveChanges();
                ViewBag.Result = "Saved";
            }
            catch (Exception e)
            {
                ViewBag.Result = "Not Saved";
            }


            return RedirectToAction("LearningPlan", "LearningPlan");
        }
    }
}