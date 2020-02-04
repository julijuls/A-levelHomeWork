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
        public string currency { get; set; }
        public Nullable<int> User_id { get; set; }

        public string User { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public Nullable<System.DateTime> deadline { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public Nullable<System.DateTime> Paid { get; set; }
        public string File { get; set; }
        public Nullable<int> currency2_id { get; set; }
        public string currency2 { get; set; }

        public Nullable<int> Bank_id { get; set; }
        public Nullable<int> DNid { get; set; }

        public virtual About_banks About_banks { get; set; }
        public virtual Countries Countries { get; set; }
        public virtual Currencies Currencies { get; set; }
        public virtual Users Users { get; set; }
        public List<PaymentsData> GetPaymentsList(Filterplat filter)
        {

            List<PaymentsData> PaymentsList = new List<PaymentsData>();

            PaymentsList = db.PaymentsRU.Where(x => x.region_id == filter.Country)
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
                                            currency = x.Currencies.currencycode,
                                            User = x.Users.Username,
                                            deadline = x.deadline,
                                            Paid = x.Paid,
                                            File = x.File,
                                            currency2_id = x.currency2_id,
                                            currency2 = x.Currencies.currencycode,
                                            Bank_id = x.Bank_id,
                                            DNid = x.DNid
                                        }).ToList();
            if (filter.Status == 1)
            {
                PaymentsList = PaymentsList.Where(x => x.Paid != null).ToList();
            }
            else if (filter.Status == 0)
            {
                PaymentsList = PaymentsList.Where(x => x.Paid == null).ToList();
            }

            switch (filter.sortOrder)
            {
                case "PurOfPayment_desc":
                    PaymentsList = PaymentsList.OrderByDescending(s => s.PurOfPayment).ToList();
                    break;
                case "Sum":
                    PaymentsList = PaymentsList.OrderBy(s => s.sum).ToList();
                    break;
                case "Sum_desc":
                    PaymentsList = PaymentsList.OrderByDescending(s => s.sum).ToList();
                    break;
                case "Paid":
                    PaymentsList = PaymentsList.OrderBy(s => s.Paid).ToList();
                    break;
                case "Paid_desc":
                    PaymentsList = PaymentsList.OrderByDescending(s => s.Paid).ToList();
                    break;
                case "File":
                    PaymentsList = PaymentsList.OrderBy(s => s.File).ToList();
                    break;
                case "File_desc":
                    PaymentsList = PaymentsList.OrderByDescending(s => s.File).ToList();
                    break;
                default:
                    PaymentsList = PaymentsList.OrderByDescending(s => s.id_plat).ToList();
                    break;
            }


            return PaymentsList.ToList();

        }

    }
}