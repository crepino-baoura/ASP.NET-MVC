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
    
    public partial class LIVRE
    {
        public int livre_id { get; set; }
        public string libelle { get; set; }
        public string url { get; set; }
        public string image_livre { get; set; }
        public Nullable<System.DateTime> date_edit { get; set; }
        public  Nullable<int> genre_id { get; set; }
        public Nullable<int> commentlitteraire_id { get; set; }
        public Nullable<int> AUTEUR { get; set; }
        public Nullable<int> editeur_id { get; set; }
    
        public virtual AUTEUR AUTEUR1 { get; set; }
        public virtual COURANTLITTERAIRE COURANTLITTERAIRE { get; set; }
        public virtual EDITEUR EDITEUR { get; set; }
        public virtual GENRE GENRE { get; set; }
    }
}
