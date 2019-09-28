using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3FizzBazz
{
    class FizzBuzz
    {
       public static void GetMassFizzBazz(int a, int b, int c, int d)
        {
           
            string result = "";
            string resultS = "";
            for (int i = a; i < b; i++)
            {
                resultS = i.ToString();
                if (i % c == 0) { resultS = "Fizz"; }
                if (i % d == 0) { resultS = "Buzz"; }
                if (i % c == 0 && i % d == 0) { resultS = "FizzBuzz"; }
                result = result + " " + resultS;
                Console.Write(resultS);
            }
            Console.WriteLine(Environment.NewLine);

            Thread.Sleep(2000);//tupit 2 sec

            if (!File.Exists(@"FizzBuzz.txt"))

            {
                File.Create(@"FizzBuzz.txt");

            }

            string totext = "";
            foreach (var item in result)

            {
                totext += item;

            }
            File.WriteAllText(@"FizzBuzz.txt", totext);
            Console.WriteLine("List write to file FizzBuzz.TXT");
           
        }
        public static async void FizzBuzzAsync()
        {
            Console.WriteLine("start GetMassFizzBazz"); // sync
            await Task.Run(() => GetMassFizzBazz(1,100,3,5)); //async
            Console.WriteLine("end GetMassFizzBazz");  // sync
        }

 
    }
}
