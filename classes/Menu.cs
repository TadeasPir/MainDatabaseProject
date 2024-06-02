using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProjectPV.classes
{

    /// <summary>
    /// Represents a menu containing a collection of menu items.
    /// </summary>**/
    /// 
    public class Menu
    {
        private string caption { get; init; }
        private List<MenuItem> menuItems = new List<MenuItem>();

        public Menu(string caption)
        {
            this.caption = caption;
        }

        /// <summary>
        /// Displays the menu with its caption and menu items.
        /// </summary>
        public void Show()
        {
            Console.WriteLine(caption);
            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {menuItems[i]}");
            }
        }
        /// <summary>
        /// Retrieves the menu item at the specified index.
        /// </summary>
        /// <param name="userInput">The index of the menu item to retrieve.</param>
        /// <returns>The menu item at the specified index, or null if the index is invalid.</returns>

        public MenuItem Selection(int userInput)
        {
            int index = userInput - 1;
            if (index < 0 || index >= menuItems.Count)
            {
                Console.Error.WriteLine($"Index {userInput} is not valid input");
                return null;
            }

            return menuItems[index];
            /// <summary>
            /// Retrieves the menu item corresponding to the given user input string.
            /// </summary>
            /// <param name="userInput">The user input string representing the index of the menu item.</param>
            /// <returns>The menu item corresponding to the user input, or null if the input is invalid.</returns>
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
        /// <summary>
        /// Retrieves the menu item based on user input from the console.
        /// </summary>
        /// <returns>The selected menu item, or null if the input is invalid.</returns>
        public MenuItem Selection()
        {
            string input = Console.ReadLine();
            Console.WriteLine();
            return Selection(input);
        }  
        /// <summary>
        /// Executes the menu by displaying it and allowing the user to make a selection.
        /// </summary>
        /// <returns>The selected menu item.</returns>

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
        /// <summary>
        /// Adds a menu item to the menu.
        /// </summary>
        /// <param name="menuItem">The menu item to add.</param>
        public void Add(MenuItem menuItem)
        {
            this.menuItems.Add(menuItem);
        }
    }
}
