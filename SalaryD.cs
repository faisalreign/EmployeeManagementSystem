//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SalaryD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SalaryD()
        {
            this.Eregistations = new HashSet<Eregistation>();
        }
    
        public int Id { get; set; }
        public string Department { get; set; }
        public string WorkingDay { get; set; }
        public string Leaves { get; set; }
        public string TotalSalary { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Eregistation> Eregistations { get; set; }
    }
}