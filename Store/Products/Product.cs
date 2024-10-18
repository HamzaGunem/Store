using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Products
{
    internal class Product
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public string ISBN { get; set; }
        public int Stock { get; set; }

        string resetColor = "\u001b[0m";
        string greenColor = "\x1b[32m";

        public Product(string title, double price, string isbn, int stock)
        {
            Title = title;
            Price = price;
            ISBN = isbn;
            Stock = stock;
        }

     
        public override string ToString()
        {
            return $"{Title}, Price: {Price}, {greenColor} ISBN: {ISBN} {resetColor}, Stock: {Stock}";
        }

    }
}
