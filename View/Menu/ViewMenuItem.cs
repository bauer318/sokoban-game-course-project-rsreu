using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Menu
{
    /// <summary>
    /// The base class for the View menu item
    /// </summary>
    public abstract class ViewMenuItem : ViewBase
    {
        /// <summary>
        /// The menu's item
        /// </summary>
        private Model.Menu.MenuItem _item = null;
        /// <summary>
        /// Get the menu's item
        /// </summary>
        protected Model.Menu.MenuItem Item
        {
            get
            {
                return _item;
            }
        }
        /// <summary>
        /// The x coordinate of the menu's item
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// The Y coordinate of the menu's item
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// The width of the menu's item
        /// </summary>
        public int Width { get; protected set; }
        /// <summary>
        /// The Height of the menu's item
        /// </summary>
        public int Height { get; protected set; }
        /// <summary>
        /// Initializes the view menu's item
        /// </summary>
        /// <param name="parItem">The menu's item</param>
        public ViewMenuItem(Model.Menu.MenuItem parItem)
        {
            _item = parItem;
        }
    }
}
