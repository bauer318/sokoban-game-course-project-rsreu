using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using View.Menu;

namespace ViewWPF.MenuGraphics
{
    public class ViewMenuWPF : View.Menu.ViewMenu, IMenu
    {
        public ViewMenuWPF(Model.Menu.Menu parSubMenuItem) : base(parSubMenuItem)
        {
            Draw();
        }
        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public void Init(FrameworkElement parControl)
        {
        }

        public void SetParentControl(FrameworkElement parControl)
        {
            View.Menu.ViewMenuItem[] menu = Menu;
            foreach (View.Menu.ViewMenuItem elViewMenuItem in menu)
            {
                ((IMenu)elViewMenuItem).SetParentControl(parControl);
            }
        }

        public override ViewMenuItem CreateItem(Model.Menu.MenuItem parMenuItem)
        {
            if (parMenuItem is Model.Menu.SubMenuItem)
                return new ViewSubMenuItemWPF((Model.Menu.SubMenuItem)parMenuItem);
            else if (parMenuItem is Model.Menu.MenuItem)
                return new ViewMenuItemWPF(parMenuItem);
            return null;
        }

        public override void NeedRedraw()
        {
            foreach (View.Menu.ViewMenuItem elViewMenuItem in Menu)
            {
                elViewMenuItem.Draw();
            }
        }
    }
}
