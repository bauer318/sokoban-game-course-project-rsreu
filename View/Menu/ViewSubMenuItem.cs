using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Menu
{
    /// <summary>
    /// Representes the Submenu item's view
    /// </summary>
    public abstract class ViewSubMenuItem:ViewMenuItem
    {
        /// <summary>
        /// The list of all view menu's item
        /// </summary>
        private List<ViewMenuItem> _items = new List<ViewMenuItem>();
        /// <summary>
        /// Initializes the Submenu item's view
        /// </summary>
        /// <param name="parSubMenuItem">The submenu item</param>
        public ViewSubMenuItem(Model.Menu.SubMenuItem parSubMenuItem) : base(parSubMenuItem)
        {

        }
        /// <summary>
        /// Add the view menu's item
        /// </summary>
        /// <param name="parViewMenuItem">The view menu's item</param>
        protected void AddItem(ViewMenuItem parViewMenuItem)
        {
            _items.Add(parViewMenuItem);
        }
    }
}
