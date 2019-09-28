using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12lessonpractic5
{
  public  class Buqet
    {
        private int price;

        private List<Flowers> flowers = new ArrayList<Flowers>();

        public int GetPrice()
        {
            foreach (Flowers flower in flowers)
            {
                price += flower.Price * flower.Quantity;
            }
            return price;
        }

        public void AddFlowers(Flowers flower)
        {
            flowers.Add(flower);
        }

        public List<Flowers> GetFlowers()
        {
            List<Flowers> tempFlowers =flowers;
            return tempFlowers;
        }

        private class ArrayList<T> : List<Flowers>  {}
    }
}
