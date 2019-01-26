using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DCIS_Syllabus.ViewModel
{
    public class CourseOutcomesIndex
    {
        public IEnumerable<Course_Outcomes> courses { get; set; } 
        public IEnumerable<Active_Values>  activeValues { get; set; } 
    }

}