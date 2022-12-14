using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ViewWPF.MenuGraphics
{
    public class ViewSubMenuItemWPF : View.Menu.ViewSubMenuItem, IMenu
    {
        public ViewSubMenuItemWPF(Model.Menu.SubMenuItem parSubMenuItem) : base(parSubMenuItem)
        {

        }
        public void SetParentControl(FrameworkElement parControl)
        {
        }
        public override void Draw()
        {
        }
    }
}
