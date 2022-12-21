using ModelWPF.Game.Cells;
using ModelWPF.Game.Commands;
using ModelWPF.Game.Levels;
using ModelWPF.Game.Locations;
using ModelWPF.Game.NewGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using View.PlayGame;
using CommandManager = ModelWPF.Game.Commands.CommandManager;

namespace ViewWPF.PlayGame
{
    public partial class ViewNewGameWPF : IMenuChosen
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

        public GameLevel Game
        {
            get
            {
                return (GameLevel)_resourceDictionary["sokobanGame"];
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

       
       public void InitialiseLevel()
        {
            commandManager.Clear();

            Border border = new Border();
            border.Padding = new Thickness(20, 0, 0, 0);
            border.CornerRadius = new CornerRadius(12);
            border.BorderThickness = new Thickness(0, 0, 0, 0);

            Viewbox viewbox = new Viewbox();
            viewbox.Stretch = Stretch.Uniform;

            Grid grid_Game = new Grid();
            grid_Game.Children.Clear();
            grid_Game.RowDefinitions.Clear();
            grid_Game.ColumnDefinitions.Clear();

            Grid grid_Main = new Grid();
            grid_Main.Children.Clear();
            grid_Main.RowDefinitions.Clear();
            grid_Main.ColumnDefinitions.Clear();

            var rowCount = Game.Level.RowCount;
            var columnCount = Game.Level.ColumnCount;

            for (var i = 0; i < rowCount; i++)
            {
                grid_Game.RowDefinitions.Add(new RowDefinition());

            }
            for (var i = 0; i < columnCount; i++)
            {
                grid_Game.ColumnDefinitions.Add(new ColumnDefinition());

            }

            for (var row = 0; row < rowCount; row++)
            {

                for (var column = 0; column < columnCount; column++)
                {
                    Cell cell = Game.Level[row, column];
                    Button button = new Button();
                    button.Focusable = false;
                    button.DataContext = cell;
                    button.Padding = new Thickness(0, 0, 0, 0);
                    button.Style = (Style)Application.Current.FindResource("Cell");
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, column);
                    grid_Game.Children.Add(button);
                }
            }
            viewbox.Child = grid_Game;
            grid_Main.RowDefinitions.Add(new RowDefinition());
            grid_Main.ColumnDefinitions.Add(new ColumnDefinition());
            grid_Main.Children.Add(viewbox);
            grid_Main.DataContext = Game.Level;
            grid_Main.Focus();
            _dockPanel = new DockPanel();
            _dockPanel.Children.Add(grid_Main);
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            CommandBase command = null;
            Level level = Game.Level;
            if(Game != null)
            {
                if (Game.GameState == GameState.Running)
                {
                    switch (e.Key)
                    {
                        case Key.Up:
                            command = new MoveCommand(level, Direction.Up);
                            break;
                        case Key.Down:
                            command = new MoveCommand(level, Direction.Down);
                            break;
                        case Key.Left:
                            command = new MoveCommand(level, Direction.Left);
                            break;
                        case Key.Right:
                            command = new MoveCommand(level, Direction.Right);
                            break;
                        case Key.Z:
                            if (Keyboard.Modifiers == ModifierKeys.Control)
                            {
                                commandManager.Undo();
                            }
                            break;
                        case Key.Y:
                            if (Keyboard.Modifiers == ModifierKeys.Control)
                            {
                                commandManager.Redo();
                            }
                            break;
                    }
                }
                else
                {
                    switch (Game.GameState)
                    {
                        case GameState.GameOver:
                            Game.Start();
                            break;
                        case GameState.LevelCompleted:
                            MessageBox.Show(Game.Level.Actor.MoveCount.ToString());
                            Game.GotoNextLevel();
                            firstStartLevel = false;
                            ReinitChoseenMenu += new dReinitChoseenMenu(InitChosenMenu);
                            ReinitChoseenMenu.Invoke(_mainWindow);
                            break;
                    }
                }  
            }
            if(command != null)
            {
                commandManager.Execute(command);
            }
        }
       
        public void InitChosenMenu(MainWindow parMainWindow)
        {
            _mainWindow = parMainWindow;
            Application.Current.Resources.MergedDictionaries.Add(_resourceDictionary);
            if (firstStartLevel)
            {
                TryToStartFirstLevel();
                parMainWindow.KeyDown += new KeyEventHandler(Window_KeyDown);
            }
            InitialiseLevel();
            parMainWindow.Content = _dockPanel;
        }
    }
}
