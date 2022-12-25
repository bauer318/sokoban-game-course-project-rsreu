using Controller.PlayGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewWPF.PlayGame;

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
            //Menu[(int)Model.Menu.MenuItemCodes.New].Selected += () => { _viewMenu.NewGame(); };
            Menu[(int)Model.Menu.MenuItemCodes.New].Selected += () => 
            {
                _viewMenu.NewGame();
                new ControllerPlayGameWPF(new ViewNewGameWPF());
            };
            Menu[(int)Model.Menu.MenuItemCodes.Help].Selected += () => { _viewMenu.Help(); };
            Menu[(int)Model.Menu.MenuItemCodes.Map].Selected += () => { _viewMenu.CreateGameMap(); };
           // Menu[(int)Model.Menu.MenuItemCodes.Record].Selected += () => { _viewMenu.Record(); };
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
