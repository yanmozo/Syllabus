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
    
    public partial class Course_Outcomes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course_Outcomes()
        {
            this.Course_Outcome_Addressed = new HashSet<Course_Outcome_Addressed>();
        }
    
        public int courseOutcomes_ID { get; set; }
        public int activeValues_FK { get; set; }
        public int syllabus_FK { get; set; }
        public string codeName { get; set; }
        public string outcomeDescription { get; set; }
        public string domainLearningLVL { get; set; }
    
        public virtual Active_Values Active_Values { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course_Outcome_Addressed> Course_Outcome_Addressed { get; set; }
        public virtual Syllabu Syllabu { get; set; }
    }
}