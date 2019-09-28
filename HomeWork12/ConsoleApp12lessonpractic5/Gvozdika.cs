using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12lessonpractic5
{
    class Gvozdika:Flowers
    {
        private static string name = "Gvozdika";
        public static int GvozdPrice = 10;
        public Gvozdika(int quantity) : base(name, quantity)
        {
            Price = GvozdPrice;
        }
    }
}
