using Store.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        string resetColor = "\u001b[0m";
        string greenColor = "\x1b[32m";

        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public double GetTotalPrice()
        {
            return Product.Price * Quantity;
        }
        public override string ToString()
        {
            return $"{Product.Title} - Quantity: {Quantity}, Total Price: {GetTotalPrice()}, {greenColor}ISBN: {Product.ISBN}{resetColor}";
        }
    }
}
