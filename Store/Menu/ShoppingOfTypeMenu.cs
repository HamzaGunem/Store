using Store.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Menu
{
    internal class ShoppingOfTypeMenu(OnlineStore onlineStore, int input) : BaseMenu(onlineStore)
    {
        public override void Display()
        {
            while (CurrentOnlineStore.IsRunning)
            {
                ProductsToShow(input);
            }
        }
        private void ProductsToShow(int input)
        {
            Console.Clear();
            switch (input)
            {
                case 1:
                    if (CurrentOnlineStore.ListProductsOfType<Book>() == null)
                    {
                        BackToMainMenu();
                    }
                    Shopping();
                    break;

                case 2:
                    if (CurrentOnlineStore.ListProductsOfType<EBook>() == null)
                    {
                        BackToMainMenu();
                        break;
                    }
                    Shopping();
                    break;

                case 3:
                    if (CurrentOnlineStore.ListProductsOfType<Magazine>() == null)
                    {
                        BackToMainMenu();
                        break;
                    }
                    Shopping();
                    break;

                default:
                    BackToMainMenu();
                    break;
            }

        }

        private void Shopping()
        {
            Console.WriteLine($"\na: Add product to the cart");
            Console.WriteLine($"b: Go back to mainmenu");
            string? input = Console.ReadLine();
            switch (input)
            {
                case "b": SwitchMenu(new MainMenu(CurrentOnlineStore)); break;
                case "a": SelectProduct(); break;
                default: break;
            }

        }
        private void SelectProduct()
        {
            ClearLastLine(3);
            Console.WriteLine("ISBN of the product?");
            string? isbnInput = Console.ReadLine();
            Console.WriteLine("How many pieces you want to buy?");
            int amount = int.Parse(Console.ReadLine());
            CurrentOnlineStore.AddToCart(isbnInput, amount);
            BackToMainMenu();
        }
    }
}
