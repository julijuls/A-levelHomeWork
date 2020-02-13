using PlatDiplom.Models;
using PlatDiplom.Models.PlatModel;
using PlatDiplom.Services;
using System;

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace PlatDiplom.Controllers
{
    public class PlatController : Controller
    {
        private nemo_freshEntities db;
        private PaymentManager manager;


        public PlatController()
        {
            db = new nemo_freshEntities();
            manager= new PaymentManager(db);

        }
    
        public ActionResult SearchAllPAFirm(Filterplat filter)
        {
           //if (filter == null)
           // {
                filter.Country = 175;
                filter.Status = 1;
           // }
           

            JsonResult result = new JsonResult();
           // try
           // {
                string draw = Request.Form.GetValues("draw")[0];
                string order = Request.Form.GetValues("order[0][column]")[0];
                string orderDir = Request.Form.GetValues("order[0][dir]")[0];
                int startRec = Convert.ToInt32(Request.Form.GetValues("start")[0]);
                int pageSize = Convert.ToInt32(Request.Form.GetValues("length")[0]);
                int totalRecords;

                List<PaymentsData> data = manager.GetAllPAFirms(filter, startRec, pageSize, order, orderDir, out totalRecords);

                int recFilter = totalRecords;
                result = this.Json(new
                {
                    draw = Convert.ToInt32(draw),
                    recordsTotal = totalRecords,
                    recordsFiltered = recFilter,
                    data = data
                }, JsonRequestBehavior.AllowGet);
            //}
            //catch (Exception ex)
            //{
            //    result = Json(System.Web.HttpException.CreateFromLastError("Не удалось загрузить данные из БД. Обламался запрос."),JsonRequestBehavior.AllowGet);
            //}
            return result;
        }



    }
}