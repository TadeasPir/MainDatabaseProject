using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProjectPV.classes
{
    /// <summary>
    /// Represents a menu item with a description and an associated action to execute.
    /// </summary>
    public class MenuItem
    {
        private string description;
        private Action action;
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItem"/> class with the specified description and action.
        /// </summary>
        /// <param name="description">The description of the menu item.</param>
        /// <param name="action">The action to execute when the menu item is selected.</param>
        public MenuItem(string popis, Action akce)
        {
            this.description = popis;
            this.action = akce;
        }
     

        public override string ToString()
        {
            return description;
        }
        /// <summary>
        /// Executes the action associated with the menu item.
        /// </summary>
        public void Execute()
        {
            action();
            
        }
    }
}
