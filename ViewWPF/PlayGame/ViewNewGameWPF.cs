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
        private GameWPF _game;
        public GameWPF Game
        {
            get
            {
                _game = (GameWPF)_resourceDictionary["sokobanGame"];
                return _game;
            }
            set
            {
                _game = value;
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
        /// <summary>
        /// Try to load and start the first level of the game.
        /// </summary>
        public override void TryToStartFirstLevel()
        {
            try
            {
                _game.Start();
            }
            catch (Exception ex)
            {
                PrintMessage("Problem loading game. " + ex.Message);
            }
        }
        private void DrawGameLevel()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Viewbox viewbox = new()
                {
                    Stretch = Stretch.Uniform
                };

                Grid gridGame = new();
                gridGame.Children.Clear();
                gridGame.RowDefinitions.Clear();
                gridGame.ColumnDefinitions.Clear();

                _gridMain = new Grid();
                _gridMain.Children.Clear();
                _gridMain.RowDefinitions.Clear();
                _gridMain.ColumnDefinitions.Clear();

                var rowCount = _game.Level.RowCount;
                var columnCount = _game.Level.ColumnCount;
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
                        Button button = new()
                        {
                            Focusable = false,
                            Padding = new Thickness(0, 0, 0, 0)
                        };
                        Cell cell = _game.Level[row, column];
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
                _gridMain.DataContext = _game.Level;
                _dockPanel.Children.Add(_gridMain);
            });
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
            Application.Current.Dispatcher.Invoke(() => 
            {
                ViewMenuMainWPF.MainWindow.Content = _dockPanel;
            });
            
        }
        private void SetApplicationResourceDictionary(ResourceDictionary parResourceDictionary)
        {
            Application.Current.Resources.MergedDictionaries.Add(parResourceDictionary);
        }

        public override void PrintMessage(string parMessage)
        {
            MessageBox.Show(parMessage);
        }
    }
}
