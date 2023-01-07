using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using View.Menu;

namespace ViewWPF.MenuGraphics
{
    /// <summary>
    /// Representes the view's menu
    /// </summary>
    public class ViewMenuWPF : View.Menu.ViewMenu, IMenu
    {
        /// <summary>
        /// Initializes the view's menu
        /// </summary>
        /// <param name="parSubMenuItem">The submenu's item</param>
        public ViewMenuWPF(Model.Menu.Menu parSubMenuItem) : base(parSubMenuItem)
        {
            Draw();
        }
        /// <summary>
        /// Draw the view's menu
        /// </summary>
        public override void Draw()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Set the menu's parent control
        /// </summary>
        /// <param name="parControl"></param>
        public void SetParentControl(FrameworkElement parControl)
        {
            View.Menu.ViewMenuItem[] menu = Menu;
            foreach (View.Menu.ViewMenuItem elViewMenuItem in menu)
            {
                ((IMenu)elViewMenuItem).SetParentControl(parControl);
            }
        }
        /// <summary>
        /// Create a menu's item
        /// </summary>
        /// <param name="parMenuItem">The menu's item</param>
        /// <returns></returns>
        public override ViewMenuItem CreateItem(Model.Menu.MenuItem parMenuItem)
        {
            if (parMenuItem is Model.Menu.SubMenuItem)
                return new ViewSubMenuItemWPF((Model.Menu.SubMenuItem)parMenuItem);
            else if (parMenuItem is Model.Menu.MenuItem)
                return new ViewMenuItemWPF(parMenuItem);
            return null;
        }
        /// <summary>
        /// Occurs when need to redraw the menu
        /// </summary>
        public override void NeedRedraw()
        {
            foreach (View.Menu.ViewMenuItem elViewMenuItem in Menu)
            {
                elViewMenuItem.Draw();
            }
        }
    }
}
