using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp12lessonpractic3;

namespace ConsoleApp12lessonpractic3
{
    public class Elipsis : Circle 
    {
        double Radius2;

        public Elipsis(double radius1,Point center ,double radius2): base( radius1, center)
        {
            this.Radius2 = radius2;
        }
        public override double GetArea()
        {
          
            return Math.PI * Radius1 * Radius2;
        }
        public override double GetPerimetr()
        {
            return 4*(Math.PI* Radius1* Radius2 + (Radius1 - Radius2))/(Radius1 + Radius2);
        }
       
    }


}
