using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_Sklad
{
    // Название Цена Базовый товар - базовый товар несет в себе срок годности с момента поставки (по истечению - списание).
    public class Product : BaseProduct
    {
    

        public int ExpirationDays { get; set; }
        public string StatusProduct = "годен";
        public Product(string name, double price, DateTime deliverydate, int experationdays) : base(name, price, deliverydate)
        {
            this.ExpirationDays = experationdays;
            this.StatusProduct = statusproduct;

        }

        public string statusproduct
        {

            get
            {
                StatusProduct = GetStatus(DeliveryDate);
                return StatusProduct;
            }
        

         
        }
        public string GetStatus(DateTime DeliveryDate)
        {
            DateTime Delaydate = new DateTime();
            Delaydate = DeliveryDate.AddDays(ExpirationDays);
            if ( DateTime.Now> Delaydate )
            {
                StatusProduct = "списан";
            }
            else
            {
                StatusProduct = "годен";
            }
           
            return StatusProduct;
        }
        public DateTime GetDelayDate(DateTime DeliveryDate)
        {
            DateTime Delaydate = new DateTime();
            Delaydate = DeliveryDate.AddDays(ExpirationDays);
            return Delaydate;
        }




    }
}
