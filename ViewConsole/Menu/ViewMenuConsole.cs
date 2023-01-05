using Model.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using View.Menu;

namespace ViewConsole.Menu
{
    /// <summary>
    /// Representes the view's menu
    /// </summary>
    public class ViewMenuConsole:View.Menu.ViewMenu
    {
        /// <summary>
        /// The view menu's Height
        /// </summary>
        public int WIDTH = Console.WindowWidth;
        /// <summary>
        /// The view menu's Width
        /// </summary>
        public int HEIGHT = Console.WindowHeight;

        /// <summary>
        /// Initializes the view's menu
        /// </summary>
        /// <param name="parSubMeuItem">The submenu's item</param>
        [SupportedOSPlatform("windows")]
        public ViewMenuConsole(Model.Menu.Menu parSubMeuItem) : base(parSubMeuItem)
        {
            Init();
            Draw();
        }
        /// <summary>
        /// Draw the view's menu
        /// </summary>
        
        public override void Draw()
        {
            var gameName = "SOKOBAN";
            Console.Clear();
            Console.CursorLeft = (WIDTH - gameName.Length-4)/2;
            Console.CursorTop = HEIGHT/3;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(gameName);
            Console.ForegroundColor = ConsoleColor.White;
            foreach(View.Menu.ViewMenuItem elViewMenuItem in Menu)
            {
                elViewMenuItem.Draw();
            }
        }
        /// <summary>
        /// Create a menu's item 
        /// Can be a Submenu's item or menu's item
        /// </summary>
        /// <param name="parMenuItem">The menu's item</param>
        /// <returns></returns>
        public override ViewMenuItem CreateItem(MenuItem parMenuItem)
        {
            if (parMenuItem is Model.Menu.SubMenuItem)
                return new ViewSubMenuItemConsole((Model.Menu.SubMenuItem)parMenuItem);
            else if (parMenuItem is Model.Menu.MenuItem)
                return new ViewMenuItemConsole(parMenuItem);
            return null;
        }
        /// <summary>
        /// Initializes all the parameters of menu's view
        /// </summary>
        [SupportedOSPlatform("windows")]
        private void Init()
        {
            
            Console.WindowHeight = HEIGHT;
            Console.WindowWidth = WIDTH;

            Console.SetBufferSize(WIDTH, HEIGHT);
            Console.SetWindowSize(WIDTH, HEIGHT);
            Console.CursorVisible = false;

            View.Menu.ViewMenuItem[] menu = Menu;
            Height = menu.Length;
            Width = menu.Max((x) => x.Width);
            X = Console.WindowWidth / 2 - Width / 2;
            Y = Console.WindowHeight / 2 - Height / 2;

            int y = Y;
            foreach(View.Menu.ViewMenuItem elViewMenuItem in Menu)
            {
                elViewMenuItem.X = X;
                elViewMenuItem.Y = y++;
            }
        }
        /// <summary>
        /// Occurs when need to redraw the menu
        /// </summary>
        public override void NeedRedraw()
        {
            Draw();
        }

        
    }
}
