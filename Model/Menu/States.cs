using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Menu
{
    /// <summary>
    /// All menu's states
    /// </summary>
    public enum States:int
    {
        /// <summary>
        /// The normal state 
        /// </summary>
        Normal,
        /// <summary>
        /// When the menu's item is focused
        /// </summary>
        Focused,
        /// <summary>
        /// When the menu's item is selected
        /// </summary>
        Selected
    }
}
