//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP.NET_MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class COURANTLITTERAIRE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COURANTLITTERAIRE()
        {
            this.LIVRE = new HashSet<LIVRE>();
        }
    
        public int commentlitteraire_id { get; set; }
        public string libelle { get; set; }
        public Nullable<int> genre_id { get; set; }
    
        public virtual GENRE GENRE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LIVRE> LIVRE { get; set; }
    }
}
