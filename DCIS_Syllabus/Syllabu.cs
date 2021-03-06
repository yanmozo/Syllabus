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
    
    public partial class Syllabu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Syllabu()
        {
            this.Assessment_Criteria = new HashSet<Assessment_Criteria>();
            this.Bibliographies = new HashSet<Bibliography>();
            this.Class_Policy = new HashSet<Class_Policy>();
            this.Course_Deliverable = new HashSet<Course_Deliverable>();
            this.Course_Outcomes = new HashSet<Course_Outcomes>();
            this.Grading_System = new HashSet<Grading_System>();
            this.Learning_Plan = new HashSet<Learning_Plan>();
            this.Program_Educational_Objs = new HashSet<Program_Educational_Objs>();
            this.Program_Outcomes = new HashSet<Program_Outcomes>();
            this.Revisions = new HashSet<Revision>();
            this.Software_Used = new HashSet<Software_Used>();
        }
    
        public int syllabus_ID { get; set; }
        public int madeBy_FK { get; set; }
        public int course_FK { get; set; }
        public string title { get; set; }
        public string academicYear { get; set; }
        public string academicPeriod { get; set; }
        public string status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assessment_Criteria> Assessment_Criteria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bibliography> Bibliographies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Class_Policy> Class_Policy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course_Deliverable> Course_Deliverable { get; set; }
        public virtual Course_Information Course_Information { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course_Outcomes> Course_Outcomes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grading_System> Grading_System { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Learning_Plan> Learning_Plan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Program_Educational_Objs> Program_Educational_Objs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Program_Outcomes> Program_Outcomes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Revision> Revisions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Software_Used> Software_Used { get; set; }
    }
}
