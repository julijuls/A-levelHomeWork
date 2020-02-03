using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlatDiplom.Models.PlatModel
{
    public class PlatForDNView
    {
        public List<PaymentsRU> Payments {get; set;}
        public string SelectedSum { get; set; }
    }
}