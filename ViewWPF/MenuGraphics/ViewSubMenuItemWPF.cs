using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ViewWPF.MenuGraphics
{
    /// <summary>
    /// Representes the submenu's item
    /// </summary>
    public class ViewSubMenuItemWPF : View.Menu.ViewSubMenuItem, IMenu
    {
        /// <summary>
        /// Initializes the submenu's item
        /// </summary>
        /// <param name="parSubMenuItem">The submenu's item</param>
        public ViewSubMenuItemWPF(Model.Menu.SubMenuItem parSubMenuItem) : base(parSubMenuItem)
        {

        }
        /// <summary>
        /// Set the submenu's parent control
        /// </summary>
        /// <param name="parControl">The submenu's parent control</param>
        public void SetParentControl(FrameworkElement parControl)
        {
        }
        /// <summary>
        /// Draw the submenu's item
        /// </summary>
        public override void Draw()
        {
        }
    }
}
