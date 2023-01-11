﻿using Model.PlayGame.Commands;
using Model.PlayGame.Locations;
using Model.PlayGame.NewGame;
using ModelWPF.PlayGame.NewGame;
using System.Threading;
using System.Windows.Input;
using View.PlayGame;
using ViewWPF.MenuGraphics;
using ViewWPF.PlayGame;

namespace Controller.PlayGame
{
    /// <summary>
    /// New game's controller
    /// </summary>
    public class ControllerPlayGameWPF : ControllerPlayGame
    {
        /// <summary>
        /// New game's view
        /// </summary>
        private readonly ViewNewGameWPF _viewNewGameWPF = null;
        /// <summary>
        /// Representes the sokoban's game
        /// </summary>
        private readonly GameWPF _game;
        /// <summary>
        /// Initializes the new game's controller
        /// </summary>
        /// <param name="parViewNewGameBase">New game's base view</param>
        public ControllerPlayGameWPF(ViewNewGameBase parViewNewGameBase) : base(parViewNewGameBase)
        {
            _viewNewGameWPF = parViewNewGameBase as ViewNewGameWPF;
            _game = _viewNewGameWPF.Game;
            Thread thread = new(ViewNewGameBase.ProcessDrawGameLevel);
            thread.Name = "Play Game View Thread";
            thread.Start();
            AddKeyDownEventHandler();
        }
        /// <summary>
        /// Remove the KeyDown Controll from the main windows
        /// </summary>
        private void RemoveKeyDownEventHandler()
        {
            ViewMenuMainWPF.MainWindow.KeyDown -= new KeyEventHandler(Controll_KeyDown);
        }
        /// <summary>
        /// Add the KeyDown Controll to the main windows
        /// </summary>
        private void AddKeyDownEventHandler()
        {
            ViewMenuMainWPF.MainWindow.KeyDown += new KeyEventHandler(Controll_KeyDown);
        }
        /// <summary>
        /// Controll the KeyDown
        /// </summary>
        /// <param name="sender">The sender's object</param>
        /// <param name="e">The event sended</param>
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
                        case Key.R:
                            if (Keyboard.Modifiers == ModifierKeys.Control)
                            {
                                LevelPlayedUtils = new(false);
                                ViewNewGameBase.FirstStartLevel = true;
                                RemoveKeyDownEventHandler();
                                ViewMenuMainWPF.BackToMainMenu();
                            }
                            break;
                        case Key.N:
                            if (Keyboard.Modifiers == ModifierKeys.Control)
                            {

                                var nextLevel = _game.Level.LevelNumber + 1;
                                if (LevelPlayedUtils.LevelPlayed.IsLevelPlayed(nextLevel))
                                {
                                    ProcessNextLevel();
                                }
                                else
                                {
                                    _viewNewGameWPF.PrintMessage(string.Format("The level {0} is not been played or the current level is the " +
                                        "last game's level", nextLevel + 1));
                                }
                            }
                            break;
                        case Key.P:
                            if (Keyboard.Modifiers == ModifierKeys.Control)
                            {

                                var previousLevel = _game.Level.LevelNumber - 1;
                                if (previousLevel >= 0)
                                {
                                    ProcessPreviousLevel();
                                }
                                else
                                {
                                    _viewNewGameWPF.PrintMessage(" The current level is the first game's level !");
                                }
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
                            LevelPlayedUtils.UpdateLevelPlayed(_game.Level.LevelNumber);
                            RemoveKeyDownEventHandler();
                            ViewMenuMainWPF.BackToMainMenu();
                            break;
                        case GameState.LevelCompleted:
                            if (e.Key != Key.Escape)
                            {
                                UpdateRecord(_game.Level.LevelNumber, _game.Level.Actor.MoveCount);
                                if (RecordUtils.NewRecordHasBeenSet)
                                {
                                    ViewNewGameBase.PrintMessage("New record has been set!");
                                }
                                ProcessNextLevel();
                                LevelPlayedUtils.UpdateLevelPlayed(_game.Level.LevelNumber);
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
        /// <summary>
        /// Process go to the next level by doing ctrl + N
        /// </summary>
        public override void ProcessNextLevel()
        {

            _game.GotoNextLevel();
            ViewNewGameBase.FirstStartLevel = false;
            ViewNewGameBase.ProcessDrawGameLevel();
        }
        /// <summary>
        /// Process back to previous level by doing ctrl + P
        /// </summary>
        public override void ProcessPreviousLevel()
        {

            _game.BackToPreviousLevel();
            ViewNewGameBase.FirstStartLevel = false;
            ViewNewGameBase.ProcessDrawGameLevel();
        }
    }
}
