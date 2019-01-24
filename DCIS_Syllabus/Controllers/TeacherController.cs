using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace DCIS_Syllabus.Controllers
{
    public class TeacherController : Controller
    {
        // GET: ViewAllSyllabus
        public ActionResult ViewAllTSyllabus()
        {
            // Get all syllabus of all handled courses here.
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
            return View();
        }

        public ActionResult Bibliography()
        {
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


        public ActionResult insert_grading(FormCollection fc)
        {
            //can insert to database using static data ONLY 

            Syllabus_ManagementEntities3 fe = new Syllabus_ManagementEntities3();

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
            // return View();
            return RedirectToAction("grading_system", "Teacher");
        }

        public ActionResult insert_data_here(string[][] array)
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

             //   Syllabus_ManagementEntities3 fe = new Syllabus_ManagementEntities3(); //db

              //  Grading_System d = new Grading_System(); //table

                SqlConnection cnn = new SqlConnection();
                cnn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings
                ["Syllabus_ManagementEntities3"].ToString();
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SaveGradingDetails";
                cmd.Connection = cnn;
                cmd.Parameters.Add("@Grading_System", SqlDbType.Structured).SqlValue = dt;

                ViewBag.Result = cmd.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
               ViewBag.Result = ex.Message;
            }
            //return result;
            return View(); 
        }
      
        public ActionResult add_revision()
        {
            return View();
        }

        public ActionResult insert_revison_history(FormCollection getGradingSystem)
        {
           

            return View(); 
        }
    }
}