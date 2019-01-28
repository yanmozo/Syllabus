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
    
    public partial class Offered
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Offered()
        {
            this.Teachers = new HashSet<Teacher>();
            this.Topics = new HashSet<Topic>();
        }
    
        public int offered_id { get; set; }
        public int start_time { get; set; }
        public int end_time { get; set; }
        public string day { get; set; }
        public int course_id { get; set; }
        public int room_id { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual Room Room { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teacher> Teachers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
