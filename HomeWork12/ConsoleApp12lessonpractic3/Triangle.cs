using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12lessonpractic3
{
    class Triangle
    {
        double A;
        double B;
        double C;
       
        public Triangle(double a, double b, double c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
           
        }
        public double GetArea()
        {
            double tan = A / B;
            return tan/4*((Math.Pow(B,2)+Math.Pow(C,2)-Math.Pow(A,2)));
        }
        public double GetPerimetr()
        {
            return A + B + C;
        }
      
    }
}
