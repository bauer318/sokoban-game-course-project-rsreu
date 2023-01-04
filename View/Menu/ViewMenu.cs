using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Menu
{
    /// <summary>
    /// Base view Menu
    /// </summary>
    public abstract class ViewMenu:ViewBase
    {
        /// <summary>
        /// The Menu
        /// </summary>
        private Model.Menu.Menu _menu = null;
        /// <summary>
        /// The view menu item's dictionary
        /// </summary>
        private Dictionary<int, ViewMenuItem> _subMenu = null;
        /// <summary>
        /// The array of the submenu item
        /// </summary>
        protected ViewMenuItem[] Menu => _subMenu.Values.ToArray();
        /// <summary>
        /// The x coordinate of the menu's item
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// The y coordinate of the menu's item
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// The width of the menu's item
        /// </summary>
        public int Width { get; protected set; }
        /// <summary>
        /// The height of the menu's item
        /// </summary>
        public int Height { get; protected set; }
        /// <summary>
        /// Get the submenu item by ID
        /// </summary>
        /// <param name="parId">The submenu item's ID</param>
        /// <returns></returns>
        public ViewMenuItem this[int parId]
        {
            get
            {
                return _subMenu[parId];
            }
        }
        /// <summary>
        /// Initializes the view menu
        /// </summary>
        /// <param name="parSubMenuItem">The submenu item</param>
        public ViewMenu(Model.Menu.Menu parSubMenuItem)
        {
            _menu = parSubMenuItem;
            _subMenu = new Dictionary<int, ViewMenuItem>();
            foreach (Model.Menu.MenuItem elMenuItem in parSubMenuItem.Items)
            {
                _subMenu.Add(elMenuItem.ID, CreateItem(elMenuItem));
            }
            _menu.NeedRedraw += NeedRedraw;
        }
        /// <summary>
        /// Provides the drawing's process
        /// </summary>
        public abstract void NeedRedraw();
        /// <summary>
        /// Creates an menu item
        /// </summary>
        /// <param name="parMenuItem">menu's item</param>
        /// <returns></returns>
        public abstract ViewMenuItem CreateItem(Model.Menu.MenuItem parMenuItem);
    }
}
