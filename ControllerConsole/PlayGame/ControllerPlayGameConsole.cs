﻿using Controller.PlayGame;
using Model.PlayGame.Cells;
using Model.PlayGame.Commands;
using Model.PlayGame.Levels;
using Model.PlayGame.Locations;
using Model.PlayGame.NewGame;
using ModelConsole.PlayGame.NewGame;
using System;
using View.PlayGame;
using ViewConsole;
using ViewConsole.PlayGame;

namespace ControllerConsole.PlayGame
{
    public class ControllerPlayGameConsole : ControllerPlayGame
    {
        private ViewNewGameConsole _viewNewGameConsole;
        private GameConsole _game;
        private Level _level;
        public GameConsole Game
        {
            get
            {
                return _game;
            }
            set
            {
                _game = value;
            }
        }
        public ControllerPlayGameConsole(ViewNewGameBase parViewNewGameBase) : base(parViewNewGameBase)
        {
            _game = new GameConsole();
            _viewNewGameConsole = parViewNewGameBase as ViewNewGameConsole;
            ProcessDrawGameLevel();
        }

        public override void ProcessDrawGameLevel()
        {
            CommandManager.Clear();
            if (ViewNewGameBase.FirstStartLevel)
            {
                TryToStartFirstLevel();
            }
            _viewNewGameConsole.InitCellButtonLocation(Game.Level.RowCount, Game.Level.ColumnCount);
            SetCellButtonStyle();
            if (ViewNewGameBase.FirstStartLevel)
            {
                Controll_KeyDown();
            }
        }
        private void Controll_KeyDown()
        {
            while (true)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                CommandBase command = null;
                if (keyPressed.Key == ConsoleKey.Escape || Game.GameState == GameState.GameOver)
                {
                    if (Game.GameState == GameState.GameOver)
                    {
                        UpdateRecord(_level.LevelNumber, _level.Actor.MoveCount);
                    }
                    ViewNewGameBase.FirstStartLevel = true;
                    _game = null;
                    _viewNewGameConsole.BackToMainMenu();
                    break;

                }
                if (Game != null)
                {
                    _level = Game.Level;
                    if (Game.GameState == GameState.Running)
                    {
                        switch (keyPressed.Key)
                        {
                            case ConsoleKey.UpArrow:
                                command = new MoveCommand(_level, Direction.Up);
                                break;
                            case ConsoleKey.DownArrow:
                                command = new MoveCommand(_level, Direction.Down);
                                break;
                            case ConsoleKey.LeftArrow:
                                command = new MoveCommand(_level, Direction.Left);
                                break;
                            case ConsoleKey.RightArrow:
                                command = new MoveCommand(_level, Direction.Right);
                                break;
                            case ConsoleKey.Z:
                                if (keyPressed.Modifiers == ConsoleModifiers.Control)
                                {
                                    CommandManager.Undo();
                                    Reedraw();
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (Game.GameState)
                        {
                            case GameState.LevelCompleted:
                                if (keyPressed.Key != ConsoleKey.Escape)
                                {
                                    UpdateRecord(_level.LevelNumber, _level.Actor.MoveCount);
                                    Game.GotoNextLevel();
                                    ViewNewGameBase.FirstStartLevel = false;
                                    ProcessDrawGameLevel();
                                }
                                break;
                        }
                    }

                }
                if (command != null)
                {
                    CommandManager.Execute(command);
                    Reedraw();
                }
            }
        }

        public override void SetCellButtonStyle()
        {
            _viewNewGameConsole.CellButtonLocations.ForEach(c =>
            {
                Cell cell = Game.Level[c.X, c.Y];
                _viewNewGameConsole.SetLeftTopConsoleCursor(c.YMap, c.XMap);
                DrawCell(cell);

            });
        }
        public void Reedraw()
        {
            _viewNewGameConsole.CellButtonLocations.ForEach(c =>
            {
                Cell cell = Game.Level[c.X, c.Y];
                if (!cell.Name.Equals("Wall"))
                {
                    _viewNewGameConsole.SetLeftTopConsoleCursor(c.YMap, c.XMap);
                    DrawCell(cell);
                }
            });
        }
        private void DrawCell(Cell parCell)
        {
            CellContents cellContents = parCell.CellContents;
            switch (parCell.Name)
            {
                case ("Wall"):
                    DrawCellUtils.DrawWall();
                    break;
                case ("Floor"):
                    if (cellContents != null)
                    {
                        switch (cellContents.Name)
                        {
                            case ("Treasure"):
                                DrawCellUtils.DrawTreasureOnFloor();
                                break;
                            case ("Actor"):
                                DrawCellUtils.DrawActorOnFloor();
                                break;
                        }
                    }
                    else
                    {
                        DrawCellUtils.DrawEmptyFloor();
                    }
                    break;
                case ("Space"):
                    DrawCellUtils.DrawSpace();
                    break;
                case ("Goal"):
                    if (cellContents != null)
                    {
                        if (cellContents.Name.Equals("Treasure"))
                        {
                            DrawCellUtils.DrawTreasureOnGoal();
                        }
                        else
                        {
                            DrawCellUtils.DrawActorOnFloor();
                        }
                    }
                    else
                    {
                        DrawCellUtils.DrawEmptyGoal();
                    }
                    break;
            }
        }
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
    }
}