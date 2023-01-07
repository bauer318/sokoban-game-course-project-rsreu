using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewConsole.Menu
{
    /// <summary>
    /// Representes the submenu's item
    /// </summary>
    public class ViewSubMenuItemConsole:View.Menu.ViewSubMenuItem
    {
        /// <summary>
        /// The Submenu's item height
        /// </summary>
        public int HEIGHT = 1;
        /// <summary>
        /// Initializes the submenu's item
        /// </summary>
        /// <param name="parSubMenuItem">The submenu's item</param>
        public ViewSubMenuItemConsole(Model.Menu.SubMenuItem parSubMenuItem) : base(parSubMenuItem)
        {
            Height = HEIGHT;
            Width = parSubMenuItem.Name.Length + 2;
        }
        // <summary>
        /// Draw the submenu's item
        /// </summary>
        public override void Draw()
        {
            Console.CursorLeft = X;
            Console.CursorTop = Y;
            Console.Write(string.Format("{0} >", Item.Name));
        }

    }
}
