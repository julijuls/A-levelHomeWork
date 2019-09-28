using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1lessonpractic4
{
   public class Product
    {
        public string Name { get; set; }
    
        protected Product(string name)
        {
            Name = name;
        }
    }
}
