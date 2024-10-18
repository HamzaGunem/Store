using Store.Menu;
using Store.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    internal class Manager
    {
        public Storage storage;
        public Cart cart;

        public Manager(Storage storage, Cart cart)
        {
            this.storage = storage;
            this.cart = cart;
        }

        public void AddProductToCart(string isbn, int quantity)
        {
            var product = storage.CheckIfProductAvailable(isbn);
            if (product != null && product.Stock >= quantity)
            {
                storage.ReduceStock(isbn, quantity);
                cart.AddProduct(product, quantity);
            }
            else if (product == null)
            {
                Console.WriteLine("Cant find product with this ISBN number");
            }
            else
            {
                Console.WriteLine("No enough stock available");
            }
        }

        public void RemoveFromCart(string isbn, int quantity)
        {
            cart.RemoveProduct(isbn, quantity);
            storage.AddBackToStorage(isbn, quantity);
        }

        public List<T> GetProductsOfType<T>() where T : Product
        {
            var listedProducts = storage.productsInStorage.OfType<T>().ToList();
            if (listedProducts.Any())
            {
                return listedProducts;
            }
            return null;
        }
    }
}
