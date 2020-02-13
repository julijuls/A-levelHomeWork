
namespace PlatDiplom.Models.PlatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class PaymentsRU
    {
        public int id_plat { get; set; }
        [Display(Name = "Purpose of payment")]
        public string PurOfPayment { get; set; }
        public string applnumber { get; set; }
        [Display(Name = "Sum")]
        public Nullable<double> sum { get; set; }
        [Display(Name = "Case")]
        public string OurCase { get; set; }
        public string TaxNum { get; set; }
        public string Comment { get; set; }
        public Nullable<int> region_id { get; set; }
        public Nullable<double> Sum_for_reg { get; set; }
        public Nullable<int> currency_id { get; set; }
        public Nullable<int> User_id { get; set; }
        public byte[] ts { get; set; }
        public Nullable<int> old_plat_num { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Deadline")]
        public Nullable<System.DateTime> deadline { get; set; }
      
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Paid")]
        public Nullable<System.DateTime> Paid { get; set; }
        public string File { get; set; }
        public Nullable<int> currency2_id { get; set; }
        public string Act { get; set; }
        public Nullable<bool> Pay { get; set; }
        public Nullable<System.DateTime> DateAct { get; set; }
        public Nullable<double> SumAct { get; set; }
        public Nullable<bool> ASAP { get; set; }
        public Nullable<System.DateTime> DateStamp { get; set; }
        public Nullable<double> SumbyAct { get; set; }
        public Nullable<int> Buh_id { get; set; }
        public Nullable<int> TaxCodeUA { get; set; }
        public string OwnCountryCode { get; set; }
        public string CountryinUA { get; set; }
        public Nullable<int> Bank_id { get; set; }
        public string TaxOrder { get; set; }
        public Nullable<System.DateTime> Writtenoff { get; set; }
        public string Invoice { get; set; }
        public Nullable<decimal> Remainder { get; set; }
        public Nullable<int> DNid { get; set; }
    
        public virtual About_banks About_banks { get; set; }
        public virtual Countries Countries { get; set; }
        public virtual Currencies Currencies { get; set; }
        public virtual Users Users { get; set; }
    }
}
