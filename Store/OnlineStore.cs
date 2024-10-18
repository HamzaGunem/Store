using Store.Menu;
using Store.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    internal class OnlineStore
    {
        private Storage storage = new Storage();
        private Cart cart = new Cart();
        private Manager manager;
        
        private BaseMenu startUpMenu;
        public bool IsRunning { get; private set; } = true;

        public OnlineStore()
        {
            manager = new Manager(storage, cart);
            SetUpTheStore();
            startUpMenu = new MainMenu(this);

        }
        public void Start()
        {
            startUpMenu.Display();
        }
        public void Exit()
        {
            IsRunning = false;
        }
        private void SetUpTheStore()
        {
            storage.AddToStorage(new Book("Book1", 30, "1", 340, 4));
            storage.AddToStorage(new Book("Book2", 45, "12", 210, 2));
            storage.AddToStorage(new Book("Book3", 24, "90", 190, 9));
            storage.AddToStorage(new EBook("EBook1", 55, "72", 340, 19));
            storage.AddToStorage(new EBook("EBook2", 15, "402", 210, 82));
            storage.AddToStorage(new EBook("EBook3", 320, "9123", 190, 1));
        }
        public void SearchProductByTitle(string title)
        {
            var product = storage.productsInStorage.FirstOrDefault(p => p.Title.ToLower() == title.ToLower());
            if (product != null)
            {
                Console.WriteLine($"{product.ToString()}");
            }
            else
            {
                Console.WriteLine("Couldnt find any product with this title");
            }
        }
        public void AddToCart(string isbn, int quantity)
        {
            manager.AddProductToCart(isbn, quantity);
        }
        public void RemoveFromCart(string isbn, int quantity)
        {
            manager.RemoveFromCart(isbn, quantity);
        }
        public bool ProductsInCart()
        {
            if (cart.ListIfProductsInCart())
            {
                return true;
            }
            return false;
        }
        public List<T> ListProductsOfType<T>() where T : Product
        {
            var listedProducts = manager.GetProductsOfType<T>();
            if (listedProducts != null)
            {
                foreach (var product in listedProducts)
                {
                    Console.WriteLine(product.ToString());
                }
                return listedProducts;
            }
            else
            {
                Console.WriteLine("No products of this type yet.");
                return null;
            }

        }

        public double GetTotalPriceOfCart()
        {
            return cart.TotalPrice();
        }
    }
}
