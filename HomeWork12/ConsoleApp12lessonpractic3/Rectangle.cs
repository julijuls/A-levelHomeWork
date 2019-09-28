using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12lessonpractic3
{
   public  class Rectangle:Figura
    {
      protected  double A;
        double B;
   

        public Rectangle(double a, double b)
        {
            this.A = a;
            this.B = b;
        
        }
        public override double GetArea()
        {
            return A*B;
        }
        public override double GetPerimetr()
        {
            return 2*(A +B);
        }
  
    }
}
