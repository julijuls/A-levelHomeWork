using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PlatDiplom.Models;
using PlatDiplom.Models.Pagination;
using PlatDiplom.Models.PlatModel;
using PlatDiplom.Services;

namespace PlatDiplom.Controllers
{
    public class PaymentsController : Controller
    {
        private nemo_freshEntities db = new nemo_freshEntities();

  
        public ActionResult Index(Filterplat filter, int page = 1)
        {
            int pageSize = 15;
            PageInfo pageInfo;

            ViewBag.Countries = new PlatManager().GetCountries(filter.SelectedCountry);
            ViewBag.Status = new PlatManager().GetStatus(filter.SelectedStatus);

            Filterplat filterview = new Filterplat
            {
                SelectedCountry = filter.SelectedCountry,
                SelectedStatus = filter.SelectedStatus,
                CountriesList = new PlatManager().GetCountries(filter.SelectedCountry),
                StatusList = new PlatManager().GetStatus(filter.SelectedStatus)
            };

            IEnumerable<PaymentsData> res = new PaymentsData().GetPaymentsList(filter.SelectedCountry, filter.SelectedStatus).ToList();

            pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = res.Count() };
            res = res.Skip((page - 1) * pageSize).Take(pageSize);

            PaymentsView ivm = new PaymentsView { PaymentsList = res, PageInfo = pageInfo, FilterPlat= filterview };
            return View(ivm);


        }

        [HttpPost]

        public ActionResult ShowPlat(List<PlatType> ClientList)
        {
            var platList = new PlatForDNView
            {
                Payments = new List<PaymentsRU>(),
                SelectedSum = null,
                SelectedCurrency=null
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
            return PartialView("/Views/Payments/Partial/ShowPlats.cshtml", platList);
        }


        public ActionResult Create()
        {
            ViewBag.Bank_id = new SelectList(db.About_banks, "Bank_ID", "Name");
            ViewBag.region_id = new SelectList(db.Countries, "id_country", "Country_Eng");
            ViewBag.currency_id = new SelectList(db.Currencies, "id_currency", "currencycode");
            ViewBag.User_id = new SelectList(db.Users, "id_User", "Username");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_plat,PurOfPayment,applnumber,sum,OurCase,TaxNum,Comment,region_id,Sum_for_reg,currency_id,User_id,ts,old_plat_num,deadline,Paid,File,currency2_id,Act,Pay,DateAct,SumAct,ASAP,DateStamp,SumbyAct,Buh_id,TaxCodeUA,OwnCountryCode,CountryinUA,Bank_id,TaxOrder,Writtenoff,Invoice,Remainder,DNid")] PaymentsRU paymentsRU)
        {
            if (ModelState.IsValid)
            {
                db.PaymentsRU.Add(paymentsRU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bank_id = new SelectList(db.About_banks, "Bank_ID", "Name", paymentsRU.Bank_id);
            ViewBag.region_id = new SelectList(db.Countries, "id_country", "Country_Eng", paymentsRU.region_id);
            ViewBag.currency_id = new SelectList(db.Currencies, "id_currency", "currencycode", paymentsRU.currency_id);
            ViewBag.User_id = new SelectList(db.Users, "id_User", "Username", paymentsRU.User_id);
            return View(paymentsRU);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentsRU paymentsRU = db.PaymentsRU.Find(id);
            if (paymentsRU == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bank_id = new SelectList(db.About_banks, "Bank_ID", "Name", paymentsRU.Bank_id);
            ViewBag.region_id = new SelectList(db.Countries, "id_country", "Country_Eng", paymentsRU.region_id);
            ViewBag.currency_id = new SelectList(db.Currencies, "id_currency", "currencycode", paymentsRU.currency_id);
            ViewBag.User_id = new SelectList(db.Users, "id_User", "Username", paymentsRU.User_id);
            return View(paymentsRU);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_plat,PurOfPayment,applnumber,sum,OurCase,TaxNum,Comment,region_id,Sum_for_reg,currency_id,User_id,ts,old_plat_num,deadline,Paid,File,currency2_id,Act,Pay,DateAct,SumAct,ASAP,DateStamp,SumbyAct,Buh_id,TaxCodeUA,OwnCountryCode,CountryinUA,Bank_id,TaxOrder,Writtenoff,Invoice,Remainder,DNid")] PaymentsRU paymentsRU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentsRU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Bank_id = new SelectList(db.About_banks, "Bank_ID", "Name", paymentsRU.Bank_id);
            ViewBag.region_id = new SelectList(db.Countries, "id_country", "Country_Eng", paymentsRU.region_id);
            ViewBag.currency_id = new SelectList(db.Currencies, "id_currency", "currencycode", paymentsRU.currency_id);
            ViewBag.User_id = new SelectList(db.Users, "id_User", "Username", paymentsRU.User_id);
            return View(paymentsRU);
        }


    }
}
