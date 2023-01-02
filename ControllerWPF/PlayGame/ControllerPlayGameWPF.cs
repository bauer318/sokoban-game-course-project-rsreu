using Controller.PlayGame;
using Model.PlayGame.Commands;
using Model.PlayGame.Locations;
using Model.PlayGame.NewGame;
using System;
using System.Windows;
using System.Windows.Input;
using View.PlayGame;
using ViewWPF.PlayGame;
using ViewWPF.MenuGraphics;
using ModelWPF.PlayGame.NewGame;

namespace Controller.PlayGame
{
    public class ControllerPlayGameWPF:ControllerPlayGame
    {
        private ViewNewGameWPF _viewNewGameWPF = null;
        private GameWPF _game;
        public ControllerPlayGameWPF(ViewNewGameBase parViewNewGameBase) : base(parViewNewGameBase)
        {
            _viewNewGameWPF = parViewNewGameBase as ViewNewGameWPF;
            _game = _viewNewGameWPF.Game;
            ViewNewGameBase.ProcessDrawGameLevel();
            AddKeyDownEventHandler();
        }
        private void RemoveKeyDownEventHandler()
        {
            ViewMenuMainWPF.MainWindow.KeyDown -= new KeyEventHandler(Controll_KeyDown);
        }

        private void AddKeyDownEventHandler()
        {
            ViewMenuMainWPF.MainWindow.KeyDown += new KeyEventHandler(Controll_KeyDown);
        }
        
        private void Controll_KeyDown(object sender, KeyEventArgs e)
        {
            CommandBase command = null;
            if (_game != null)
            {
                if (_game.GameState == GameState.Running)
                {
                    switch (e.Key)
                    {
                        case Key.Up:
                            command = new MoveCommand(_game.Level, Direction.Up);
                            break;
                        case Key.Down:
                            command = new MoveCommand(_game.Level, Direction.Down);
                            break;
                        case Key.Left:
                            command = new MoveCommand(_game.Level, Direction.Left);
                            break;
                        case Key.Right:
                            command = new MoveCommand(_game.Level, Direction.Right);
                            break;
                        case Key.Z:
                            if (Keyboard.Modifiers == ModifierKeys.Control)
                            {
                                ViewNewGameBase.CommandManager.Undo();
                            }
                            break;
                    }
                }
                else
                {
                    switch (_game.GameState)
                    {
                        case GameState.GameOver:
                            ViewNewGameBase.FirstStartLevel = true;
                            UpdateRecord(_game.Level.LevelNumber, _game.Level.Actor.MoveCount);
                            if (RecordUtils.NewRecordHasBeenSet)
                            {
                                ViewNewGameBase.PrintMessage("New record has been set!");
                            }
                            RemoveKeyDownEventHandler();
                            ViewMenuMainWPF.BackToMainMenu();
                            break;
                        case GameState.LevelCompleted:
                            if(e.Key != Key.Escape)
                            {
                                UpdateRecord(_game.Level.LevelNumber, _game.Level.Actor.MoveCount);
                                if (RecordUtils.NewRecordHasBeenSet)
                                {
                                    ViewNewGameBase.PrintMessage("New record has been set!");
                                }
                                _game.GotoNextLevel();
                                ViewNewGameBase.FirstStartLevel = false;
                                ViewNewGameBase.ProcessDrawGameLevel();
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
                ViewNewGameBase.CommandManager.Execute(command);
            }
        }
    }
 }
