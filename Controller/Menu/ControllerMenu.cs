using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Menu
{
    public abstract class ControllerMenu : ControllerBase
    {
        private Model.Menu.Menu _menu = null;
        protected Model.Menu.Menu Menu
        {
            get { return _menu; }
            set { _menu = value; }
        }
    }
}
