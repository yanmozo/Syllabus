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
    
    public partial class Course_Information
    {
        public int course_ID { get; set; }
        public string courseCode { get; set; }
        public string title { get; set; }
        public string credits { get; set; }
        public string equivalent { get; set; }
        public string preRequisites { get; set; }
        public string coRequisites { get; set; }
        public string term { get; set; }
        public string room { get; set; }
        public System.TimeSpan time { get; set; }
        public string day { get; set; }
    }
}