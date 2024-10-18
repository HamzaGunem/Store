using Store.Menu;
using Store.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    internal class Cart
    {
        List<CartItem> cartItems = new List<CartItem>();

        public void AddProduct(Product product, int quantity)
        {
            var cartItem = cartItems.FirstOrDefault(ci => ci.Product.ISBN == product.ISBN);
            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                cartItems.Add(new CartItem(product, quantity));
            }
            Console.WriteLine($"\nAdded {quantity} of {product.Title} to the cart.");
        }

        public void RemoveProduct(string ISBN, int quantity)
        {
            var cartItem = cartItems.FirstOrDefault(ci => ci.Product.ISBN == ISBN);
            if (cartItem != null)
            {
                if (cartItem.Quantity <= quantity)
                {
                    cartItems.Remove(cartItem);
                    Console.WriteLine($"{cartItem.Product.Title} has been removed from the cart");
                }
                else
                {
                    cartItem.Quantity -= quantity;
                    Console.WriteLine($"Removed {quantity} of {cartItem.Product.Title} from the cart.");
                }
            }
            else
            {
                Console.WriteLine("Product not found in the cart.");
            }
        }

        public bool ListIfProductsInCart()
        {
            if (cartItems.Count == 0)
            {
                Console.WriteLine("Cart is empty");
                return false;
            }

            foreach (var item in cartItems)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine($"Total: {TotalPrice()}");
            return true;
        }

        public double TotalPrice()
        {
            return cartItems.Sum(ci => ci.GetTotalPrice());
        }
    }
}
