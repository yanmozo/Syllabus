using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCIS_Syllabus.Controllers
{
    public class ChairmanController : Controller
    {
        // GET: Chairman
        public ActionResult ViewAllChSyllabus()
        {
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

        public ActionResult ProgramObj()
        {
            Syllabus_ManagementEntities3 f = new Syllabus_ManagementEntities3();
            Program_Educational_Objs d = new Program_Educational_Objs();

            var detailList = (from u in f.Core_Value select u);
            ViewData["cores"] = detailList.ToList();

            var proEduOut = (from u in f.Program_Educational_Objs select u);
            ViewData["listOfProEdu"] = proEduOut.ToList();
            return View();
        }

        public ActionResult Want(FormCollection fc)
        {
            string code = fc["code"].ToString();
            string desc = fc["desc"].ToString();
            string status = fc["status"].ToString();
            int sylid = 1;

            

            Syllabus_ManagementEntities3 f = new Syllabus_ManagementEntities3();
            Program_Educational_Objs d = new Program_Educational_Objs();

            var coreid = (from u in f.Core_Value where u.name == status select u.coreValue_ID).FirstOrDefault();

            ViewBag.code = code;
            ViewBag.desc = desc;
            ViewBag.status = status;
            ViewBag.coreid = coreid;

            d.objectives = desc;
            d.codeName = code;
            d.syllabus_FK = sylid;
            d.coreValue_FK =Convert.ToInt32(coreid);
            

            try
            {
                f.Program_Educational_Objs.Add(d);
                f.SaveChanges();
                ViewBag.Result = "Saved";
            }
            catch (Exception e)
            {
                ViewBag.Result = e;
            }
            return RedirectToAction("ProgramObj", "Chairman");
        }
    }
}