using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12lessonpractic5
{
   public  class Flowers
    {

        public int Price { get; protected set; }

        public int Quantity { get; }

        public string Name { get; }

        protected Flowers(string name, int quantity)
        {
            Quantity = quantity;
            Name = name;
        }
    }
}
