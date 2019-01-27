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
    public class Course_OutcomesController : Controller
    {
        private Syllabus_ManagementEntities4 db = new Syllabus_ManagementEntities4();

        // GET: Course_Outcomes
        public ActionResult Index()
        {
            var course_Outcomes = db.Course_Outcomes.Include(c => c.Syllabu);
            return View(course_Outcomes.ToList());

        }


        // GET: Course_Outcomes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Outcomes course_Outcomes = db.Course_Outcomes.Find(id);
            if (course_Outcomes == null)
            {
                return HttpNotFound();
            }
            return View(course_Outcomes);
        }

        // GET: Course_Outcomes/Create
        public ActionResult Create()
        {
            ViewBag.syllabus_FK = new SelectList(db.Syllabus, "syllabus_ID", "title");
            return View();
        }

        // POST: Course_Outcomes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "courseOutcomes_ID,syllabus_FK,codeName,outcomeDescription,domainLearningLVL")] Course_Outcomes course_Outcomes)
        {
            if (ModelState.IsValid)
            {
                db.Course_Outcomes.Add(course_Outcomes);
                db.SaveChanges();

                db.Entry(course_Outcomes).GetDatabaseValues();
                int newID = course_Outcomes.courseOutcomes_ID;
                int numOfPO = db.Program_Outcomes.Select(d => d.code_outcome).Distinct().Count();
                int syllabusID = course_Outcomes.syllabus_FK;
                PopulateModels(numOfPO, newID);

                return RedirectToAction("ShowResults", "Active_Values", new { id = syllabusID});
            }

            ViewBag.syllabus_FK = new SelectList(db.Syllabus, "syllabus_ID", "title", course_Outcomes.syllabus_FK);
            return View(course_Outcomes);
        }
        

        private void PopulateModels(int numOfPO, int courseOutcomes_ID)
        {
            //List<Active_Values> modelActiveModels = new List<Active_Values>();

            string[] colName = { "S", "V", "D" };
            int j = 1;
            for (int i = 0; i < numOfPO; i++) //the first three does not have columnName
            {
                Active_Values av = new Active_Values();
                if (i < 3)
                {
                    av.columnName = colName[i];
                }
                else
                {
                    av.columnName = j.ToString();
                    
                    j++;
                }

                av.programOutcomeAbbr = " ";
                av.activeStatus = "false";
                av.courseOutcomes_FK = courseOutcomes_ID;
                db.Active_Values.Add(av);
                db.SaveChanges();
            }


        }

        // GET: Course_Outcomes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Outcomes course_Outcomes = db.Course_Outcomes.Find(id);
            if (course_Outcomes == null)
            {
                return HttpNotFound();
            }
            ViewBag.syllabus_FK = new SelectList(db.Syllabus, "syllabus_ID", "title", course_Outcomes.syllabus_FK);
            return View(course_Outcomes);
        }

        // POST: Course_Outcomes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "courseOutcomes_ID,syllabus_FK,codeName,outcomeDescription,domainLearningLVL")] Course_Outcomes course_Outcomes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course_Outcomes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.syllabus_FK = new SelectList(db.Syllabus, "syllabus_ID", "title", course_Outcomes.syllabus_FK);
            return View(course_Outcomes);
        }

        // GET: Course_Outcomes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Outcomes course_Outcomes = db.Course_Outcomes.Find(id);
            if (course_Outcomes == null)
            {
                return HttpNotFound();
            }
            return View(course_Outcomes);
        }

        // POST: Course_Outcomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course_Outcomes course_Outcomes = db.Course_Outcomes.Find(id);
            db.Course_Outcomes.Remove(course_Outcomes);
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
