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
    public class ViewMenuConsole:View.Menu.ViewMenu
    {
        public int WIDTH = Console.WindowWidth;
        public int HEIGHT = Console.WindowHeight;
        
        
        [SupportedOSPlatform("windows")]
        public ViewMenuConsole(Model.Menu.Menu parSubMeuItem) : base(parSubMeuItem)
        {
            Init();
            Draw();
        }
        
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

        public override ViewMenuItem CreateItem(MenuItem parMenuItem)
        {
            if (parMenuItem is Model.Menu.SubMenuItem)
                return new ViewSubMenuItemConsole((Model.Menu.SubMenuItem)parMenuItem);
            else if (parMenuItem is Model.Menu.MenuItem)
                return new ViewMenuItemConsole(parMenuItem);
            return null;
        }

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

        public override void NeedRedraw()
        {
            Draw();
        }

        
    }
}
