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
    
    public partial class Program_Outcomes
    {
        public int programOutcomes_ID { get; set; }
        public int coreValue_FK { get; set; }
        public int syllabus_FK { get; set; }
        public string attributeName { get; set; }
        public string outcomeDesc { get; set; }
        public string code_outcome { get; set; }
    
        public virtual Core_Value Core_Value { get; set; }
        public virtual Syllabu Syllabu { get; set; }
    }
}
