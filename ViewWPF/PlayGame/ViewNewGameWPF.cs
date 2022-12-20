using ModelWPF.Game.Cells;
using ModelWPF.Game.Command;
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

namespace ViewWPF.PlayGame
{
    public partial class ViewNewGameWPF : IMenuChosen
    {
        private readonly ModelWPF.Game.Command.CommandManager commandManager = new ModelWPF.Game.Command.CommandManager();
        ResourceDictionary res = Application.LoadComponent(
            new Uri("/ViewWPF;component/PlayGame/ResourceDictionaries/Cell.xaml",
               UriKind.RelativeOrAbsolute)) as ResourceDictionary;
        private DockPanel dockPanel;


        GameLevel Game
        {
            get
            {
                return (GameLevel)res["sokobanGame"];
            }
        }
        

        private void Window_Loaded()
        {
            Game.PropertyChanged += game_PropertyChanged;

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
        void game_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "GameState":
                    UpdateGameDisplay();
                    break;
            }
        }
        /// <summary>
		/// We set feedback messages and so one here,
		/// using the game's <see cref="GameState"/>.
		/// </summary>
		void UpdateGameDisplay()
        {
            switch (Game.GameState)
            {
                case GameState.Loading:
                    //FeedbackControl1.Message = new FeedbackMessage { Message = "Loading..." };
                    //ContinuePromptVisible = false;
                    break;
                case GameState.GameOver:
                    //FeedbackControl1.Message = new FeedbackMessage { Message = "Game Over" };
                    //ContinuePromptVisible = true;
                    break;
                case GameState.Running:
                    //ContinuePromptVisible = false;
                    //FeedbackControl1.Message = new FeedbackMessage();
                    // Uncomment when/if pause is implemented.
                    //if (gameState == GameState.Loading)
                    //{
                    InitialiseLevel();
                    //}
                    break;
                case GameState.LevelCompleted:
                    Game.GotoNextLevel();
                    //FeedbackControl1.Message = new FeedbackMessage { Message = "Level Completed!" };
                    //MediaElement_LevelComplete.Position = TimeSpan.MinValue;
                    //MediaElement_LevelComplete.Play();
                    //ContinuePromptVisible = true;
                    break;
                case GameState.GameCompleted:
                    /*FeedbackControl1.Message = new FeedbackMessage { Message = "Well done. \nGame completed! \nEmail dbvaughan \nAT g mail dot com" };
                    MediaElement_GameComplete.Position = TimeSpan.MinValue;
                    MediaElement_GameComplete.Play();*/
                    break;
            }
        }
        private void InitialiseLevel()
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

            var n = Game.Level.RowCount;
            var m = Game.Level.ColumnCount;

            for (var i = 0; i < n; i++)
            {
                grid_Game.RowDefinitions.Add(new RowDefinition());

            }
            for (var i = 0; i < m; i++)
            {
                grid_Game.ColumnDefinitions.Add(new ColumnDefinition());

            }
            for (var row = 0; row < n; row++)
            {

                for (var column = 0; column < m; column++)
                {
                    Cell cell = Game.Level[row, column];
                    Button b = new Button();
                    b.Focusable = false;
                    b.DataContext = cell;
                    b.Padding = new Thickness(0, 0, 0, 0);
                    b.Style = (Style)Application.Current.FindResource("Cell");
                    Grid.SetRow(b, row);
                    Grid.SetColumn(b, column);
                    grid_Game.Children.Add(b);
                }
            }
            viewbox.Child = grid_Game;
            grid_Main.RowDefinitions.Add(new RowDefinition());
            grid_Main.ColumnDefinitions.Add(new ColumnDefinition());
            grid_Main.Children.Add(viewbox);
            grid_Main.DataContext = Game.Level;
            grid_Main.Focus();
            dockPanel = new DockPanel();
            dockPanel.Children.Add(grid_Main);
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            CommandBase command = null;
            Level level = Game.Level;
            if(Game != null)
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
            if(command != null)
            {
                commandManager.Execute(command);
            }
        }
        public void InitChosenMenu(MainWindow parMainWindow)
        {
            Application.Current.Resources.MergedDictionaries.Add(res);
            Window_Loaded();
            parMainWindow.KeyDown += new KeyEventHandler(Window_KeyDown);
            InitialiseLevel();
            parMainWindow.Content = dockPanel;
        }
    }
}
