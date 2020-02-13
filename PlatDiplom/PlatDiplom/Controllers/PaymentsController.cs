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

        private IPlatManeger repository;
        public PaymentsController()
        {
            this.repository = new PlatManager(new nemo_freshEntities());
        }
        public PaymentsController(IPlatManeger repository)
        {
            this.repository = repository;
        }
        private nemo_freshEntities db = new nemo_freshEntities();
        public ActionResult Index(Filterplat filter, int page = 1)
        {
            int pageSize = 10;

            Filterplat filterview = new Filterplat
            {
                Country = filter.Country,
                Status = filter.Status,
                CountriesList = repository.GetCountries(filter.Country),
                StatusList = repository.GetStatus(filter.Status),
                sortOrder = filter.sortOrder
            };

            IEnumerable<PaymentsData> res = repository.GetPaymentsList(filter).ToList();

            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = res.Count() };
            res = res.Skip((page - 1) * pageSize).Take(pageSize);

            PaymentsView ivm = new PaymentsView { PaymentsList = res, PageInfo = pageInfo, FilterPlat = filterview };
            return View(ivm);

        }
        [HttpPost]
        public ActionResult ShowPlat(List<PlatType> ClientList)
        {
           var platList = repository.PaymentCollection(ClientList);
           return PartialView("/Views/Payments/Partial/ShowPlats.cshtml", platList);
        }
        public ActionResult Create()
        {
            ViewBag.region_id = repository.GetCountries(175);
            ViewBag.currency_id = repository.GetCurrencies(1);
            ViewBag.user_id = repository.GetUsers(331);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PaymentsRU payments)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.Create(payments);
                    repository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ViewBag.region_id = repository.GetCountries(payments.region_id);
                ViewBag.currency_id = repository.GetCurrencies(payments.currency_id);
                ViewBag.user_id = repository.GetUsers(payments.User_id);
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");

            }
            return View(payments);

        }
        public ActionResult Edit(int id)
        {

            PaymentsRU paymentsRU = repository.GetPaymentByID(id);
            if (paymentsRU == null)
            {
                return HttpNotFound();
            }
            ViewBag.region_id = repository.GetCountries(paymentsRU.region_id);
            ViewBag.currency_id = repository.GetCurrencies(paymentsRU.currency_id);
            ViewBag.user_id = repository.GetUsers(paymentsRU.User_id);
            return View(paymentsRU);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PaymentsRU paymentsRU)
        {
            if (ModelState.IsValid)
            {
                repository.EditPayments(paymentsRU);
                repository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.region_id = repository.GetCountries(paymentsRU.region_id);
            ViewBag.currency_id = repository.GetCurrencies(paymentsRU.currency_id);
            ViewBag.user_id = repository.GetUsers(paymentsRU.User_id);
            return View(paymentsRU);
        }


    }
}
