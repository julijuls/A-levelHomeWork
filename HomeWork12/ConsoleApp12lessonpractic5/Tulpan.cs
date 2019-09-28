using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12lessonpractic5
{
    class Tulpan:Flowers
    {
        private static string name = "Tulpan";
        public static int TulpanPrice = 15;
        public Tulpan(int quantity) : base(name, quantity)
        {
            Price = TulpanPrice;
        }
    }
}
