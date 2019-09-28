using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12lessonpracctic1
{
   public  struct Point
    {
        public int X;
        public int Y;
       
    }
    public class Trapecia :Figura
    {

        public Point A;
        public Point B;
        public Point C;
        public Point D;
        public Trapecia(Point a,Point b,Point c,Point d)
        {
            this.A= a;
            this.B = b;
            this.C = c;
            this.D = d;



        }

       
        public  bool isTrapRavn(Point a, Point b, Point c, Point d)
        {

            return (GetDistance(a, b) == GetDistance(c, d));
        }
        public  double GetPerimetr(Point a, Point b, Point c, Point d)
        {

            double A = GetDistance(a,b);
            double B = GetDistance(b,c);
            double C = GetDistance(c,d);
            double D = GetDistance(d,c);
            return A + B + C + D;

        }
        public double GetArea(Point a, Point b, Point c, Point d)
         {
            return (GetDistance(b, c) + GetDistance(a, d)) *0.5*( b.Y- a.Y);
         }


    }




}
