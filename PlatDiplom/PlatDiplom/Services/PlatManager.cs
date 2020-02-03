using PlatDiplom.Models.PlatModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlatDiplom.Services
{
    public class PlatManager : IPlatManeger
    {
        private nemo_freshEntities db = new nemo_freshEntities();
        public  SelectList GetCountries(int? id)
        {
            List<Countries> CountriesLst = db.Countries.Where(x => x.id_country == 175 || x.id_country == 144 || x.id_country == 18 || x.id_country == 178).ToList();
            SelectList countries = new SelectList(CountriesLst, "id_country", "Country_Rus", id);
            return countries;
        }

        public SelectList GetStatus(int? id)
        {
            List<SelectListItem> StatusLst = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Paid",
                    Value = "1"
                },
                new SelectListItem
                {
                    Selected = true,
                    Text = "NotPaid",
                    Value = "0"
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
    }
}