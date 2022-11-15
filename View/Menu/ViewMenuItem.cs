using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Menu
{
    public abstract class ViewMenuItem:ViewBase
    {
        private Model.Menu.MenuItem _item = null;

        protected Model.Menu.MenuItem Item
        {
            get
            {
                return _item;
            }
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }

        public ViewMenuItem(Model.Menu.MenuItem parItem)
        {
            _item = parItem;
        }
    }
}
