using Model.PlayGame.Cells;
using Model.PlayGame.Commands;
using ModelWPF.PlayGame.NewGame;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using View.PlayGame;
using ViewWPF.MenuGraphics;

namespace ViewWPF.PlayGame
{
    /// <summary>
    /// Representes the new game's view
    /// </summary>
    public partial class ViewNewGameWPF : ViewNewGameBase
    {
        /// <summary>
        /// Main dockpanel as main container's new game's view
        /// </summary>
        private DockPanel _dockPanel;
        /// <summary>
        /// Main grid's new game's view
        /// </summary>
        private Grid _gridMain;
        /// <summary>
        /// The resource dictionary's new game's view
        /// </summary>
        private ResourceDictionary _resourceDictionary = Application.LoadComponent(
            new Uri("/ViewWPF;component/PlayGame/ResourceDictionaries/CellWPF.xaml",
               UriKind.RelativeOrAbsolute)) as ResourceDictionary;
        /// <summary>
        /// The sokoban's game
        /// </summary>
        private GameWPF _game;
        /// <summary>
        /// The list of ButtonLocation
        /// </summary>
        private List<ButtonLocation> _buttonList;
       
        /// <summary>
        /// Get or Set the sokoban's game
        /// </summary>
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
        /// <summary>
        /// Draw the current sokoban's game level
        /// </summary>
        private void DrawGameLevel()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                _buttonList = new();
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
                        ButtonLocation button = new(row, column)
                        {
                            Focusable = false,
                            Padding = new Thickness(0, 0, 0, 0)
                        };
                        Cell cell = _game.Level[row, column];
                        cell.NeedRedrawCell += Cell_NeedRedrawCell;
                        button.DataContext = cell;
                        button.Style = (Style)Application.Current.FindResource("Cell");
                        _buttonList.Add(button);
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
        /// <summary>
        /// Redraw the cell
        /// </summary>
        /// <param name="parCell">The cell to redraw</param>
        private void Cell_NeedRedrawCell(Cell parCell)
        {
            ButtonLocation button = ButtonLocation.GetButtonLocationByCoord(
                parCell.Location.RowNumber,
                parCell.Location.ColumnNumber,
                _buttonList);
            button.Style = null;
            button.Style = (Style)Application.Current.FindResource("Cell");
        }

        /// <summary>
        /// Processes to draw the sokoban's game level
        /// </summary>
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
        /// <summary>
        /// Set the application's resource dictionary
        /// </summary>
        /// <param name="parResourceDictionary">the application's resource dictionary</param>
        private void SetApplicationResourceDictionary(ResourceDictionary parResourceDictionary)
        {
            Application.Current.Resources.MergedDictionaries.Add(parResourceDictionary);
        }
        /// <summary>
        /// Print a message
        /// </summary>
        /// <param name="parMessage">The message to print</param>
        public override void PrintMessage(string parMessage)
        {
            MessageBox.Show(parMessage);
        }
    }
}
