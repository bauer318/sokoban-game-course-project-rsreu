using Controller.PlayGame;
using ControllerWPF.Help;
using ControllerWPF.Records;
using System.Windows.Input;
using ViewWPF.Help;
using ViewWPF.MenuGraphics;
using ViewWPF.PlayGame;
using ViewWPF.Records;

namespace ControllerWPF.Menu
{
    public class ControllerMenuMainWPF : Controller.Menu.ControllerMenu
    {
        private readonly ViewWPF.MenuGraphics.ViewMenuMainWPF _viewMenu = null;
        public ControllerMenuMainWPF()
        {
            Menu = new Model.Menu.MenuMain();
            _viewMenu = new ViewWPF.MenuGraphics.ViewMenuMainWPF(Menu);
            Menu[(int)Model.Menu.MenuItemCodes.Exit].Selected += () =>
            {
                _viewMenu.Close();
            };
            Menu[(int)Model.Menu.MenuItemCodes.New].Selected += () =>
            {
                _viewMenu.NewGame();
                _ = new ControllerPlayGameWPF(new ViewNewGameWPF());
            };
            Menu[(int)Model.Menu.MenuItemCodes.Help].Selected += () =>
            {
                _viewMenu.Help();
                _ = new ControllerHelpWPF(new ViewHelpWPF());
            };
            Menu[(int)Model.Menu.MenuItemCodes.Record].Selected += () =>
            {
                _viewMenu.Record();
                _ = new ControllerRecordWPF(new ViewRecordWPF());
            };
            _viewMenu.Init();
            foreach (Model.Menu.MenuItem elMenuItem in Menu.Items)
            {

                ((ViewWPF.MenuGraphics.ViewMenuItemWPF)_viewMenu[elMenuItem.ID]).Enter += (id) =>
                {
                    Menu.FocusItemById(id);
                    Menu.SelectFocusedItem();
                };
            }

        }
        public override void Start()
        {
            ViewMenuMainWPF.MainWindow.KeyDown += new KeyEventHandler(Controll_KeyDown);
        }

        private void Controll_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    Menu.FocusPrevious();
                    break;
                case Key.Down:
                    Menu.FocusNext();
                    break;
                case Key.Enter:
                    Menu.SelectFocusedItem();
                    break;
            }
        }
    }
}
