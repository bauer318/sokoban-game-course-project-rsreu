using Controller.PlayGame;
using Model.PlayGame.Cells;
using Model.PlayGame.Commands;
using Model.PlayGame.Levels;
using Model.PlayGame.Locations;
using Model.PlayGame.NewGame;
using ModelConsole.PlayGame.NewGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using View.PlayGame;
using ViewConsole.PlayGame;

namespace ControllerConsole.PlayGame
{
    public class ControllerPlayGameConsole:ControllerPlayGame
    {
        private ViewNewGameConsole _viewNewGameConsole;
        private GameConsole _game;
        private int[,] map = { 
            {1,2,2,2,3,3,3,3,3 },
            {3,2,2,2,4,5,2,2,3 },
            {3,2,4,2,2,3,2,5,3 },
            {3,3,3,3,3,3,3,3,3 } };
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
        public ControllerPlayGameConsole(ViewNewGameBase parViewNewGameBase):base(parViewNewGameBase)
        {
            _game = new GameConsole();
            _viewNewGameConsole = parViewNewGameBase as ViewNewGameConsole;
            ProcessDrawGameLevel();
            //TryToStartFirstLevel();
            //_viewNewGameConsole.InitCellButtonLocation(map.GetLength(0),map.GetLength(1));
            /*SetCellButtonStyle();
            Thread.Sleep(1000);
            map[0, 0] = 2;
            map[0, 1] = 1;
            SetCellButtonStyle();
            Thread.Sleep(1000);
            map[0, 1] = 2;
            map[1, 1] = 1;
            SetCellButtonStyle();
            Thread.Sleep(1000);
            map[1, 1] = 2;
            map[1, 2] = 1;
            SetCellButtonStyle();
            Thread.Sleep(1000);
            map[1, 2] = 2;
            map[1, 3] = 1;
            SetCellButtonStyle();
            Thread.Sleep(1000);
            map[1, 3] = 2;
            map[1, 4] = 1;
            map[1, 5] = 4;
            SetCellButtonStyle();*/
        }

        public override void ProcessDrawGameLevel()
        {
            CommandManager.Clear();
            if (ViewNewGameBase.FirstStartLevel)
            {
                TryToStartFirstLevel();
                //ViewMenuMainWPF.MainWindow.KeyDown += new KeyEventHandler(Controll_KeyDown);
                //_viewNewGameWPF.SetApplicationResourceDictionary(_resourceDictionary);
            }
            //_viewNewGameWPF.DrawGameLevel(Game.Level.RowCount, Game.Level.ColumnCount);
            _viewNewGameConsole.InitCellButtonLocation(Game.Level.RowCount, Game.Level.ColumnCount);
            SetCellButtonStyle();
            Controll_KeyDown();
            //ViewMenuMainWPF.MainWindow.Content = _viewNewGameWPF.DockPanel;
        }
        private void Controll_KeyDown()
        {
            bool isRunning = true;
            while (isRunning)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                CommandBase command = null;
                if (Game != null)
                {
                    Level level = Game.Level;
                    if (Game.GameState == GameState.Running)
                    {
                        switch (keyPressed.Key)
                        {
                            case ConsoleKey.UpArrow:
                                command = new MoveCommand(level, Direction.Up);
                                break;
                            case ConsoleKey.DownArrow:
                                command = new MoveCommand(level, Direction.Down);
                                break;
                            case ConsoleKey.LeftArrow:
                                command = new MoveCommand(level, Direction.Left);
                                break;
                            case ConsoleKey.RightArrow:
                                command = new MoveCommand(level, Direction.Right);
                                break;
                            case ConsoleKey.Z:
                                if (keyPressed.Modifiers == ConsoleModifiers.Control)
                                {
                                    CommandManager.Undo();
                                    SetCellButtonStyle();
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
                                //RemoveKeyDownEventHandler();
                                _viewNewGameConsole.BackToMainMenu();
                                isRunning = false;
                                break;
                            case GameState.LevelCompleted:
                                if (keyPressed.Key != ConsoleKey.Escape)
                                {
                                    Game.GotoNextLevel();
                                    ViewNewGameBase.FirstStartLevel = false;
                                    ProcessDrawGameLevel();
                                }
                                break;
                        }
                    }
                    if (keyPressed.Key == ConsoleKey.Escape)
                    {
                        ViewNewGameBase.FirstStartLevel = true;
                        _viewNewGameConsole.BackToMainMenu();
                        isRunning = false;
                        //RemoveKeyDownEventHandler();
                    }
                }
                if (command != null)
                {
                    CommandManager.Execute(command);
                    SetCellButtonStyle();
                }
            }
        }
        public override void SetCellButtonStyle()
        {
            _viewNewGameConsole.CellButtonLocations.ForEach(c => 
            {
                Cell cell = Game.Level[c.X, c.Y];
                CellContents cellContents = cell.CellContents;
                _viewNewGameConsole.SetLeftTopConsoleCursor(c.YMap, c.XMap);
                switch (cell.Name)
                {
                    case ("Wall"):
                        _viewNewGameConsole.DrawWall();
                        break;
                    case ("Floor"):
                        if (cellContents != null)
                        {
                            switch (cellContents.Name)
                            {
                                case ("Treasure"):
                                    //Draw Treasure on floor $
                                    _viewNewGameConsole.DrawTreasureOnFloor();
                                    break;
                                case ("Actor"):
                                    //Draw Actor on floor @
                                    _viewNewGameConsole.DrawActorOnFloor();
                                    break;
                            }
                        }
                        else
                        {
                            _viewNewGameConsole.DrawEmptyFloor();
                        }
                        break;
                    case ("Space"):
                        _viewNewGameConsole.DrawSpace();
                        break;
                    case ("Goal"):
                        if(cellContents != null)
                        {
                            if (cellContents.Name.Equals("Treasure"))
                            {
                                _viewNewGameConsole.DrawTreasureOnGoal();
                            }
                        }
                        else
                        {
                            _viewNewGameConsole.DrawEmptyGoal();
                        }
                        break;
                }
            });
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
