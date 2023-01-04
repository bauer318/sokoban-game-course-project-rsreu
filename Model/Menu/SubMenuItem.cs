using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Menu
{
    /// <summary>
    /// Represents a submenu item
    /// </summary>
    public class SubMenuItem : MenuItem
    {
        /// <summary>
        /// The menu item's dictionary
        /// </summary>
        private Dictionary<int, MenuItem> _items = new();
        /// <summary>
        /// Get the array of all menu's items 
        /// </summary>
        public MenuItem[] Items
        {
            get
            {
                return _items.Values.ToArray();
            }
        }
        /// <summary>
        /// Get the single menu's item by ID
        /// </summary>
        /// <param name="parId">The menu's item ID</param>
        /// <returns></returns>
        public MenuItem this[int parId]
        {
            get
            {
                return _items[parId];
            }
        }
        /// <summary>
        /// Initializes a submenu item
        /// </summary>
        /// <param name="parId">The submenu item ID</param>
        /// <param name="parName">he submenu item name</param>
        public SubMenuItem(int parId, string parName) : base(parId, parName)
        {

        }
        /// <summary>
        /// Add the menu item
        /// </summary>
        /// <param name="parMenuItem">The added menu item</param>
        public void AddItem(MenuItem parMenuItem)
        {
            _items.Add(parMenuItem.ID, parMenuItem);
        }
    }
}
