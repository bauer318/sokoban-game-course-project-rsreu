using Model.PlayGame.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ViewWPF.PlayGame
{
    public class TestView : View.PlayGame.ViewNewGameBase,IMenuChosen
    {
        private readonly CommandManager commandManager = new CommandManager();
        private ResourceDictionary _resourceDictionary = Application.LoadComponent(
            new Uri("/ViewWPF;component/PlayGame/ResourceDictionaries/Cell.xaml",
               UriKind.RelativeOrAbsolute)) as ResourceDictionary;
        private DockPanel _dockPanel;
        private MainWindow _mainWindow;
        public delegate void dReinitChoseenMenu(MainWindow mainWindow);
        public event dReinitChoseenMenu ReinitChoseenMenu;
        public bool firstStartLevel = true;
        public void InitChosenMenu(MainWindow parMainWindow)
        {
            throw new NotImplementedException();
        }

        public override void InitialiseLevel()
        {
            throw new NotImplementedException();
        }
        public new Model.PlayGame.NewGame.Game Game
        {
            get
            {
                return (Model.PlayGame.NewGame.Game)_resourceDictionary["sokobanGame"];
            }
        }
        private void TryToStartFirstLevel()
        {
            try
            {
                /* Load and start the first level of the game. */
                Game.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem loading game. " + ex.Message);
            }
        }
    }
}
