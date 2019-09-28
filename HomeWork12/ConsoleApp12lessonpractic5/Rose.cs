using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12lessonpractic5
{
    class Rose:Flowers
    {
        private static string name = "Rose";
        public static int RosePrice=20;
        public Rose(int quantity) : base(name, quantity)
        {
            Price = RosePrice;
        }

    }
}
