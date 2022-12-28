using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    /// <summary>
    /// Base class for the Menu's controller
    /// </summary>
    public abstract class ControllerBase
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ControllerBase()
        {
            //Start();
        }
        /// <summary>
        /// Start a menu
        /// </summary>
        public abstract void Start();
    }
}
