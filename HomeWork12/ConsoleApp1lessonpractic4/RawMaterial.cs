using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1lessonpractic4
{
    class RawMaterial:Product
    {

        
        private static string name = "RawMaterial";
        public int Size { get; set;}

        public RawMaterial():base(name)
        {
            Name = name;
        }

    }
}
