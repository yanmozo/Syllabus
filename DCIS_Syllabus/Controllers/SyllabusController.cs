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
    }
}