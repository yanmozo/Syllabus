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
            Syllabus_ManagementEntities4 sm = new Syllabus_ManagementEntities4();
            Syllabu s = new Syllabu();

            var syllabusList = (from u in sm.Syllabus
                                select u);
            ViewData["ListofSyllabus_C"] = syllabusList.ToList();
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

        public ActionResult ProgramObj2()
        {
            Syllabus_ManagementEntities4 f = new Syllabus_ManagementEntities4();
            Program_Educational_Objs d = new Program_Educational_Objs();

            var detailList = (from u in f.Core_Value select u);
            ViewData["cores"] = detailList.ToList();


            var proEduOut = (from u in f.Program_Educational_Objs
                             join newer in f.Core_Value on u.coreValue_FK equals newer.coreValue_ID 
                             select u);
            ViewData["listOfProEdu"] = proEduOut.ToList();
            return View();
        }

        public ActionResult ProgramEduObj(FormCollection fc)
        {
            string code = fc["code"].ToString();
            string desc = fc["desc"].ToString();
            string status = fc["status"].ToString();
            int sylid = 1;

            

            Syllabus_ManagementEntities4 f = new Syllabus_ManagementEntities4();
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
            return RedirectToAction("ProgramObj2", "Chairman");
        }

        public ActionResult DeleteThings() {
            Syllabus_ManagementEntities4 f = new Syllabus_ManagementEntities4();
            Program_Educational_Objs d = new Program_Educational_Objs();

            int ids = Convert.ToInt32(Request.QueryString["ids"]);

            var c = (from p in f.Program_Educational_Objs
                     where p.programEduOutcome_ID == ids
                     select p).FirstOrDefault();
        
                f.Program_Educational_Objs.Remove(c);
                f.SaveChanges();
  
            return RedirectToAction("ProgramObj2", "Chairman");
        }

        public ActionResult PassToUpdate() {
            Syllabus_ManagementEntities4 f = new Syllabus_ManagementEntities4();

            int detailId = Convert.ToInt32(Request.QueryString["ids"]);

            var c = (from p in f.Program_Educational_Objs
                     where p.programEduOutcome_ID == detailId
                     select p).FirstOrDefault();
            ViewBag.objective = c.objectives;
            ViewBag.codename = c.codeName;
            ViewBag.id = c.programEduOutcome_ID;

            var detailList = (from u in f.Core_Value select u);
            ViewData["cores"] = detailList.ToList();

            return View();
        }

        public ActionResult UpdateNow(FormCollection fc) {
            string code = fc["code"].ToString();
            string desc = fc["desc"].ToString();
            string status = fc["status"].ToString();
            int id2 = Convert.ToInt32(Request.QueryString["id"]);

           
            Syllabus_ManagementEntities4 f = new Syllabus_ManagementEntities4();
            Core_Value cores = new Core_Value();

            var stat = (from u in f.Core_Value
                        where u.name == status
                        select u.coreValue_ID).FirstOrDefault();
           

            var d = f.Program_Educational_Objs.SingleOrDefault(b => b.programEduOutcome_ID == id2);

            d.objectives = code;
            d.codeName = code;
            d.coreValue_FK = stat;

            f.SaveChanges();
            return RedirectToAction("ProgramObj2", "Chairman");
        }

        public ActionResult AddDeli(FormCollection fc)
        {
            string code = fc["code"].ToString();
            string desc = fc["desc"].ToString();
            int co = 7;
            string ass1 = fc["ass1"].ToString();
            string ass2 = fc["ass2"].ToString();
            int syllabus = 1;

            Syllabus_ManagementEntities4 f = new Syllabus_ManagementEntities4();
            Course_Deliverable d = new Course_Deliverable();

            d.outputName = code;
            d.output_description = desc;
            d.courseOutcomeAddressed_FK = co;
            d.assessmentTypeA = ass1;
            d.assessmentTypeB = ass2;
            d.syllabus_FK = syllabus;

            try
            {
                f.Course_Deliverable.Add(d);
                f.SaveChanges();
                ViewBag.Result = "Saved";
            }
            catch (Exception e)
            {
                ViewBag.Result = e;
            }
            return RedirectToAction("outputs_requirements", "Teacher");
            //return View("../teacher/outputs_requirements");
        }
    }
}