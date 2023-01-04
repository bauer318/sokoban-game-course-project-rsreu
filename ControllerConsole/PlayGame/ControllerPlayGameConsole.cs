using Controller.PlayGame;
using Model.PlayGame.Cells;
using Model.PlayGame.Commands;
using Model.PlayGame.Levels;
using Model.PlayGame.Locations;
using Model.PlayGame.NewGame;
using ModelConsole.PlayGame.NewGame;
using System;
using System.Threading;
using View.PlayGame;
using ViewConsole;
using ViewConsole.PlayGame;

namespace ControllerConsole.PlayGame
{
    public class ControllerPlayGameConsole : ControllerPlayGame
    {
        private ViewNewGameConsole _viewNewGameConsole;
        private GameConsole _game;
        public ControllerPlayGameConsole(ViewNewGameBase parViewNewGameBase) : base(parViewNewGameBase)
        {
            _viewNewGameConsole = parViewNewGameBase as ViewNewGameConsole;
            _game = _viewNewGameConsole.Game;
            Thread thread = new Thread(ViewNewGameBase.ProcessDrawGameLevel);
            thread.Name = "Play Game View Thread";
            thread.Start();
            Controll_KeyDown();
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

        private void Controll_KeyDown()
        {
            while (true)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                CommandBase command = null;
                if (keyPressed.Key == ConsoleKey.Escape || _game.GameState == GameState.GameOver)
                {
                    if (_game.GameState == GameState.GameOver)
                    {
                        UpdateRecord(_game.Level.LevelNumber, _game.Level.Actor.MoveCount);
                        if (RecordUtils.NewRecordHasBeenSet)
                        {
                            ViewNewGameBase.PrintMessage("New Record has been set");
                            Thread.Sleep(1000);
                        }
                        LevelPlayedUtils.UpdateLevelPlayed(_game.Level.LevelNumber);

                    }
                    ViewNewGameBase.FirstStartLevel = true;
                    _game = null;
                    _viewNewGameConsole.BackToMainMenu();
                    break;

                }
                if (_game != null)
                {
                    if (_game.GameState == GameState.Running)
                    {
                        switch (keyPressed.Key)
                        {
                            case ConsoleKey.UpArrow:
                                command = new MoveCommand(_game.Level, Direction.Up);
                                break;
                            case ConsoleKey.DownArrow:
                                command = new MoveCommand(_game.Level, Direction.Down);
                                break;
                            case ConsoleKey.LeftArrow:
                                command = new MoveCommand(_game.Level, Direction.Left);
                                break;
                            case ConsoleKey.RightArrow:
                                command = new MoveCommand(_game.Level, Direction.Right);
                                break;
                            case ConsoleKey.Z:
                                if (keyPressed.Modifiers == ConsoleModifiers.Control)
                                {
                                    ViewNewGameBase.CommandManager.Undo();
                                    _viewNewGameConsole.Reedraw();
                                }
                                break;
                            case ConsoleKey.I:
                                if (keyPressed.Modifiers == ConsoleModifiers.Control)
                                {
                                    LevelPlayedUtils = new(false);
                                    ViewNewGameBase.FirstStartLevel = true;
                                    ViewNewGameBase.ProcessDrawGameLevel();
                                }
                                break;
                            case ConsoleKey.N:
                                if (keyPressed.Modifiers == ConsoleModifiers.Control)
                                {
                                    var nextLevel = _game.Level.LevelNumber + 1;
                                    if (LevelPlayedUtils.LevelPlayed.IsLevelPlayed(nextLevel))
                                    {
                                        ProcessNextLevel();
                                    }
                                    else
                                    {
                                        _viewNewGameConsole.PrintMessage(string
                                            .Format("The level {0} is not been played or the current level is the " +
                                            "last game's level", nextLevel + 1));
                                    }
                                }
                                break;
                            case ConsoleKey.P:
                                if (keyPressed.Modifiers == ConsoleModifiers.Control)
                                {
                                    var previousLevel = _game.Level.LevelNumber - 1;
                                    if (LevelPlayedUtils.LevelPlayed.IsLevelPlayed(previousLevel))
                                    {
                                        ProcessPreviousLevel();
                                    }
                                    else
                                    {
                                        _viewNewGameConsole.PrintMessage(" The current level is the first game's level !");
                                    }
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (_game.GameState)
                        {
                            case GameState.LevelCompleted:
                                if (keyPressed.Key != ConsoleKey.Escape)
                                {
                                    UpdateRecord(_game.Level.LevelNumber, _game.Level.Actor.MoveCount);
                                    if (RecordUtils.NewRecordHasBeenSet)
                                    {
                                        ViewNewGameBase.PrintMessage("New Record has been set");
                                        Thread.Sleep(1000);
                                    }
                                    ProcessNextLevel();
                                    LevelPlayedUtils.UpdateLevelPlayed(_game.Level.LevelNumber);
                                }
                                break;
                        }
                    }

                }
                if (command != null)
                {
                    ViewNewGameBase.CommandManager.Execute(command);
                    _viewNewGameConsole.Reedraw();
                }
            }
        }

    }
}
