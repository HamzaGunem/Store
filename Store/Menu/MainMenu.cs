using Store.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Menu
{
    internal class MainMenu(OnlineStore onlineStore) : BaseMenu(onlineStore)
    {
        public override void Display()
        {
            while (CurrentOnlineStore.IsRunning)
            {
                Console.Clear();
                Console.WriteLine("=== Welcome ===");
                Console.WriteLine("1: Show All Books");
                Console.WriteLine("2: Show All EBooks");
                Console.WriteLine("3: Show All Magazine");
                Console.WriteLine("4: Go to cart");
                Console.WriteLine("5: Exit");
                Console.WriteLine($"\nWhat do you want to do:");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1": SwitchMenu(new ShoppingOfTypeMenu(CurrentOnlineStore, 1)); break;
                    case "2": SwitchMenu(new ShoppingOfTypeMenu(CurrentOnlineStore, 2)); break;
                    case "3": SwitchMenu(new ShoppingOfTypeMenu(CurrentOnlineStore, 3)); break;
                    case "4": SwitchMenu(new CartMenu(CurrentOnlineStore)); break;
                    case "5": CurrentOnlineStore.Exit(); break;
                    default: Console.WriteLine("\nInvalid input"); break;
                }
            }
        }

    }
}
