using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCIS_Syllabus.Controllers
{
    public class SoftwareUsedController : Controller
    {
        // GET: SoftwareUsed
        public ActionResult Index()
        {
            return View();
        }

        // Add/Edit Software Used
        public ActionResult SoftwareUsed()
        {
            //connect to db
            Syllabus_ManagementEntities4 syllabus = new Syllabus_ManagementEntities4();
            //retrieve table details (firstName, lastName, etc.)
            Software_Used d = new Software_Used();

            //from the table friends, select all in descending order by age
            var detailS = (from u in syllabus.Software_Used
                           select u).FirstOrDefault();

            //converting all the retrieved data (friends) into a list object
            ViewData["SoftwareUsed"] = detailS;
            return View();
        }

        // Add Software Used
        public ActionResult SoftwareUsedAdd(FormCollection software)
        {
            //retrieve the Id passed from the update page (Method = "GET")
            int syllabusIDFK = Convert.ToInt32(Request.QueryString["syllabusId"]);
            string softUsed = software["software"].ToString();


            //connect to db
            Syllabus_ManagementEntities4 syllabus = new Syllabus_ManagementEntities4();
            //retrieve specific table data based from the detail Id (firstName, lastName, etc.)
            Software_Used s = new Software_Used();

            //assigning the table data through the input
            s.syllabus_FK = syllabusIDFK;
            s.software = softUsed.Replace(System.Environment.NewLine, "<br />");

            try
            {
                //add data to db
                syllabus.Software_Used.Add(s);

                //save data to db
                syllabus.SaveChanges();
                ViewBag.Result = "Saved";
            }
            catch (Exception e)
            {
                ViewBag.Result = "Not Saved" + e.Message;
            }

            syllabus.SaveChanges();
            return RedirectToAction("SoftwareUsed", "SoftwareUsed");
        }

        // Edit Software Used
        public ActionResult SoftwareUsedUpdate()
        {
            //connect to db
            Syllabus_ManagementEntities4 syllabus = new Syllabus_ManagementEntities4();
            int softUID = Convert.ToInt32(Request.QueryString["softUid"]);

            var retOneData = (from u in syllabus.Software_Used
                              where u.softwareUsed_ID == softUID
                              select u).FirstOrDefault();


            ViewData["SoftwareUsed"] = retOneData;
            return View();
        }

        // Update to DB Software Used
        public ActionResult SoftwareUsedUpdated(FormCollection software)
        {
            //retrieve the Id passed from the update page (Method = "GET")
            int softUID = Convert.ToInt32(Request.QueryString["softUid"]);
            string syllabusDesc = software["software"];


            //connect to db
            Syllabus_ManagementEntities4 syllabus = new Syllabus_ManagementEntities4();
            //retrieve specific table data based from the detail Id (firstName, lastName, etc.)
            var softwareDetail = syllabus.Software_Used.SingleOrDefault(b => b.softwareUsed_ID == softUID);

            //assigning the table data through the input
            softwareDetail.software = syllabusDesc.Replace(System.Environment.NewLine, "<br />");

            syllabus.SaveChanges();
            return RedirectToAction("SoftwareUsed", "SoftwareUsed");
        }

        // Add/Edit Software Used
        public ActionResult SoftwareUsedDelete()
        {
            Syllabus_ManagementEntities4 syllabus = new Syllabus_ManagementEntities4();
            int softUID = Convert.ToInt32(Request.QueryString["softUID"]);
            var delData = (from u in syllabus.Software_Used
                           where u.softwareUsed_ID == softUID
                           select u).FirstOrDefault();


            syllabus.Software_Used.Remove(delData);
            syllabus.SaveChanges();
            return RedirectToAction("SoftwareUsed", "SoftwareUsed");
        }
    }
}