//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PsikojikDestekProje2020.Models.Entitys
{
    using System;
    using System.Collections.Generic;
    
    public partial class Doktor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Doktor()
        {
            this.HastaNot = new HashSet<HastaNot>();
            this.Randevu = new HashSet<Randevu>();
            this.Recete = new HashSet<Recete>();
        }
    
        public long Doktorid { get; set; }
        public string DoktorAdı { get; set; }
        public string SoktorSoyadı { get; set; }
        public string DoktorTel { get; set; }
        public string DoktorMail { get; set; }
        public string DoktorSifre { get; set; }
        public Nullable<int> BolumID { get; set; }
        public string DoktorUnvan { get; set; }
    
        public virtual Bolum Bolum { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HastaNot> HastaNot { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Randevu> Randevu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recete> Recete { get; set; }
    }
}