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
    
    public partial class Zimmer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zimmer()
        {
            this.Zimmerbuchung = new HashSet<Zimmerbuchung>();
        }
    
        public int id { get; set; }
        public int kategorie_id { get; set; }
        public int zimmerNummer { get; set; }
    
        public virtual Kategorie Kategorie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zimmerbuchung> Zimmerbuchung { get; set; }
    }
}
