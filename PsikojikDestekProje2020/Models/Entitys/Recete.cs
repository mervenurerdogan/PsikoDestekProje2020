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
    
    public partial class Recete
    {
        public long ReceteID { get; set; }
        public string ilacAdi { get; set; }
        public string Doz { get; set; }
        public string KullanımTalimati { get; set; }
        public Nullable<long> HastaID { get; set; }
        public Nullable<long> DoktorID { get; set; }
    
        public virtual Doktor Doktor { get; set; }
        public virtual Hasta Hasta { get; set; }
    }
}
