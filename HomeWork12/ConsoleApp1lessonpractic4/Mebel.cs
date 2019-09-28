using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1lessonpractic4
{
    class Mebel:Product
    {
        private static string name = "Mebel";
        public string Manufacturer { get; set;}
        public Mebel() : base(name)
        {
            Name = name;
        }
    }
}
