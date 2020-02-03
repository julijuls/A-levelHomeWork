using PlatDiplom.Models.Pagination;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlatDiplom.Models.Pagination;
using PlatDiplom.Models.PlatModel;

namespace PlatDiplom.Models.PlatModel
{
    public class PaymentsView
    {
        public IEnumerable<PaymentsData> PaymentsList { get; set; }
        public PageInfo PageInfo { get; set; }
        public Filterplat FilterPlat { get; set; }
    }
}