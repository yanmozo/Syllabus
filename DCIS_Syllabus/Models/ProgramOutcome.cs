using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCIS_Syllabus.Models
{
    public class ProgramOutcome
    {
        public string CodeO { get; set; }
        public int SyllabusFK { get; set; }
        public string AttributeName { get; set; }
        public string OutcomeDesc { get; set; }
    }
}