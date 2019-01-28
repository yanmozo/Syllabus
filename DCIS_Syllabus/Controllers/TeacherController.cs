using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DCIS_Syllabus.Models;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "madeBy_FK, course_FK, title, academicYear, academicPeriod, status")]Syllabu newSyllabus)
        {
            if (ModelState.IsValid)
            {
                sm.Syllabus.Add(newSyllabus);
                sm.SaveChanges();
                return RedirectToAction("Creation");
            }
            return View("Creation");
        }

        public ActionResult populateCourses()
        {

            //List<Course_Information> listCourses = new List<Course_Information>();
            var getData = (from courses in sm.Course_Information
                           select courses);
            

            ViewData["ListofCourses"] = getData.ToList();
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

            Syllabus_ManagementEntities4 revise = new Syllabus_ManagementEntities4();
            Revision revised = new Revision();

            var reviseList = (from u in revise.Revisions select u);
            ViewData["ListOfRevisions"] = reviseList.ToList();

            return View();
        }

        public ActionResult course_outcomes()
        {
            return View();
        }
        public ActionResult grading_system()
        {

            Syllabus_ManagementEntities4 grading_system = new Syllabus_ManagementEntities4();
            Grading_System grad_sys = new Grading_System();

            var gradSysList = (from u in grading_system.Grading_System
                               where u.syllabus_FK == 1
                               select u);

            var weight = (from x in grading_system.Grading_System
                          select x).Sum(x => x.weight); 
                        
            ViewBag.Result = weight; 
            ViewData["GradingSystem"] = gradSysList.ToList();


            return View();
        }


        public ActionResult Creation()
        {
            var getData = (from courses in sm.Course_Information
                           select courses);


            ViewData["ListofCourses"] = getData.ToList();
            return View();
        }

        public ActionResult outputs_requirements()
        {
            Syllabus_ManagementEntities4 sm = new Syllabus_ManagementEntities4();
            Course_Deliverable D = new Course_Deliverable();
            var deliverableList = (from u in sm.Course_Deliverable
                              select u);
            ViewData["ListOfDeliverables"] = deliverableList.ToList();

            return View();
        }


        public ActionResult add_grading(FormCollection fc)
        {
            return View(); 
        }

        public ActionResult insert_grading(FormCollection fc)
        {
            string require_grading = fc["requirements"].ToString();
            string type_grading = fc["type"].ToString();
            double weight_grading = Convert.ToDouble(fc["weight"]); 

            Syllabus_ManagementEntities4 fe = new Syllabus_ManagementEntities4();
            Grading_System d = new Grading_System();

            d.syllabus_FK = 1;
            d.typeOfGrading = type_grading;
            d.weight = weight_grading;
            d.requirementsName = require_grading;  ;

            try
            {
                fe.Grading_System.Add(d);
                fe.SaveChanges();
                ViewBag.Result = "Save Changes";
            }
            catch (Exception e)
            {
                ViewBag.Result = "Error! " + e.Message;
            }
            return RedirectToAction("grading_system", "Teacher");
        }

        public static string SaveData(string[][] array)
        {
            string result = string.Empty;
            try
            {
                //One thing to keep in mind Column Names of DataTable
                //must be same as Table-Valued Type parameters//
                //Please refer commented queries in the bottom.
                //Just execute all of them in the Database sequentially//
                //Then change Webconfig connectionstring according to you//

                DataTable dt = new DataTable();
                dt.Columns.Add("syllabus_FK");
                dt.Columns.Add("typeOfGrading");
                dt.Columns.Add("weight");
                dt.Columns.Add("requirementsName");

                foreach (var arr in array)
                {
                    DataRow dr = dt.NewRow();
                    dr["syllabus_FK"] = arr[0];
                    dr["typeOfGrading"] = arr[1];
                    dr["weight"] = arr[2];
                    dr["requirementsName"] = arr[3];
                    dt.Rows.Add(dr);
                }

            // Syllabus_ManagementEntities3 fe = new Syllabus_ManagementEntities3(); //db
             // Grading_System d = new Grading_System(); //table

              SqlConnection cnn = new SqlConnection();
               cnn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings
                ["Syllabus_ManagementEntities3"].ToString();
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SaveGradingDetails";
                cmd.Connection = cnn;
                cmd.Parameters.Add("@TableType", SqlDbType.Structured).SqlValue = dt;

                result = cmd.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
            //return View(); 
        }
      
         public ActionResult insert_revision(FormCollection getRevisionDetails)
        {
            string items = getRevisionDetails["revision_items"].ToString();
            string revisedBy = getRevisionDetails["revision_revisedBy"].ToString();
            string revisionDate = getRevisionDetails["revision_revisionDate"].ToString();
            string approvedBy = getRevisionDetails["revision_approvedBy"].ToString();
            string approvedDate = getRevisionDetails["revision_approvedDate"].ToString();
            Syllabus_ManagementEntities4 fe = new Syllabus_ManagementEntities4();

            Revision getTable = new Revision();
            getTable.syllabus_FK = 1;
            getTable.versionNum = 1.0;
            getTable.fieldsRevised = items;
            getTable.dateRevised =  revisionDate;
            getTable.approvedDate = approvedDate;
            getTable.revisedBy = revisedBy;
            getTable.approvedBy = approvedBy;

            try
            {
                fe.Revisions.Add(getTable); 
                fe.SaveChanges();
                ViewBag.Result = "Save Changes";
            }
            catch (Exception)
            {
                ViewBag.Result = "Error! ";
            }
            return RedirectToAction("revision_history", "Teacher");
        }

        public ActionResult insert_revisionHistory()
        {
            return View();
        }

        public ActionResult AssessmentCriteria()
        {
            var criteriaList = (from u in sm.Assessment_Criteria
                            select u);
            ViewData["ListofCriteria"] = criteriaList.ToList();
            return View();
        }

        public ActionResult insert_course_outcomes()
        {
            return View(); 
        }
        public ActionResult add_course_outcomes()
        {

            return RedirectToAction("course_outcomes", "Teacher");
        }

        public ActionResult program_outcomes()
        {
            int syllabusFK = 1;
            Syllabus_ManagementEntities4 syllabus = new Syllabus_ManagementEntities4();
            Program_Outcomes prog_out = new Program_Outcomes();
            var POCV = (from u in syllabus.Program_Outcomes
                        join cv in syllabus.Core_Value on u.coreValue_FK equals cv.coreValue_ID
                        select new CoreValuePO{ CodeOutcome = u.code_outcome, CoreValueName = cv.name}).ToList();


            var PO = (from u in syllabus.Program_Outcomes
                      where u.syllabus_FK == syllabusFK
                      select new ProgramOutcome { CodeO = u.code_outcome, SyllabusFK = u.syllabus_FK, AttributeName = u.attributeName, OutcomeDesc = u.outcomeDesc}).Distinct().OrderBy(u => u.CodeO).ToList() ;

            ViewData["POCoreValue"] = POCV;
            ViewData["PO"] = PO;


            return View(); 
        }


        public ActionResult add_programOutcomes()
        {
            return View();
        }


        public ActionResult insert_programOutcomes(FormCollection detailsPO)
        {
            int i = 0;
            string coreValuesScientia = detailsPO["_PO"].ToString(); //get the core values names 
            string code = detailsPO["code_programOutcomes"].ToString();
            string attribute = detailsPO["attribute_programOutcomes"].ToString();
            string program_outcomes = detailsPO["desc_programOutcomes"].ToString();
            string[] arrCoreValues = coreValuesScientia.Split(',');
            int[] id = new int[3];
            Syllabus_ManagementEntities4 db = new Syllabus_ManagementEntities4();

            Core_Value get_coreValue = new Core_Value(); //gets the core value table 
            Program_Outcomes get_PO = new Program_Outcomes(); //gets the program outcomes table 


            for (i = 0; i < arrCoreValues.Length; i++)
            {
                //get the id of the name core value 
                string coreValueName = arrCoreValues[i];
                var getID = (from p in db.Core_Value
                             where p.name == coreValueName
                             select p.coreValue_ID).FirstOrDefault();


                get_PO.coreValue_FK = getID;
                get_PO.syllabus_FK = 1;
                get_PO.attributeName = attribute;
                get_PO.outcomeDesc = program_outcomes;
                get_PO.code_outcome = code;

                try
                {
                    db.Program_Outcomes.Add(get_PO);
                    db.SaveChanges();
                    ViewBag.Result = "Save Changes";
                }
                catch (Exception e)
                {
                    ViewBag.Result = "Error! " + e.Message;
                }
            }
            return RedirectToAction("program_outcomes", "Teacher");
        }
    }
}