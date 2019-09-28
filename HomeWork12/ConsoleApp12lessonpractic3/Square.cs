using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12lessonpractic3
{
    public class Square :Rectangle
    {
    
        public Square(double a, double b) : base( a,  b)
        {
      
        }

        public override double GetArea()
        {
            return A* A ;
        }
        public override double GetPerimetr()
        {
            return 4*A  ;
        }
    

    }
}
