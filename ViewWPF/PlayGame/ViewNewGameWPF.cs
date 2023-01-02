using Model.PlayGame.Cells;
using Model.PlayGame.Commands;
using ModelWPF.PlayGame.NewGame;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using View.PlayGame;
using ViewWPF.MenuGraphics;

namespace ViewWPF.PlayGame
{
    public partial class ViewNewGameWPF : ViewNewGameBase
    {
        private DockPanel _dockPanel;
        private Grid _gridMain;
        private ResourceDictionary _resourceDictionary = Application.LoadComponent(
            new Uri("/ViewWPF;component/PlayGame/ResourceDictionaries/CellWPF.xaml",
               UriKind.RelativeOrAbsolute)) as ResourceDictionary;
        
        public GameWPF Game
        {
            get
            {
                return (GameWPF)_resourceDictionary["sokobanGame"];
            }
            set
            {
                Game = value;
            }
        }

        /// <summary>
        /// Try to load and start the first level of the game.
        /// </summary>
        public override void TryToStartFirstLevel()
        {
            try
            {
                Game.Start();
            }
            catch (Exception ex)
            {
                PrintMessage("Problem loading game. " + ex.Message);
            }
        }

        public Grid GridMain
        {
            get
            {
                return _gridMain;
            }
            private set
            {
                _gridMain = value;
            }
        }
        public DockPanel DockPanel
        {
            get
            {
                return _dockPanel;
            }
        }

        public void DrawGameLevel()
        {
            Border border = new Border();
            border.Padding = new Thickness(20, 0, 0, 0);
            border.CornerRadius = new CornerRadius(12);
            border.BorderThickness = new Thickness(0, 0, 0, 0);

            Viewbox viewbox = new Viewbox();
            viewbox.Stretch = Stretch.Uniform;

            Grid gridGame = new Grid();
            gridGame.Children.Clear();
            gridGame.RowDefinitions.Clear();
            gridGame.ColumnDefinitions.Clear();

            _gridMain = new Grid();
            _gridMain.Children.Clear();
            _gridMain.RowDefinitions.Clear();
            _gridMain.ColumnDefinitions.Clear();

            var rowCount = Game.Level.RowCount;
            var columnCount = Game.Level.ColumnCount;
            for (var i = 0; i < rowCount; i++)
            {
                gridGame.RowDefinitions.Add(new RowDefinition());

            }
            for (var i = 0; i < columnCount; i++)
            {
                gridGame.ColumnDefinitions.Add(new ColumnDefinition());

            }

            for (var row = 0; row < rowCount; row++)
            {

                for (var column = 0; column < columnCount; column++)
                {
                    Button button = new Button();
                    button.Focusable = false;
                    button.Padding = new Thickness(0, 0, 0, 0);
                    Cell cell = Game.Level[row, column];
                    button.DataContext = cell;
                    button.Style = (Style)Application.Current.FindResource("Cell");
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, column);
                    gridGame.Children.Add(button);
                }
            }
            viewbox.Child = gridGame;
            _gridMain.RowDefinitions.Add(new RowDefinition());
            _gridMain.ColumnDefinitions.Add(new ColumnDefinition());
            _gridMain.Children.Add(viewbox);
            _gridMain.Focus();
            _dockPanel = new DockPanel();
            _gridMain.DataContext = Game.Level;
            _dockPanel.Children.Add(_gridMain);
        }

        public override void ProcessDrawGameLevel()
        {
            CommandManager.Clear();
            if (FirstStartLevel)
            {
                TryToStartFirstLevel();
                SetApplicationResourceDictionary(_resourceDictionary);
            }
            DrawGameLevel();
            ViewMenuMainWPF.MainWindow.Content = _dockPanel;
        }
        public void SetApplicationResourceDictionary(ResourceDictionary parResourceDictionary)
        {
            Application.Current.Resources.MergedDictionaries.Add(parResourceDictionary);
        }

        public override void PrintMessage(string parMessage)
        {
            MessageBox.Show(parMessage);
        }
    }
}
