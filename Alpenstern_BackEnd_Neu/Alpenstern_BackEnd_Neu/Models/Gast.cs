//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Alpenstern_BackEnd_Neu.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Gast
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Gast()
        {
            this.Gastlogin = new HashSet<Gastlogin>();
        }
    
        public int id { get; set; }
        public int stadt_id { get; set; }
        public string vorname { get; set; }
        public string nachname { get; set; }
        public System.DateTime geburtsdatum { get; set; }
        public string straße { get; set; }
        public string email { get; set; }
        public string telefonnummer { get; set; }
        public string reisepassnummer { get; set; }
    
        public virtual Stadt Stadt { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gastlogin> Gastlogin { get; set; }
    }
}
