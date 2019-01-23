using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCIS_Syllabus.Controllers
{
    public class InstGradAttrbController : Controller
    {
        // GET: InstGradAttrb
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InstGradAttrb()
        {
            //connect to db
            Syllabus_ManagementEntities1 syllabus = new Syllabus_ManagementEntities1();
            //retrieve table details (firstName, lastName, etc.) -- what table?
            Core_Value value = new Core_Value();

            //from the table friends, select all in descending order by age
            var core_valueList = (from u in syllabus.Core_Value
                                  select u);

            //converting all the retrieved data (friends) into a list object
            ViewData["CoreValueList"] = core_valueList.ToList();
            return View();
        }
    }
}