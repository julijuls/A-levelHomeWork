using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_Sklad
{
   public class BaseProduct 
    {

        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime DeliveryDate { get; set; }

        public BaseProduct(string name, double price, DateTime deliverydate)
        {
            this.Name = name;
            this.Price = price;
            this.DeliveryDate = deliverydate;
        }

   
        

    }
}
