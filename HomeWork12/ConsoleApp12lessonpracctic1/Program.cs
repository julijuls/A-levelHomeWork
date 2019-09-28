using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12lessonpracctic1
{
    class Program
    {
        static void Main(string[] args)
        {
            Point A = new Point { X=0, Y=0};
            Point B = new Point { X = 1, Y = 1 };
            Point C = new Point { X = 2, Y = 1 };
            Point D = new Point { X = 3, Y = 0 };
 

            Trapecia t = new Trapecia(A,B,C,D);
           // Console.WriteLine( t.GetDistance(A,B));
            Console.WriteLine(t.GetArea(A, B, C, D));
            Console.WriteLine(t.GetPerimetr(A, B, C, D));
            Console.WriteLine(t.isTrapRavn(A, B, C, D));

            Console.ReadKey();
         
            



        }
    }
}
