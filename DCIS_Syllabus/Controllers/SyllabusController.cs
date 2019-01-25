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
        
        // --------------- BOOKS ---------------- //

        public ActionResult UpdateBooks(FormCollection fc)
        {
            //int courseID = Convert.ToInt32(Request.QueryString["CourseID"]);
            string bID = fc["BookID"].ToString();
            

            if (bID == "")
            {
                ViewBag.res = "add";
                string cnum = fc["CallNumber"].ToString();
                string title = fc["Title"].ToString();
                string author = fc["Author"].ToString();
                int year = Convert.ToInt32(fc["Year"].ToString());

                Syllabus_ManagementEntities4 sm = new Syllabus_ManagementEntities4();
                Book b = new Book();
                b.course_fk = 1;
                b.callNumber = cnum;
                b.title = title;
                b.author = author;
                b.year = year;
                
                try
                {
                    sm.Books.Add(b);
                    sm.SaveChanges();

                    //Book fb = new Book();
                    //var d = sm.Books.SingleOrDefault(newBook => fb.title == title);
                    //ViewBag.bID = d.book_id;
                    //Source s = new Source();
                    //s.type_of_resource = "book";
                    //s.resource_fk = d.book_id;
                    //sm.Sources.Add(s);
                    ViewBag.Result = "Saved";
                }
                catch (Exception e)
                {
                    ViewBag.Result = e;
                }



            }
            else
            {
                Syllabus_ManagementEntities4 sm = new Syllabus_ManagementEntities4();
                ViewBag.res = "update";
                int bookID = Convert.ToInt32(bID);
                var book = sm.Books.SingleOrDefault(b => b.book_id == bookID);
                string cnum = fc["CallNumber"].ToString();
                string title = fc["Title"].ToString();
                string author = fc["Author"].ToString();
                int year = Convert.ToInt32(fc["Year"].ToString());

                book.callNumber = cnum;
                book.title = title;
                book.author = author;
                book.year = year;
                book.course_fk = 1;

                sm.SaveChanges();
            }

            return RedirectToAction("Bibliography", "Teacher");
            //return View();
        }

        public ActionResult DeleteBook()
        {
            int bookID = Convert.ToInt32(Request.QueryString["BookID"]);
            Syllabus_ManagementEntities4 sm = new Syllabus_ManagementEntities4();
            var c = (from p in sm.Books
                     where p.book_id == bookID
                     select p).FirstOrDefault();


            sm.Books.Remove(c);
            sm.SaveChanges();

            return RedirectToAction("Bibliography", "Teacher");
        }

        // --------------- ONLINE RESOURCES ---------------- //
        public ActionResult UpdateWebResources(FormCollection fc)
        {
            string wID = fc["WebID"].ToString();
            if(wID == "")
            {
                ViewBag.Result = "add";
                string wname = fc["CallNumber"].ToString();
                string wlink = fc["Title"].ToString();


                Online_Sources b = new Online_Sources();
                b.webpageName = wname;
                b.weblink = wlink;
                

                try
                {
                    sm.Online_Sources.Add(b);
                    sm.SaveChanges();
                    ViewBag.Result = "Saved";
                }
                catch(Exception e)
                {
                    ViewBag.Result = e;
                }
            }
            else
            {
                ViewBag.Result = "update";
            }

            return RedirectToAction("Bibliography", "Teacher");
        }

        public ActionResult DeleteOnlineResource()
        {
            int webID = Convert.ToInt32(Request.QueryString["WebID"]);
            Syllabus_ManagementEntities4 sm = new Syllabus_ManagementEntities4();
            var webrow = (from p in sm.Online_Sources
                     where p.onlineSource_ID == webID
                     select p).FirstOrDefault();


            sm.Online_Sources.Remove(webrow);
            sm.SaveChanges();

            return RedirectToAction("Bibliography", "Teacher");
        }

         //------- ASSESSMENT CRITERIA ------- 

        public ActionResult AddNewCriteria(FormCollection fc)
        {
            string criterianame = fc["n_criterianame"].ToString();
            int poorpts = Convert.ToInt32(fc["n_poorpts"]);
            string poordesc = fc["n_poordesc"].ToString();
            int fairpts = Convert.ToInt32(fc["n_fairpts"]);
            string fairdesc = fc["n_fairdesc"].ToString();
            int epts = Convert.ToInt32(fc["n_epts"]);
            string edesc = fc["n_edesc"].ToString();
            int spts = Convert.ToInt32(fc["n_spts"]);
            string sdesc = fc["n_sdesc"].ToString();
            int hpoints = Convert.ToInt32(fc["n_hpoints"]);

            Syllabus_ManagementEntities4 sm = new Syllabus_ManagementEntities4();
            Assessment_Criteria ac = new Assessment_Criteria();
            ac.syllabus_FK = 1; // static
            ac.criteriaName = criterianame;
            ac.poor_pts = poorpts;
            ac.poor_desc = poordesc.Replace(System.Environment.NewLine, "<br />");
            ac.fair_pts = fairpts;
            ac.fair_desc = fairdesc.Replace(System.Environment.NewLine, "<br />");
            ac.satisfactory_pts = spts;
            ac.satisfactory_desc = sdesc.Replace(System.Environment.NewLine, "<br />");
            ac.excellent_pts = epts;
            ac.excellent_desc = edesc.Replace(System.Environment.NewLine, "<br />");
            ac.highestPoints = hpoints;

            try
            {
                sm.Assessment_Criteria.Add(ac);
                sm.SaveChanges();
                ViewBag.Result = "Saved";
            }
            catch (Exception e)
            {
                ViewBag.Result = e;
            }

            return RedirectToAction("AssessmentCriteria", "Teacher");
            
        }
        
        public ActionResult UpdateCriteria()
        {
            int webID = Convert.ToInt32(Request.QueryString["WebID"]);
            Syllabus_ManagementEntities4 sm = new Syllabus_ManagementEntities4();
            
            var ac = (from p in sm.Assessment_Criteria
                          where p.assesmentCriteria_ID == webID
                          select p).FirstOrDefault();
            ViewData["ACInfo"] = ac;
            return View();
        }

        public ActionResult SubmitUpdatedCriteria(FormCollection fc)
        {
            string criterianame = fc["criterianame"].ToString();
            int poorpts = Convert.ToInt32(fc["poorpts"]);
            string poordesc = fc["poordesc"].ToString();
            int fairpts = Convert.ToInt32(fc["fairpts"]);
            string fairdesc = fc["fairdesc"].ToString();
            int epts = Convert.ToInt32(fc["epts"]);
            string edesc = fc["edesc"].ToString();
            int spts = Convert.ToInt32(fc["spts"]);
            string sdesc = fc["sdesc"].ToString();
            int hpoints = Convert.ToInt32(fc["hpoints"]);


            int webID = Convert.ToInt32(Request.QueryString["WebID"]);
            Syllabus_ManagementEntities4 sm = new Syllabus_ManagementEntities4();
            var ac = sm.Assessment_Criteria.SingleOrDefault(b => b.assesmentCriteria_ID == webID);

            ac.criteriaName = criterianame;
            ac.poor_pts = poorpts;
            ac.poor_desc = poordesc.Replace(System.Environment.NewLine, "<br />");
            ac.fair_pts = fairpts;
            ac.fair_desc = fairdesc.Replace(System.Environment.NewLine, "<br />");
            ac.satisfactory_pts = spts;
            ac.satisfactory_desc = sdesc.Replace(System.Environment.NewLine, "<br />");
            ac.excellent_pts = epts;
            ac.excellent_desc = edesc.Replace(System.Environment.NewLine, "<br />");
            ac.highestPoints = hpoints;

            sm.SaveChanges();
            return RedirectToAction("AssessmentCriteria", "Teacher");
        }

        public ActionResult DeleteCriteria()
        {
            int webID = Convert.ToInt32(Request.QueryString["WebID"]);
            Syllabus_ManagementEntities4 sm = new Syllabus_ManagementEntities4();
            var ac = (from p in sm.Assessment_Criteria
                     where p.assesmentCriteria_ID == webID
                     select p).FirstOrDefault();


            sm.Assessment_Criteria.Remove(ac);
            sm.SaveChanges();

            return RedirectToAction("AssessmentCriteria", "Teacher");
        }

        public ActionResult DeleteDeliverablesAndRequirements() {
            Syllabus_ManagementEntities4 sm = new Syllabus_ManagementEntities4();
            Course_Deliverable d = new Course_Deliverable();

            int id = Convert.ToInt32(Request.QueryString["DRID"]);

            var c = (from u in sm.Course_Deliverable
                     where u.courseDeliverables_ID == id
                     select u).FirstOrDefault();

            try
            {
                sm.Course_Deliverable.Remove(c);
                sm.SaveChanges();
            }
            catch (Exception e) {
                ViewBag.Result = e;
            }
            return RedirectToAction("outputs_requirements", "Teacher");
        }

        public ActionResult UpdateDeliverablesAndRequirements() {
            Syllabus_ManagementEntities4 sm = new Syllabus_ManagementEntities4();
            Course_Deliverable d = new Course_Deliverable();
            int id = Convert.ToInt32(Request.QueryString["DRID"]);

            var c = (from u in sm.Course_Deliverable
                     where u.courseDeliverables_ID == id
                     select u).FirstOrDefault();

            ViewBag.id = c.courseDeliverables_ID;
            ViewBag.name = c.outputName;
            ViewBag.desc = c.output_description;
            ViewBag.ass1 = c.assessmentTypeA;
            ViewBag.ass2 = c.assessmentTypeB;
            return View();
        }

        public ActionResult UpdateNow2(FormCollection fc) {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            string name = fc["name"].ToString();
            string desc = fc["desc"].ToString();
            string ass1 = fc["ass1"].ToString();
            string ass2 = fc["ass2"].ToString();

            Syllabus_ManagementEntities4 sm = new Syllabus_ManagementEntities4();
            Course_Deliverable d = new Course_Deliverable();

            var c = (from u in sm.Course_Deliverable
                     where u.courseDeliverables_ID == id
                     select u).FirstOrDefault();

            c.outputName = name;
            c.output_description = desc;
            c.assessmentTypeA = ass1;
            c.assessmentTypeB = ass2;

            sm.SaveChanges();

            return RedirectToAction("outputs_requirements", "Teacher");
        }
    }
}