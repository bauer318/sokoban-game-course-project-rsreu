using Model.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Menu;

namespace ViewConsole.Menu
{
    public class ViewMenuConsole:View.Menu.ViewMenu
    {
        public int WIDTH = 60;
        public int HEIGHT = 30;
        private bool _isMenuMainActive;

        public ViewMenuConsole(Model.Menu.Menu parSubMeuItem) : base(parSubMeuItem)
        {
            Init();
            Draw();
        }
        public void NewGame()
        {
            _isMenuMainActive = false;
        }
        public override void Draw()
        {
            Console.Clear();
            foreach(View.Menu.ViewMenuItem elViewMenuItem in Menu)
            {
                elViewMenuItem.Draw();
            }
        }

        protected override ViewMenuItem CreateItem(MenuItem parMenuItem)
        {
            if (parMenuItem is Model.Menu.SubMenuItem)
                return new ViewSubMenuItemConsole((Model.Menu.SubMenuItem)parMenuItem);
            else if (parMenuItem is Model.Menu.MenuItem)
                return new ViewMenuItemConsole(parMenuItem);
            return null;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
        private void Init()
        {
            Console.WindowHeight = HEIGHT;
            Console.WindowWidth = WIDTH;

            Console.SetBufferSize(WIDTH, HEIGHT);
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

        protected override void NeedRedraw()
        {
            Draw();
        }

        
    }
}
