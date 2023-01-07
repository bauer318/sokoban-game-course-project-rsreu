using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ViewWPF
{
    /// <summary>
    /// Interface for working with the game's menu
    /// </summary>
    public interface IMenu
    {
        /// <summary>
        /// Set the parent's control
        /// </summary>
        /// <param name="parControl">The parent's control</param>
        void SetParentControl(FrameworkElement parControl);
       
    }
}
