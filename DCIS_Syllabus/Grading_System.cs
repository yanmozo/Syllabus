//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DCIS_Syllabus
{
    using System;
    using System.Collections.Generic;
    
    public partial class Grading_System
    {
        public int gradingSystem_ID { get; set; }
        public int courseDescription_FK { get; set; }
        public int syllabus_FK { get; set; }
        public string typeOfGrading { get; set; }
        public double weight { get; set; }
    
        public virtual Course_Deliverable Course_Deliverable { get; set; }
        public virtual Syllabu Syllabu { get; set; }
    }
}
