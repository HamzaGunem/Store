using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Products
{
    internal class Book(string title, double price, string isbn, int pages, int stock) : Product(title, price, isbn,stock)
    {
        public int Pages { get; set; } = pages;

        public override string ToString()
        {
            return $"Book: {base.ToString()}, Pages: {Pages}";
        }
    }
}
