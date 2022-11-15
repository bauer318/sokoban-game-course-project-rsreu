using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Menu
{
    public abstract class ViewMenu:ViewBase
    {
        private Model.Menu.Menu _menu = null;
        private Dictionary<int, ViewMenuItem> _subMenu = null;
        protected ViewMenuItem[] Menu => _subMenu.Values.ToArray();

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public ViewMenuItem this[int parId]
        {
            get
            {
                return _subMenu[parId];
            }
        }

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
        protected abstract void NeedRedraw();
        protected abstract ViewMenuItem CreateItem(Model.Menu.MenuItem parMenuItem);
    }
}
