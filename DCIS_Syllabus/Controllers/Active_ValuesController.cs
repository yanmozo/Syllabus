using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DCIS_Syllabus;
using DCIS_Syllabus.ViewModel;

namespace DCIS_Syllabus.Controllers
{
    public class Active_ValuesController : Controller
    {
        private Syllabus_ManagementEntities4 db = new Syllabus_ManagementEntities4();

        // GET: Active_Values
        public ActionResult Index()
        {
            var active_Values = db.Active_Values.Include(a => a.Course_Outcomes);
            return View(active_Values.ToList());
        }

        /// <summary>
        /// This looks for a specific course outcome with all active values d
        /// </summary>
        /// <param name="activeModel"></param>
        /// <returns></returns>
       /* public ActionResult ShowResults(Active_Values activeModel)//find all activeValues of courseID
        {
            var viewModel = new CourseOutcomesIndex
            {
                activeValues = db.Active_Values
                .Where(i => i.courseOutcomes_FK == activeModel.courseOutcomes_FK),
                courses = db.Course_Outcomes
                .Where(i => i.courseOutcomes_ID == activeModel.courseOutcomes_FK)
              };

            ViewBag.course_ID = activeModel.courseOutcomes_FK;
            return View("ShowResults", viewModel);
        }*/

        public ActionResult ShowResults(int id)//find all activeValues of courseID
        {
            //if(id != null)
            //{

            var viewmodel1 = new CourseOutcomesIndex();
            viewmodel1.courses = db.Course_Outcomes.Include(i => i.Active_Values)
                          .Where(i => i.syllabus_FK == id);
            //}
            viewmodel1.activeValues = db.Active_Values
                                    .Join(db.Course_Outcomes, a => a.courseOutcomes_FK, b => b.courseOutcomes_ID, 
                                    (a, b) => a);
            //ViewBag.course_ID = viewModel.ElementAt(1).activeValues.ElementAt(1).courseOutcomes_FK;     
            return View("ShowResults", viewmodel1);
        }

        // GET: Active_Values/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Active_Values active_Values = db.Active_Values.Find(id);
            if (active_Values == null)
            {
                return HttpNotFound();
            }
            return View(active_Values);
        }

        // GET: Active_Values/Create
        public ActionResult CreateActiveValues(int id)
        {
            ViewBag.courseOutcomes_FK = id;
            ViewBag.columnName = new SelectList(db.Core_Value, "coreValue_ID", "name");
            //ViewBag.courseOutcomes_FK = new SelectList(db.Course_Outcomes, "courseOutcomes_ID", "codeName");
            return View();
        }

        // POST: Active_Values/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "activeValues_ID,columnName,programOutcomeAbbr,activeStatus,courseOutcomes_FK")] Active_Values active_Values)
        {
            if (ModelState.IsValid)
            {
                db.Active_Values.Add(active_Values);
                db.SaveChanges();
                return RedirectToAction("ShowResults",active_Values);
            }

            ViewBag.courseOutcomes_FK = new SelectList(db.Course_Outcomes, "courseOutcomes_ID", "codeName", active_Values.courseOutcomes_FK);
            return View(active_Values);
        }

        // GET: Active_Values/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Active_Values active_Values = db.Active_Values.Find(id);
            if (active_Values == null)
            {
                return HttpNotFound();
            }
            ViewBag.courseOutcomes_FK = new SelectList(db.Course_Outcomes, "courseOutcomes_ID", "codeName", active_Values.courseOutcomes_FK);
            return View(active_Values);
        }

        // POST: Active_Values/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "activeValues_ID,columnName,programOutcomeAbbr,activeStatus,courseOutcomes_FK")] Active_Values active_Values)
        {
            if (ModelState.IsValid)
            {
                db.Entry(active_Values).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.courseOutcomes_FK = new SelectList(db.Course_Outcomes, "courseOutcomes_ID", "codeName", active_Values.courseOutcomes_FK);
            return View(active_Values);
        }

        // GET: Active_Values/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Active_Values active_Values = db.Active_Values.Find(id);
            if (active_Values == null)
            {
                return HttpNotFound();
            }
            return View(active_Values);
        }

        // POST: Active_Values/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Active_Values active_Values = db.Active_Values.Find(id);
            db.Active_Values.Remove(active_Values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
