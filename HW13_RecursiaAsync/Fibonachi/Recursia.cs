using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonachi
{
    class Recursia
    {
      public  static ulong Fibonachi(int n)
        {
            ulong a = 0;
            ulong b = 1;
            ulong tmp;

            for (ulong i = 0; i < (ulong)n; i++)
            {
                tmp = a;
                a = b;
                b += tmp;
            }

            return a;
        }
        public static ulong Factorial(int x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return (ulong)x * Factorial(x - 1);
            }

      
        }

    }
}
