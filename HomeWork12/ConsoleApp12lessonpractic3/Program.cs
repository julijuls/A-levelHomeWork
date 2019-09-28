using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12lessonpractic3
{
    class Program
    {
        static void Main(string[] args)
        {
            Point Center1 = new Point { X = 0, Y = 0 };
            Point Center2 = new Point { X = 3, Y = 5 };
    
            double R1 = 13;
            double R2 = 11;

            int A = 4;
            int B = 4;
            int C = 3;
           

            Square square = new Square(A,B);
            Console.WriteLine(" Square Perimetr="+square.GetPerimetr());
            Console.WriteLine("Square Area=" + square.GetArea());

            Rectangle rectangle = new Rectangle(A, B);
            Console.WriteLine("Rectangle Perimetr=" + rectangle.GetPerimetr());
            Console.WriteLine("Rectangle Area=" + rectangle.GetArea());

            Triangle triangle = new Triangle(A, B,C);
            Console.WriteLine("Triangle Perimetr=" + triangle.GetPerimetr());
            Console.WriteLine("Triangle Area=" + triangle.GetArea());

            Circle circle = new Circle(R1,Center1);
            Console.WriteLine("Circle Perimetr=" + circle.GetPerimetr());
            Console.WriteLine("Circle Area=" + circle.GetArea());

            Elipsis elipsis = new Elipsis(R1, Center1,R2);
            Console.WriteLine("Elipsis Perimetr=" + circle.GetPerimetr());
            Console.WriteLine("Elipsis Area=" + circle.GetArea());

            Console.ReadKey();


        }
    }
}
