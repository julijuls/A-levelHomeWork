using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12lessonpractic2
{
    class Program
    {
        static void Main(string[] args)
        {
            Point Center1 = new Point { X = 0, Y = 0 };
            Point Center2 = new Point { X = 3, Y = 5 };
            Point Center3 = new Point { X = 3, Y = 5 };
            double R1 = 13;
            double R2 = 11;
            double R3 = 11;


            Circle circle1 = new Circle(R1, Center1);
            Circle circle2 = new Circle(R2, Center2);
            Circle circle3 = new Circle(R3, Center3);

            Console.WriteLine("Default Circles");
            bool result =circle1 == circle2;
            Console.WriteLine("Compare with overload=" + result);
            Console.WriteLine("Compare with function(isAreaofCircleEqual)=" + circle1.isAreaofCircleEqual(R1,R2));

            Console.WriteLine("Similar Circles ");
            bool result2 = circle2 == circle3;
            Console.WriteLine("Compare with overload=" + result2);
            Console.WriteLine("Compare with function(isAreaofCircleEqual)=" + circle1.isAreaofCircleEqual(R2, R3));


            Console.ReadKey();
        }
    }
}
