//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tsystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CourseSchedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CourseSchedule()
        {
            this.Registered_in_the_course = new HashSet<Registered_in_the_course>();
        }
    
        public int Course_ID { get; set; }
        public string Course_Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.TimeSpan> Start_Time { get; set; }
        public Nullable<System.TimeSpan> End_Time { get; set; }
        public string Course_Status { get; set; }
        public Nullable<int> Seats_Number { get; set; }
        public string Course_Place { get; set; }
        public string user_Type { get; set; }
        public Nullable<int> Classification_ID { get; set; }
        public string Course_Type { get; set; }
        public Nullable<int> Certificate_ID { get; set; }
        public string Trainer_Name { get; set; }
    
        public virtual CertificateTemplate CertificateTemplate { get; set; }
        public virtual CourseClassification CourseClassification { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registered_in_the_course> Registered_in_the_course { get; set; }
    }
}
