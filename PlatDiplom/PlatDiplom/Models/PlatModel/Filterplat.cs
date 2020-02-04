using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlatDiplom.Models.PlatModel
{
    public class Filterplat
    {
        public int? SelectedCountry { get; set; }
        public int? SelectedStatus { get; set; }
        public IEnumerable<SelectListItem> CountriesList { get; set; }
        public IEnumerable<SelectListItem> StatusList { get; set; }
        public string sortOrder { get; set; }
    }
}