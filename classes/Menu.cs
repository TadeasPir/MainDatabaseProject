using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProjectPV.classes
{
    public class Menu
    {
        private string caption { get; init; }
        private List<MenuItem> menuItems = new List<MenuItem>();

        public Menu(string caption)
        {
            this.caption = caption;
        }
        public void Show()
        {
            Console.WriteLine(caption);
            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {menuItems[i]}");
            }
        }

        public MenuItem Selection(int userInput)
        {
            int index = userInput - 1;
            if (index < 0 || index >= menuItems.Count)
            {
                Console.Error.WriteLine($"Index {userInput} is not valid input");
                return null;
            }

            return menuItems[index];
        }

        public MenuItem Selection(string userInput)
        {
            int idx;
            if (!int.TryParse(userInput, out idx))
            {
                Console.Error.WriteLine($"Invalid input '{userInput}'");
                return null;
            }

            return Selection(idx);
        }

        public MenuItem Selection()
        {
            string input = Console.ReadLine();
            Console.WriteLine();
            return Selection(input);
        }

        public MenuItem Execute()
        {
            MenuItem item = null;
            do
            {
                Show();
                item = Selection();
            } while (item == null);

            return item;
        }

        public void Add(MenuItem menuItem)
        {
            this.menuItems.Add(menuItem);
        }
    }
}
