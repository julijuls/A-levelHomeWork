using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp12lessonpractic5
{
    class Program
    {
        static void Main(string[] args)
        {
              Flowers[] newBouquet = new Flowers[3]
            {
                new Rose(20),
                new Tulpan(18),
                new Gvozdika(9)
            };


            Buqet bouquet = new Buqet();
            foreach (var flowers in newBouquet)
            {
                bouquet.AddFlowers(flowers);
            }

            int totalPrice = bouquet.GetPrice();

            Console.WriteLine($"Buquet price: {totalPrice} .");

            var flowersBouquet = bouquet.GetFlowers();

            foreach (var flowers in flowersBouquet)
            {
                Console.WriteLine(flowers.Name+" "+flowers.Quantity+" "+flowers.Price+"UAH");
               // Console.WriteLine( flowers.Quantity);
            }

            Console.ReadLine();
        }
    }
}
