using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulePL.PostModels
{
    public class PaymentPost
    {
    

        //public PaymentPost(DateTime p1, int p2)
        //{
        //    this.Date = p1;
        //    this.Value = p2;
        //}

        public DateTime? Date { get; set; }
        public int Value { get; set; }
  

    }
}
