//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Alpenstern_BackEnd_Neu.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Komplettpaket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Komplettpaket()
        {
            this.Komplettbuchung = new HashSet<Komplettbuchung>();
        }
    
        public int id { get; set; }
        public string bezeichnung { get; set; }
        public decimal zuschlagProTag { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Komplettbuchung> Komplettbuchung { get; set; }
    }
}
