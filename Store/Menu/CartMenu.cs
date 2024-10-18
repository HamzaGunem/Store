using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Menu
{
    class CartMenu(OnlineStore onlineStore) : BaseMenu(onlineStore)
    {
        public override void Display()
        {
            while (CurrentOnlineStore.IsRunning)
            {
                Console.Clear();
                if (CurrentOnlineStore.ProductsInCart())
                {
                    ReadyToCheckOut();
                }
                else
                {
                    BackToMainMenu();
                }
            }
        }
        public void ReadyToCheckOut()
        {
            Console.WriteLine($"\n1: Remove product from the cart.");
            Console.WriteLine($"2: Checkout.");
            Console.WriteLine($"3: back to main menu.");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1": RemoveProduct(); break;
                case "2": CheckOut(); break;
                case "3": BackToMainMenu(); break;
            }
        }
        public void RemoveProduct()
        {
            ClearLastLine(3);
            Console.WriteLine("ISBN of the product you want to remove:");
            string isbn = Console.ReadLine();
            ClearLastLine(1);
            Console.WriteLine("how many pieces do you want to remove");
            int amount = int.Parse(Console.ReadLine());
            CurrentOnlineStore.RemoveFromCart(isbn, amount);
            Console.WriteLine("Press any key to continue");
        }
        public void CheckOut()
        {
            Console.Clear();
            Console.WriteLine("Thank you for your purchase");
            Console.WriteLine($"Total payed: {CurrentOnlineStore.GetTotalPriceOfCart()}");
            Console.WriteLine($"Press any key to exit");
            Console.ReadKey();
            CurrentOnlineStore.Exit();
        }

    }
}
