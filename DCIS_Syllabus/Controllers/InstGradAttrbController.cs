using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DCIS_Syllabus.Models;

namespace DCIS_Syllabus.Controllers
{
    public class InstGradAttrbController : Controller
    {
        // GET: InstGradAttrb
        public ActionResult Index()
        {
            return View();
        }

        // Chair View
        public ActionResult InstGradAttrb()
        {
            //connect to db
            Syllabus_ManagementEntities4 syllabus = new Syllabus_ManagementEntities4();
            //retrieve table details (firstName, lastName, etc.) -- what table?
            //Core_Value value = new Core_Value();

            //from the table friends, select all in descending order by age
            var core_valueList = (from cv in syllabus.Core_Value
                                  join cva in syllabus.Core_Value_Attribute on cv.coreValue_ID equals cva.coreValue_FK
                                  select new CoreValue{  CoreValueName = cv.name, Attribute = cva.description, CoreValueAttrb_Id = cva.coreValueAttrib_ID }).ToList();

            //converting all the retrieved data (friends) into a list object
            ViewData["CoreValueList"] = core_valueList;
            return View(core_valueList);
        }

        // Chair Create
        public ActionResult AddCoreValue(FormCollection cv_info)
        {
            //retrieve data from URL because passed through form
            string cv_desc = Convert.ToString(Request.QueryString["cvAttrib"]).Replace(System.Environment.NewLine, "<br />");
            string cv_CoreValueName = Convert.ToString(Request.QueryString["cvCoreValue"]);

            //connect to db
            Syllabus_ManagementEntities4 syllabus = new Syllabus_ManagementEntities4();

            //retrieve table details (firstName, lastName, etc.)
            Core_Value_Attribute cv_a = new Core_Value_Attribute();
            Core_Value cv = new Core_Value();

            //find the id base from the selected
            var core_val = (from u in syllabus.Core_Value
                            where u.name == cv_CoreValueName
                            select u);

            //assigning the table data through the input using only the FIRST
            cv_a.coreValue_FK = core_val.First().coreValue_ID;
            cv_a.description = cv_desc;

            try
            {
                //add data to db
                syllabus.Core_Value_Attribute.Add(cv_a);

                //save data to db
                syllabus.SaveChanges();
            }
            catch (Exception)
            {
            }
            return RedirectToAction("InstGradAttrb", "InstGradAttrb");
        }

        // Chair Update
        public ActionResult UpdateCoreValue(FormCollection cv_info)
        {
            //connect to db
            Syllabus_ManagementEntities4 syllabus = new Syllabus_ManagementEntities4();
            int cv_attr_id = Convert.ToInt32(Request.QueryString["coreValAttrIdU"]);

            var retOneData = (from u in syllabus.Core_Value_Attribute
                              where u.coreValueAttrib_ID == cv_attr_id
                              select u).FirstOrDefault();


            ViewData["OneDetailCVA"] = retOneData;
            return View();
        }

        // Chair Update
        public ActionResult UpdatedCoreValue(FormCollection cv_info)
        {
            //retrieve the Id passed from the update page (Method = "GET")
            int cv_attrbId = Convert.ToInt32(Request.QueryString["CoreValueAttrbId"]);
            string cv_desc = cv_info["cvCoreAttrbU"].Replace(System.Environment.NewLine, "<br />");
            string cv_CoreValueName = cv_info["cvCoreValueU"];


            //connect to db
            Syllabus_ManagementEntities4 syllabus = new Syllabus_ManagementEntities4();
            //retrieve specific table data based from the detail Id (firstName, lastName, etc.)
            //retrieve table details (firstName, lastName, etc.)

            //find the id base from the selected
            var coreValue_FKRet = (from u in syllabus.Core_Value
                                   where u.name == cv_CoreValueName
                                   select u.coreValue_ID).FirstOrDefault();
            var cvaDetail = syllabus.Core_Value_Attribute.SingleOrDefault(b => b.coreValueAttrib_ID == cv_attrbId);

            //assigning the table data through the input
            cvaDetail.coreValue_FK = coreValue_FKRet;
            cvaDetail.description = cv_desc;

            syllabus.SaveChanges();
            return RedirectToAction("InstGradAttrb", "InstGradAttrb");
            //ViewBag.Result = cv_desc;
            //return View();
        }

        // Chair Delete
        public ActionResult DeleteCoreValue(FormCollection cv_info)
        {
            //connect to db
            Syllabus_ManagementEntities4 syllabus = new Syllabus_ManagementEntities4();
            int cv_attr_id = Convert.ToInt32(Request.QueryString["coreValAttrIdD"]);
            var delData = (from u in syllabus.Core_Value_Attribute
                           where u.coreValueAttrib_ID == cv_attr_id
                           select u).FirstOrDefault();


            syllabus.Core_Value_Attribute.Remove(delData);
            syllabus.SaveChanges();
            return RedirectToAction("InstGradAttrb", "InstGradAttrb");
        }

        // Teacher and Coordinator View
        public ActionResult InstGradAttrbViewTC()
        {
            //connect to db
            Syllabus_ManagementEntities4 syllabus = new Syllabus_ManagementEntities4();
            //retrieve table details (firstName, lastName, etc.) -- what table?
            //Core_Value value = new Core_Value();

            //from the table friends, select all in descending order by age
            var core_valueList = (from cv in syllabus.Core_Value
                                  join cva in syllabus.Core_Value_Attribute on cv.coreValue_ID equals cva.coreValue_FK
                                  select new CoreValue { CoreValueName = cv.name, Attribute = cva.description, CoreValueAttrb_Id = cva.coreValueAttrib_ID }).ToList();

            //converting all the retrieved data (friends) into a list object
            ViewData["CoreValueList"] = core_valueList;
            return View(core_valueList);
        }
    }
}