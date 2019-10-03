using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork16Collections
{
    class Program
    {

 
        static void Main(string[] args)
        {
            cars Cars = new cars();
            Console.WriteLine("foreach");

            foreach (Car c in Cars)
            Console.WriteLine(c.Model + "\t" + c.Colour + "\t" +c.Engine);
            Console.WriteLine("IEnumerable yield");

            foreach (Car c in Cars.GetCars(5))
            {
                Console.WriteLine(c.Model + "\t" + c.Colour + "\t" + c.Engine);
            }
            Console.WriteLine("List<T>");
            cars.IterateCarsList();
            Console.ReadLine();
        }
    }
}
