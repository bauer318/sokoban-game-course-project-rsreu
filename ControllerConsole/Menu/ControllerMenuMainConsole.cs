using ControllerConsole.Help;
using ControllerConsole.PlayGame;
using ControllerConsole.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewConsole.Help;
using ViewConsole.PlayGame;
using ViewConsole.Record;

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
            Menu[(int)Model.Menu.MenuItemCodes.Help].Selected += () =>
            {
                _viewMenu.Help();
                ViewHelpConsole viewHelpConsole = new ViewHelpConsole();
                viewHelpConsole.ViewMenuConsole = _viewMenu;
                new ControllerHelpConsole(viewHelpConsole);
            };
            Menu[(int)Model.Menu.MenuItemCodes.Record].Selected += () =>
            {
                _viewMenu.Record();
                ViewRecordConsole viewRecordConsole = new ViewRecordConsole();
                viewRecordConsole.ViewMenuConsole = _viewMenu;
                new ControllerRecordConsole(viewRecordConsole);
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
