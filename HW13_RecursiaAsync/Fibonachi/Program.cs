using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonachi
{
    class Program
    {
        

        static void Main(string[] args)
        {

            Console.WriteLine(" 1-calculate; 2-exit;");
            int answer = Convert.ToInt32(Console.ReadLine());
            while (answer == 1 || answer == 2)
            {
                switch (answer)
                {
                    case 1:

                        Console.WriteLine("Enter n");
                        int n = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"Fibonacci:{Recursia.Fibonachi(n)}");
                        Console.WriteLine($"Factorial:{Recursia.Factorial(n)}");
                        Console.ReadKey();
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
                Console.WriteLine(" 1-calculate; 2-exit;");
                answer = Convert.ToInt32(Console.ReadLine());
                Console.ReadKey();
            }



        }
    }
}
