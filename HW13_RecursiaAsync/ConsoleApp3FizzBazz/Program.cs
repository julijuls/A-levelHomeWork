using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3FizzBazz
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            FizzBuzz.FizzBuzzAsync();
           
            watch.Stop();
            Console.WriteLine(watch.Elapsed.ToString());
        
            Console.ReadKey();

        }
    }
}
