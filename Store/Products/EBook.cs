using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Store.Products
{
    internal class EBook(string title, double price, string isbn, double filesize,int stock) : Product (title, price, isbn, stock)
    {
        public double FileSize { get; set; } = filesize; //in mb.

        public override string ToString()
        {
            return base.ToString() + $", FileSize: {FileSize}";
        }
    }
}
