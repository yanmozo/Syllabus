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
    
    public partial class Consultation
    {
        public int consultationId { get; set; }
        public int schoolId { get; set; }
        public string time { get; set; }
        public string place { get; set; }
        public string message { get; set; }
        public string status { get; set; }
        public string subject { get; set; }
        public string date { get; set; }
        public int memberId { get; set; }
    
        public virtual Member Member { get; set; }
    }
}