using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulePL.ViewModels
{
    public class AddModelStud
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public int? Age { get; set; }
        public IEnumerable<PaymentViewModel> Payments { get; set; }
    }
}
