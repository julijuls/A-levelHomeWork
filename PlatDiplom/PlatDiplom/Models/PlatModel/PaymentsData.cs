using PlatDiplom.Models.PlatModel;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;


namespace PlatDiplom.Models
{
    public class PaymentsData
    {
         public int id_plat { get; set; }
        public string PurOfPayment { get; set; }
        public Nullable<double> sum { get; set; }
        public string OurCase { get; set; }
        public string TaxNum { get; set; }
        public Nullable<int> region_id { get; set; }
        public Nullable<int> currency_id { get; set; }
        public string currency { get; set; }
        public Nullable<int> User_id { get; set; }
        public string User { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public Nullable<System.DateTime> deadline { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public Nullable<System.DateTime> Paid { get; set; }
        public string File { get; set; }
        public UploadFiles.FileOptions FileObj { get; set; }
        public Nullable<int> Bank_id { get; set; }
        public virtual About_banks About_banks { get; set; }
        public virtual Countries Countries { get; set; }
        public virtual Currencies Currencies { get; set; }
        public virtual Users Users { get; set; }
      

    }
}