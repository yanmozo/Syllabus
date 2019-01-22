using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCIS_Syllabus.Controllers
{
    public class AddNewSyllabusController : Controller
    {
        // GET: AddNewSyllabus
        public ActionResult NewSyllabus()
        {
            return View();
        }
    }
}