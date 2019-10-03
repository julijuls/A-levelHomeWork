using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork16Collections
{
    public class cars : IEnumerator, IEnumerable
    {
        private List<Car> carlist;
        int position = -1;        
        public cars()
        {
            carlist = new List<Car>      
                    {
                        new Car("Porsh","red","MDC.AB"),
                        new Car("Lexus","grey","CT200h"),
                        new Car("Audi","white","DDVB"),
                        new Car("Tayota","red","22R"),
                        new Car("Honda","blue","OM628/OM629")

                    };

        }  
        public static void IterateCarsList()
        {
            var theCars = new List<Car>
                {

                        new Car("Porsh","red","MDC.AB"),
                        new Car("Lexus","grey","CT200h"),
                        new Car("Audi","white","DDVB"),
                        new Car("Tayota","red","22R"),
                        new Car("Honda","blue","OM628/OM629")


                };


            foreach ( Car theCar in theCars)
            {
                Console.WriteLine(theCar.Model+" "+theCar.Colour+" "+theCar.Engine);

            }
        }


        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
        public int Count
        {
            get { return carlist.Count(); }
        }
        public bool MoveNext()
        {
            position++;
            return (position < carlist.Count);
        }         
        public void Reset()
        {
            position = 0;
        }
        public IEnumerable GetCars(int max)
        {
            for (int i = 0; i < max; i++)
            {
                if (i == carlist.Count)
                {
                    yield break;
                }
                else
                {
                    yield return carlist[i];
                }
            }
        }
        public object Current
        {
            get
            {
                return carlist[position];
            }
        }
    }
}
