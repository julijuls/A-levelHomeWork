using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_Sklad;

namespace ClassLibrary_Sklad
{
   public class ProductManage
    {
        public static List<Product> _productList;

        public ProductManage()
        {

            _productList = new List<Product>();

            DateTime DateProduct = new DateTime(2019, 09, 05);

            _productList.Add(new Product("sand", 12.3, DateProduct, 2));
            _productList.Add(new Product("wire", 20.5, DateProduct, 5));
            _productList.Add(new Product("milk", 11.4, DateProduct, 1));
            _productList.Add(new Product("honey", 27.5, DateProduct, 8));

        }
        public static Product[] ViewProductsList
        {
            get
            {
                return _productList.ToArray();

            }
        }
    }
}
 