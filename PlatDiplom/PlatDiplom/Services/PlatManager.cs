using PlatDiplom.Models;
using PlatDiplom.Models.PlatModel;
using PlatDiplom.Models.VirtualEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlatDiplom.Services
{
    public class PlatManager : IPlatManeger
    {

        private nemo_freshEntities db;

        public PlatManager(nemo_freshEntities db)
        {
            this.db = db;
        }
        public List<PaymentsData> GetPaymentsList(Filterplat filter)
        {

            List<PaymentsData> PaymentsList = new List<PaymentsData>();

            PaymentsList = db.PaymentsRU.Where(x => x.region_id == filter.Country)
                                        .Select(x => new PaymentsData()
                                        {
                                            id_plat = x.id_plat,
                                            PurOfPayment = x.PurOfPayment,
                                            sum = x.sum,
                                            OurCase = x.OurCase,
                                            region_id = x.region_id,
                                            currency_id = x.currency_id,
                                            currency = x.Currencies.currencycode,
                                            User = x.Users.Username,
                                            Paid = x.Paid,
                                            //FileObj =new FileOptions(x.File ?? ""),
                                            File=x.File,

                                            Bank_id = x.Bank_id

                                        }).ToList();
            if (filter.Status == 1)
            {
                PaymentsList = PaymentsList.Where(x => x.Paid != null).ToList();
            }
            else if (filter.Status == 0)
            {
                PaymentsList = PaymentsList.Where(x => x.Paid == null).ToList();
            }
            return PaymentsList.ToList();

        }
        public void Create(PaymentsRU payment)
        {
            db.PaymentsRU.Add(payment);
        }
        public PaymentsRU GetPaymentByID(int id)
        {
            return db.PaymentsRU.Find(id);
        }
        public void EditPayments(PaymentsRU payment)
        {
            db.Entry(payment).State = EntityState.Modified;
        }
        public PlatForDNView PaymentCollection(List<PlatType> ClientList)
        {
            var platList = new PlatForDNView
            {
                Payments = new List<PaymentsRU>(),
                SelectedSum = null,
                SelectedCurrency = null
            };
            foreach (var item in ClientList)
            {
                var localInventionsList = new List<PaymentsRU>();
                localInventionsList = db.PaymentsRU.Where(x => x.id_plat == item.Id).ToList();
                platList.Payments.AddRange(localInventionsList);

            }
            platList.Payments = platList.Payments.Distinct().OrderBy(x => x.id_plat).ToList();
            platList.SelectedSum = platList.Payments.Sum(x => x.sum).ToString();
            platList.SelectedCurrency = platList.Payments.Distinct().Select(x => x.Currencies.currencycode).FirstOrDefault();
            return platList;
        }
        public void MarkAsPaid(List<PlatType>  platList,string fullPathFile)
        {
            DateTime thisDay = DateTime.Now;
            foreach (var item in platList)
            {
                var PlatEdit = GetPaymentByID(item.Id);
                PlatEdit.Paid = thisDay;
                PlatEdit.File = fullPathFile;

            }
            Save();
        }
        public SelectList GetCountries(int? id = 94)
        {
            List<Countries> CountriesLst = db.Countries.Where(x =>
               x.id_country == 175
            || x.id_country == 144
            || x.id_country == 18
            || x.id_country == 178
            || x.id_country == 19
            || x.id_country == 65
            || x.id_country == 94
            || x.id_country == 216).ToList();
            SelectList countries = new SelectList(CountriesLst, "id_country", "Country_Eng", id);
            return countries;
        }
        public SelectList GetStatus(int? id = 0)
        {
            List<SelectListItem> StatusLst = new List<SelectListItem>
            {

                 new SelectListItem
                {
                    Selected = true,
                    Text = "NotPaid",
                    Value = "0"
                },
                new SelectListItem
                {
                    Text = "Paid",
                    Value = "1"
                },
                new SelectListItem
                {
                    Text = "All",
                    Value = "-1"
                }

            };
            SelectList Status = new SelectList(StatusLst, "Value", "Text", id);
            return Status;
        }
        public SelectList GetCurrencies(int? id = 1)
        {
            List<Currencies> CurrensiesLst = db.Currencies.Where(x =>
               x.id_currency == 1
            || x.id_currency == 2
            || x.id_currency ==3
            || x.id_currency == 4
            || x.id_currency == 8
            || x.id_currency == 13
                  ).ToList();
            SelectList currencies = new SelectList(CurrensiesLst, "id_currency", "currencycode", id);
            return currencies;
        }
        public SelectList GetUsers(int? id=331)
        {
            List<Users> UsersLst = db.Users.ToList();
            SelectList users = new SelectList(UsersLst, "id_User", "Username", id);
            return users;

        }
        public void Save()
        {
            db.SaveChanges();
        }

     
    }
}