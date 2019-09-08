using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_Sklad;


namespace HW9_OOP_Sklad
{
   public class Program
    {
        static void Main(string[] args)
        {
            
            ProductManage carList = new ProductManage();
            Console.Write(string.Format("{{0, -{0}}}|", 10),"Product");
            Console.Write(string.Format("{{0, -{0}}}|", 5), "Price");
            Console.Write(string.Format("{{0, -{0}}}|", 20), "DeliveryDate");
            Console.Write(string.Format("{{0, -{0}}}|", 20), "Days");
            Console.Write(string.Format("{{0, -{0}}}|", 20), "DelayDate");
            Console.Write(string.Format("{{0, -{0}}}|", 20), "Status");
            Console.WriteLine();
            foreach (Product s in ProductManage.ViewProductsList)
            {
                Console.Write(string.Format("{{0, -{0}}}|", 10),s.Name);
                Console.Write(string.Format("{{0, -{0}}}|", 5), s.Price);
                Console.Write(string.Format("{{0, -{0}}}|", 20), s.DeliveryDate);
                Console.Write(string.Format("{{0, -{0}}}|", 20), s.ExpirationDays);
                Console.Write(string.Format("{{0, -{0}}}|", 20), s.GetDelayDate(s.DeliveryDate));
                Console.Write(string.Format("{{0, -{0}}}|", 20), s.StatusProduct);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
