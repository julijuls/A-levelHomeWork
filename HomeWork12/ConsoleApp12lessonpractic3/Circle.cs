using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12lessonpractic3
{
    public struct Point
    {
        public int X;
        public int Y;

    }
    public class Circle:Figura
    {
        protected double Radius1;
        protected Point CenterCircle;


        public Circle(double radius1, Point centercircle)
        {
            this.Radius1 = radius1;
            this.CenterCircle = centercircle;

        }

        public override double GetArea()
        {

            return Math.PI * Math.Pow(Radius1, 2); ;
        }
        public override double GetPerimetr()
        {
            return Math.PI * 2 * Radius1;
        }
     
    }
}
