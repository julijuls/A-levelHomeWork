using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12lessonpractic2
{
        public struct Point
    {
        public int X;
        public int Y;

    }
    public class Circle
    {
        private double Radius;
        private Point CenterCircle;
        

        public Circle(double radius,Point centercircle)
        {
            //if (radius > 0)
            //{
            //    this.CenterCircle = centercircle;
            //}
            //else
            //{
            //    Console.WriteLine("radius cannot be negative");
            //};
            if(radius<0)
            {
                throw new ArgumentNullException(nameof(radius));
            }
       
            this.Radius = radius;
           
        }

        public bool isAreaofCircleEqual(double R1,double R2)
        {
            return Math.PI * Math.Pow(R1, 2) == Math.PI * Math.Pow(R2, 2);

        }
        static public bool operator ==(Circle c1, Circle c2)
        {
            if (c1.Radius == c2.Radius && c1.CenterCircle.X == c2.CenterCircle.X && c1.CenterCircle.Y == c2.CenterCircle.Y)
                return true;
            return false;
        
        }
        static public bool operator !=(Circle c1, Circle c2)
        {
            if (!(c1.Radius == c2.Radius && c1.CenterCircle.X == c2.CenterCircle.X && c1.CenterCircle.Y == c2.CenterCircle.Y))
                return true;
            return false;

        }


    }
}
