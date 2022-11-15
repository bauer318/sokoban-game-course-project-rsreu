using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Menu
{
    public abstract class ViewSubMenuItem:ViewMenuItem
    {
        private List<ViewMenuItem> _items = new List<ViewMenuItem>();
        public ViewSubMenuItem(Model.Menu.SubMenuItem parSubMenuItem) : base(parSubMenuItem)
        {

        }
        protected void AddItem(ViewMenuItem parViewMenuItem)
        {
            _items.Add(parViewMenuItem);
        }
    }
}
