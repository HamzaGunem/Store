using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Menu
{
    internal abstract class BaseMenu(OnlineStore onlineStore)
    {
        public BaseMenu? PreviousMenu { get; set; }
        public OnlineStore CurrentOnlineStore { get; set; } = onlineStore;
        public abstract void Display();

        public virtual void SwitchMenu(BaseMenu newMenu)
        {
            newMenu.PreviousMenu = this;

            newMenu.Display();
        }

        public void BackToMainMenu()
        {
            Console.WriteLine($"\nPress any key to go back");
            Console.ReadKey();
            SwitchMenu(new MainMenu(CurrentOnlineStore));
        }
        public void ClearLastLine(int numberOfLines)
        {
            for (int i = 0; i < numberOfLines; i++)
            {
                // Move the cursor to the start of the previous line
                Console.SetCursorPosition(0, Console.CursorTop - 1);

                // Overwrite the line with spaces (handle wide consoles)
                Console.Write(new string(' ', Console.BufferWidth));

                // Move the cursor back to the start of that line
                Console.SetCursorPosition(0, Console.CursorTop);
            }
        }
    }
}
