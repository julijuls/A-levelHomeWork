using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1lessonpractic4
{
    class ManageDb
    {
        private List<Product> productlist = new ArrayList<Product>();

        public void Addproduct(Product product)
        {
            productlist.Add(product);
        }

        public List<Product> GetProduct()
        {
            List<Product> tempProduct = productlist;
            return tempProduct;
        }

        private class ArrayList<T> : List<Product> { }
    }
}
