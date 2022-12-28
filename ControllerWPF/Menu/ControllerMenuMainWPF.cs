using Controller.PlayGame;
using ControllerWPF.Help;
using ControllerWPF.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewWPF.Help;
using ViewWPF.PlayGame;
using ViewWPF.Record;

namespace ControllerWPF.Menu
{
    public class ControllerMenuMainWPF : Controller.Menu.ControllerMenu
    {
        private ViewWPF.MenuGraphics.ViewMenuMainWPF _viewMenu = null;
        public ControllerMenuMainWPF()
        {
            Menu = new Model.Menu.MenuMain();
            _viewMenu = new ViewWPF.MenuGraphics.ViewMenuMainWPF(Menu);
            Menu[(int)Model.Menu.MenuItemCodes.Exit].Selected += () => { _viewMenu.Close(); };
            Menu[(int)Model.Menu.MenuItemCodes.New].Selected += () => 
            {
                _viewMenu.NewGame();
                new ControllerPlayGameWPF(new ViewNewGameWPF());
            };
            Menu[(int)Model.Menu.MenuItemCodes.Help].Selected += () => 
            { 
                _viewMenu.Help();
                new ControllerHelpWPF(new ViewHelpWPF());
            };
           Menu[(int)Model.Menu.MenuItemCodes.Record].Selected += () => 
           { 
               _viewMenu.Record();
               new ControllerRecordWPF(new ViewRecordWPF());
           };
            _viewMenu.Init();
            foreach (Model.Menu.MenuItem elMenuItem in Menu.Items)
            {

                ((ViewWPF.MenuGraphics.ViewMenuItemWPF)_viewMenu[elMenuItem.ID]).Enter += (id) => { Menu.FocusItemById(id); Menu.SelectFocusedItem(); };
            }
        }
        public override void Start()
        {
            throw new NotImplementedException();
        }
    }
}
