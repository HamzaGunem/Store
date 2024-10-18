using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Products
{
    internal class Magazine(string title, double price, string isbn, int stock) : Product (title, price, isbn, stock)
    {

    }
}
