using PlatDiplom.Models.PlatModel;
using PlatDiplom.Models.VirtualEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;


namespace PlatDiplom.Models
{
    public class PaymentsData
    {
        nemo_freshEntities db = new nemo_freshEntities();
        public int id_plat { get; set; }
        public string PurOfPayment { get; set; }
        public string applnumber { get; set; }
        public Nullable<double> sum { get; set; }
        public string OurCase { get; set; }
        public string TaxNum { get; set; }
         public Nullable<int> region_id { get; set; }
        public Nullable<int> currency_id { get; set; }
        public Nullable<int> User_id { get; set; }

        public string User { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public Nullable<System.DateTime> deadline { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public Nullable<System.DateTime> Paid { get; set; }
        public string File { get; set; }
        public Nullable<int> currency2_id { get; set; }

        public Nullable<int> Bank_id { get; set; }
        public Nullable<int> DNid { get; set; }

        public virtual About_banks About_banks { get; set; }
        public virtual Countries Countries { get; set; }
        public virtual Currencies Currencies { get; set; }
        public virtual Users Users { get; set; }
        public List<PaymentsData> GetPaymentsList(int? country_id,int? status_id)
        {

            List<PaymentsData> PaymentsList = new List<PaymentsData>();

            PaymentsList = db.PaymentsRU.Where(x => x.region_id == country_id)
                                        .Select(x => new PaymentsData()
                                        {
                                            id_plat = x.id_plat,
                                            PurOfPayment = x.PurOfPayment,
                                            applnumber = x.applnumber,
                                            sum = x.sum,
                                            OurCase = x.OurCase,
                                            TaxNum = x.TaxNum,
                                            region_id = x.region_id,
                                            currency_id = x.currency_id,
                                            User = x.Users.Username,
                                            deadline = x.deadline,
                                            Paid = x.Paid,
                                            File = x.File,
                                            currency2_id = x.currency2_id,
                                            Bank_id = x.Bank_id,
                                            DNid = x.DNid
                                        }).ToList();
            if (status_id == 1)
            {
                PaymentsList = PaymentsList.Where(x => x.Paid != null).ToList();
            }else if(status_id == 0)
            {
                PaymentsList = PaymentsList.Where(x => x.Paid == null).ToList();
            }

            return PaymentsList.ToList();

        }

    }
}