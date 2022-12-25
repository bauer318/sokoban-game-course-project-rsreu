using Controller.PlayGame;
using Model.PlayGame.Commands;
using Model.PlayGame.Locations;
using Model.PlayGame.NewGame;
using System;
using System.Windows;
using System.Windows.Input;
using View.PlayGame;
using CommandManager = Model.PlayGame.Commands.CommandManager;
using ViewWPF.PlayGame;
using ViewWPF.MenuGraphics;
using Model.PlayGame.Cells;
using Model.PlayGame.Levels;
using ModelWPF.PlayGame.NewGame;

namespace Controller.PlayGame
{
    public class ControllerPlayGameWPF:ControllerPlayGame
    {
        private ResourceDictionary _resourceDictionary = Application.LoadComponent(
            new Uri("/ViewWPF;component/PlayGame/ResourceDictionaries/CellWPF.xaml",
               UriKind.RelativeOrAbsolute)) as ResourceDictionary;
        private ViewNewGameWPF _viewNewGameWPF = null;
        public GameWPF Game
        {
            get
            {
                //return new GameWPF();
                return (GameWPF)_resourceDictionary["sokobanGame"];
            }
            set
            {
                Game = value;
            }
        }
        public ControllerPlayGameWPF(ViewNewGameBase parViewNewGameBase) : base(parViewNewGameBase)
        {
            _viewNewGameWPF = parViewNewGameBase as ViewNewGameWPF;
            ProcessDrawGameLevel();
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
                ViewNewGameBase.PrintExceptionMessage("Problem loading game. " + ex.Message);
            }
        }

        public override void ProcessDrawGameLevel()
        {
            CommandManager.Clear();
            if (ViewNewGameBase.FirstStartLevel)
            {
                TryToStartFirstLevel();
                ViewMenuMainWPF.MainWindow.KeyDown += new KeyEventHandler(Controll_KeyDown);
                _viewNewGameWPF.SetApplicationResourceDictionary(_resourceDictionary);
            }
            _viewNewGameWPF.DrawGameLevel(Game.Level.RowCount, Game.Level.ColumnCount);
            SetCellButtonStyle();
            ViewMenuMainWPF.MainWindow.Content = _viewNewGameWPF.DockPanel;
        }
        public override void SetCellButtonStyle()
        {
            _viewNewGameWPF.CellButtons.ForEach(cellButton => 
            {
                Cell cell = Game.Level[cellButton.X, cellButton.Y];
                cellButton.DataContext = cell;
                cellButton.Style = (Style)Application.Current.FindResource("Cell");
            });
            _viewNewGameWPF.GridMain.DataContext = Game.Level;
        }
        private void RemoveKeyDownEventHandler()
        {
            ViewMenuMainWPF.MainWindow.KeyDown -= new KeyEventHandler(Controll_KeyDown);
        }
        
        private void Controll_KeyDown(object sender, KeyEventArgs e)
        {
            CommandBase command = null;
            Level level = Game.Level;
            if (Game != null)
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
                                CommandManager.Undo();
                            }
                            break;
                    }
                }
                else
                {
                    switch (Game.GameState)
                    {
                        case GameState.GameOver:
                            ViewNewGameBase.FirstStartLevel = true;
                            RemoveKeyDownEventHandler();
                            ViewMenuMainWPF.BackToMainMenu();
                            break;
                        case GameState.LevelCompleted:
                            if(e.Key != Key.Escape)
                            {
                                Game.GotoNextLevel();
                                ViewNewGameBase.FirstStartLevel = false;
                                ProcessDrawGameLevel();
                            }
                            break;
                    }
                }
                if (e.Key == Key.Escape)
                {
                    ViewNewGameBase.FirstStartLevel = true;
                    RemoveKeyDownEventHandler();
                }
            }
            if (command != null)
            {
                CommandManager.Execute(command);
            }
        }
    }
 }
