using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12lessonpracctic1
{
    public abstract class Figura
    {


        protected  double GetDistance(Point a, Point b)
        {

            return Math.Sqrt((Math.Pow((b.X - a.X), 2) + Math.Pow((b.Y - a.Y), 2)));

        }
        //public abstract double GetPerimetr();
        //public abstract double GetArea();
     


    }
}
