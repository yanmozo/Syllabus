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
    
    public partial class Course_Outcome_Addressed
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course_Outcome_Addressed()
        {
            this.Course_Deliverable = new HashSet<Course_Deliverable>();
        }
    
        public int courseOutcomeAddressed_ID { get; set; }
        public int courseOutcome_FK { get; set; }
        public int addressedCO_Num { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course_Deliverable> Course_Deliverable { get; set; }
        public virtual Course_Outcomes Course_Outcomes { get; set; }
    }
}
