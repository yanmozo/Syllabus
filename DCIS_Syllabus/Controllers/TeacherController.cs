using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

            Syllabus_ManagementEntities4 fe = new Syllabus_ManagementEntities4();
            Revision d = new Revision();

           //var detailList = (from u in fe.Details
           //                       select u).OrderByDescending(x => x.Age);
           //ViewData["ListOfFriends"] = detailList.ToList();

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


        public ActionResult Creation()
        {
            var getData = (from courses in sm.Course_Information
                           select courses);


            ViewData["ListofCourses"] = getData.ToList();
            return View();
        }

        public ActionResult outputs_requirements()
        {
            return View();
        }


        public ActionResult insert_grading(FormCollection fc)
        {
            //can insert to database using static data ONLY 

            Syllabus_ManagementEntities4 fe = new Syllabus_ManagementEntities4();

            Grading_System d = new Grading_System();
            // d.gradingSystem_ID = 1;
            d.syllabus_FK = 1;
            d.typeOfGrading = "Outputs";
            d.weight = 1.0;
            d.requirementsName = "Lectures";

            try
            {
                fe.Grading_System.Add(d);
                fe.SaveChanges();
                ViewBag.Result = "Save Changes";
            }
            catch (Exception e)
            {
                ViewBag.Result = "Error! ";
            }
             return View();
           // return RedirectToAction("grading_system", "Teacher");
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
            catch (Exception e)
            {
                ViewBag.Result = "Error! ";
            }
            return RedirectToAction("revision_history", "Teacher");
        }

        public ActionResult insert_revisionHistory()
        {
            
            return View();
        }


    
    }
}