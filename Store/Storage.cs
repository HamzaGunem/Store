using Store.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    internal class Storage()
    {
        public List<Product> productsInStorage { get; set; } = [];

        public void AddToStorage(Product product)
        {
            productsInStorage.Add(product);
        }
        public Product CheckIfProductAvailable(string isbn)
        {
            return productsInStorage.FirstOrDefault(p => p.ISBN == isbn);
        }
        public void ReduceStock(string isbn, int quantity)
        {
            var product = productsInStorage.FirstOrDefault(p => p.ISBN == isbn);
            if (product != null && product.Stock >= quantity)
            {
                product.Stock -= quantity;
            }
        }
        public void AddBackToStorage(string isbn, int quantity)
        {
            var product = productsInStorage.FirstOrDefault(p =>p.ISBN == isbn);
            if(product != null)
            {
                product.Stock += quantity;
            }
        }
    }
}
