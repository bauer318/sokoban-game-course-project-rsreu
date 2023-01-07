using ControllerConsole.Help;
using ControllerConsole.PlayGame;
using ControllerConsole.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using ViewConsole.Help;
using ViewConsole.PlayGame;
using ViewConsole.Records;

namespace ControllerConsole.Menu
{
    /// <summary>
    /// Main menu's controller
    /// </summary>
    public class ControllerMenuMainConsole:Controller.Menu.ControllerMenu
    {
        /// <summary>
        /// Main menu's view
        /// </summary>
        private readonly ViewConsole.Menu.ViewMenuConsole _viewMenu = null;
        /// <summary>
        /// Indicates whether is need to exit app
        /// Get or Set the value
        /// </summary>
        public bool NeedExit { get; set; }
        /// <summary>
        /// Default's contructor
        /// </summary>
        [SupportedOSPlatform("windows")]
        public ControllerMenuMainConsole()
        {
            Menu = new Model.Menu.MenuMain();
            _viewMenu = new ViewConsole.Menu.ViewMenuConsole(Menu);

            Menu[(int)Model.Menu.MenuItemCodes.Exit].Selected += () => { NeedExit = true; };
            Menu[(int)Model.Menu.MenuItemCodes.New].Selected += () =>
            {
                
                ViewNewGameConsole viewNewGameConsole = new ViewNewGameConsole();
                viewNewGameConsole.ViewMenuConsole = _viewMenu;
                new ControllerPlayGameConsole(viewNewGameConsole);
            };
            Menu[(int)Model.Menu.MenuItemCodes.Help].Selected += () =>
            {
                
                ViewHelpConsole viewHelpConsole = new ViewHelpConsole();
                viewHelpConsole.ViewMenuConsole = _viewMenu;
                new ControllerHelpConsole(viewHelpConsole);
            };
            Menu[(int)Model.Menu.MenuItemCodes.Record].Selected += () =>
            {
                
                ViewRecordConsole viewRecordConsole = new ViewRecordConsole();
                viewRecordConsole.ViewMenuConsole = _viewMenu;
                new ControllerRecordConsole(viewRecordConsole);
            };
        }
        /// <summary>
        /// Start Main menu to work with KeyDown 
        /// </summary>
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
