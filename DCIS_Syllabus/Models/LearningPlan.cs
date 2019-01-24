using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCIS_Syllabus.Models
{
    public class LearningPlan
    {
        public int LearningId { get; set; }
        public int CourseOutcomeFK { get; set; }
        public int CourseIdFK { get; set; }
        public int QuarterIdFK { get; set; }
        public int SyllabusIdFK { get; set; }
        public string LODesc { get; set; }
        public int hrs { get; set; }
        public string topics { get; set; }
        public string teacherAct { get; set; }
        public string learnerAct { get; set; }
        public string assessAct { get; set; }
        public string QuarterName { get; set; }
    }
}