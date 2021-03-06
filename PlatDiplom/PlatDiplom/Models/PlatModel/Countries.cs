//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlatDiplom.Models.PlatModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Countries
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Countries()
        {
            this.PaymentsRU = new HashSet<PaymentsRU>();
        }
    
        public int id_country { get; set; }
        public string Country_Eng { get; set; }
        public string Country_Rus { get; set; }
        public string Country_Ukr { get; set; }
        public string Country_Code { get; set; }
        public Nullable<bool> Favourite { get; set; }
        public byte[] SSMA_TimeStamp { get; set; }
        public string Country_CN { get; set; }
        public string Country_BE { get; set; }
        public string Country_ES { get; set; }
        public string Country_PT { get; set; }
        public string Country_DE { get; set; }
        public string Country_FR { get; set; }
        public string Country_IT { get; set; }
        public string Country_PL { get; set; }
        public string Country_JA { get; set; }
        public string Country_LT { get; set; }
        public string Country_LV { get; set; }
        public string Country_CZ { get; set; }
        public string Comment { get; set; }
    
        public virtual Countries Countries1 { get; set; }
        public virtual Countries Countries2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentsRU> PaymentsRU { get; set; }
    }
}
