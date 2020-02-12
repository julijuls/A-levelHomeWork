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
    [Authorize]
    public class PaymentsController : Controller
    {
        private nemo_freshEntities db = new nemo_freshEntities();
        public ActionResult Index(Filterplat filter, int page = 1)
        {
            int pageSize = 15;
               
            Filterplat filterview = new Filterplat
            {
                Country = filter.Country,
                Status = filter.Status,
                CountriesList = new PlatManager().GetCountries(filter.Country),
                StatusList = new PlatManager().GetStatus(filter.Status),
                sortOrder=filter.sortOrder
            };

            IEnumerable<PaymentsData> res = new PlatManager().GetPaymentsList(filter).ToList();

            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = res.Count() };
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
            ViewBag.region_id = new PlatManager().GetCountries();
            ViewBag.currency_id = new PlatManager().GetCurrencies();
            ViewBag.user_id = new PlatManager().GetUsers();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PaymentsRU paymentsRU)
        {
            if (ModelState.IsValid)
            {
                db.PaymentsRU.Add(paymentsRU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.region_id = new PlatManager().GetCountries(paymentsRU.region_id);
            ViewBag.currency_id = new PlatManager().GetCurrencies(paymentsRU.currency_id);
           // ViewBag.User_id = new SelectList(db.Users, "id_User", "Username", paymentsRU.User_id);
            ViewBag.user_id = new PlatManager().GetUsers(paymentsRU.User_id);
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
            ViewBag.region_id = new PlatManager().GetCountries(paymentsRU.region_id);
            ViewBag.currency_id = new PlatManager().GetCurrencies(paymentsRU.currency_id);
            ViewBag.user_id = new PlatManager().GetUsers(paymentsRU.User_id);
            return View(paymentsRU);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PaymentsRU paymentsRU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentsRU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.region_id = new PlatManager().GetCountries(paymentsRU.region_id);
            ViewBag.currency_id = new PlatManager().GetCurrencies(paymentsRU.currency_id);
            ViewBag.user_id = new PlatManager().GetUsers(paymentsRU.User_id);
            return View(paymentsRU);
        }


    }
}
