using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Menu
{
    /// <summary>
    /// Representes a single menu item
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// Delegate for the method to select the menu item
        /// </summary>
        public delegate void dSelected();
        /// <summary>
        /// Occurs when this menu item is selected
        /// </summary>
        public event dSelected Selected = null;
        /// <summary>
        /// The current menu item state 
        /// </summary>
        private States _state = States.Normal;
        /// <summary>
        /// The menu item name
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Get or Set the menu item state
        /// </summary>
        public States State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                if (_state == States.Selected)
                    Selected?.Invoke();
            }
        }
        /// <summary>
        /// Get or Set the menu item's ID
        /// </summary>
        public int ID { get; private set; }
        /// <summary>
        /// Initializes a menu item
        /// </summary>
        /// <param name="parId">The menu item's ID</param>
        /// <param name="parName">The menu item's name</param>
        public MenuItem(int parId, string parName)
        {
            ID = parId;
            State = States.Normal;
            Name = parName;
        }
    }
}
