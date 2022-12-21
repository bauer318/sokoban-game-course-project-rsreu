using Controller.PlayGame;
using ModelWPF.Game.Cells.Actors;
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
using System.Windows.Input;
using View.PlayGame;
using ViewWPF.MenuGraphics;
using ViewWPF.PlayGame;
using CommandManager = ModelWPF.Game.Commands.CommandManager;

namespace ControllerWPF.PlayGame
{
    public class ControllerPlayGameWPF:ControllerPlayGame
    {
        private readonly CommandManager commandManager = new CommandManager();
        private ResourceDictionary _resourceDictionary = Application.LoadComponent(
            new Uri("/ViewWPF;component/PlayGame/ResourceDictionaries/CellWPF.xaml",
               UriKind.RelativeOrAbsolute)) as ResourceDictionary;
        private ViewNewGameWPF _viewNewGameWPF = null;
        public ControllerPlayGameWPF(ViewNewGameBase parViewNewGameBase) : base(parViewNewGameBase) 
        {
            _viewNewGameWPF = parViewNewGameBase as ViewNewGameWPF;
            T();
        }

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
                ViewNewGameBase.PrintExceptionMessage("Problem loading game. " + ex.Message);
            }
        }

        public void T()
        {
            commandManager.Clear();
            if (ViewNewGameBase.FirstStartLevel)
            {
                TryToStartFirstLevel();
                ViewMenuMainWPF.MainWindow.KeyDown += new KeyEventHandler(Controll_KeyDown);
                _viewNewGameWPF.SetApplicationResourceDictionary(_resourceDictionary);
            }
            _viewNewGameWPF.DrawGameLevel(Game);
            ViewMenuMainWPF.MainWindow.Content = _viewNewGameWPF.DockPanel;
        }

        public void Controll_KeyDown(object sender, KeyEventArgs e)
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
                            Game.GotoNextLevel();
                            ViewNewGameBase.FirstStartLevel = false;
                            T();
                            break;
                    }
                }
            }
            if (command != null)
            {
                commandManager.Execute(command);
            }
        }
    }
 }
