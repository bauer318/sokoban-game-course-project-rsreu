using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Menu
{
    /// <summary>
    /// Base class for Menu's controller
    /// </summary>
    public abstract class ControllerMenu : ControllerBase
    {
        /// <summary>
        /// A Menu
        /// </summary>
        private Model.Menu.Menu _menu = null;
        /// <summary>
        /// Get or set a menu
        /// </summary>
        protected Model.Menu.Menu Menu
        {
            get { return _menu; }
            set { _menu = value; }
        }
    }
}
