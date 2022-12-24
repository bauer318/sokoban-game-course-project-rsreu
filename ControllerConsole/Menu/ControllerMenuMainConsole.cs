using ControllerConsole.PlayGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewConsole.PlayGame;

namespace ControllerConsole.Menu
{
    public class ControllerMenuMainConsole:Controller.Menu.ControllerMenu
    {
        private ViewConsole.Menu.ViewMenuConsole _viewMenu = null;
        protected bool NeedExit { get; set; }

        public ControllerMenuMainConsole()
        {
            Menu = new Model.Menu.MenuMain();
            _viewMenu = new ViewConsole.Menu.ViewMenuConsole(Menu);

            Menu[(int)Model.Menu.MenuItemCodes.Exit].Selected += () => { NeedExit = true; };
            Menu[(int)Model.Menu.MenuItemCodes.New].Selected += () =>
            {
                _viewMenu.NewGame();
                ViewNewGameConsole viewNewGameConsole = new ViewNewGameConsole();
                viewNewGameConsole.ViewMenuConsole = _viewMenu;
                new ControllerPlayGameConsole(viewNewGameConsole);
            };
        }
        public override void Start()
        {
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        Menu.FocusPrevious();
                        break;
                    case ConsoleKey.DownArrow:
                        Menu.FocusNext();
                        break;
                    case ConsoleKey.Enter:
                        Menu.SelectFocusedItem();
                        break;
                }
            } while (!NeedExit);
        }
    }
}
