using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Menu
{
    public class SubMenuItem : MenuItem
    {
        private Dictionary<int, MenuItem> _items = new Dictionary<int, MenuItem>();
        public MenuItem[] Items
        {
            get
            {
                return _items.Values.ToArray();
            }
        }

        public MenuItem this[int parId]
        {
            get
            {
                return _items[parId];
            }
        }

        public SubMenuItem(int parId, string parName) : base(parId, parName)
        {

        }
        protected void AddItem(MenuItem parMenuItem)
        {
            _items.Add(parMenuItem.ID, parMenuItem);
        }
    }
}
