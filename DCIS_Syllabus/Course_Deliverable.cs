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
    
    public partial class Course_Deliverable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course_Deliverable()
        {
            this.Grading_System = new HashSet<Grading_System>();
        }
    
        public int courseDeliverables_ID { get; set; }
        public int courseOutcomeAdd_FK { get; set; }
        public int syllabus_FK { get; set; }
        public string outputName { get; set; }
        public string output_description { get; set; }
        public string assessmentTypeA { get; set; }
        public string assessmentTypeB { get; set; }
    
        public virtual Course_Outcome_Addressed Course_Outcome_Addressed { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grading_System> Grading_System { get; set; }
        public virtual Syllabu Syllabu { get; set; }
    }
}
