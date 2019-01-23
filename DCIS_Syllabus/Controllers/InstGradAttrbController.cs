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

        // Teacher and Coordinator View
        public ActionResult InstGradAttrb()
        {
            //connect to db
            Syllabus_ManagementEntities4 syllabus = new Syllabus_ManagementEntities4();
            //retrieve table details (firstName, lastName, etc.) -- what table?
            //Core_Value value = new Core_Value();

            //from the table friends, select all in descending order by age
            var core_valueList = (from cv in syllabus.Core_Value
                                  join cva in syllabus.Core_Value_Attribute on cv.coreValue_ID equals cva.coreValue_FK
                                  select new CoreValue{  CoreValueName = cv.name, Attribute = cva.description }).ToList();

            //converting all the retrieved data (friends) into a list object
            ViewData["CoreValueList"] = core_valueList;
            return View(core_valueList);
        }
    }
}