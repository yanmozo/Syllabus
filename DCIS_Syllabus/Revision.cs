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
    
    public partial class Revision
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Revision()
        {
            this.Revisions_Log = new HashSet<Revisions_Log>();
        }
    
        public int revision_ID { get; set; }
        public int syllabus_FK { get; set; }
        public double versionNum { get; set; }
        public string fieldsRevised { get; set; }
        public string dateRevised { get; set; }
        public string approvedDate { get; set; }
        public string revisedBy { get; set; }
        public string approvedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Revisions_Log> Revisions_Log { get; set; }
        public virtual Syllabu Syllabu { get; set; }
    }
}
