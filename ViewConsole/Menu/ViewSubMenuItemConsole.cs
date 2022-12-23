using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewConsole.Menu
{
    public class ViewSubMenuItemConsole:View.Menu.ViewSubMenuItem
    {

        public int HEIGHT = 1;
        public ViewSubMenuItemConsole(Model.Menu.SubMenuItem parSubMenuItem) : base(parSubMenuItem)
        {
            Height = HEIGHT;
            Width = parSubMenuItem.Name.Length + 2;
        }

        public override void Draw()
        {
            Console.CursorLeft = X;
            Console.CursorTop = Y;
            Console.Write(string.Format("{0} >", Item.Name));
        }

    }
}
