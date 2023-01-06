using Model.PlayGame.Cells;
using ModelConsole.PlayGame.NewGame;
using System;
using System.Collections.Generic;
using System.Threading;
using View.PlayGame;
using ViewConsole.Menu;

namespace ViewConsole.PlayGame
{
    /// <summary>
    /// Representes the new game's view
    /// </summary>
    public class ViewNewGameConsole : ViewNewGameBase
    {
        /// <summary>
        /// The menu's view
        /// </summary>
        private ViewMenuConsole _viewMenuConsole;
        /// <summary>
        /// The List of current level's view cell with location
        /// </summary>
        private List<ViewCellLocation> _cellButtonLocations = new List<ViewCellLocation>();
        /// <summary>
        /// The sokoban's game
        /// </summary>
        private GameConsole _game;
        /// <summary>
        /// Get or Set the sokoban's game
        /// </summary>
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
        /// <summary>
        /// Get or Set the menu's view
        /// </summary>
        public ViewMenuConsole ViewMenuConsole
        {
            get
            {
                return _viewMenuConsole;
            }
            set
            {
                _viewMenuConsole = value;
            }
        }
        /// <summary>
        /// Default's contructor
        /// </summary>
        public ViewNewGameConsole() : base()
        {
            _game = new GameConsole();
        }
        /// <summary>
        /// Print a message
        /// </summary>
        /// <param name="parMessage">The message to print</param>
        public override void PrintMessage(string parMessage)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft = Console.WindowWidth / 4;
            Console.CursorTop = Console.WindowHeight / 2;
            Console.Write(parMessage);
        }
        /// <summary>
        /// Draw the current sokoban's game level
        /// </summary>
        public void DrawGameLevel()
        {
            Console.Clear();
            _cellButtonLocations.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            var rowCount = _game.Level.RowCount;
            var colCount = _game.Level.ColumnCount;
            if (rowCount <= _viewMenuConsole.HEIGHT && colCount <= _viewMenuConsole.WIDTH)
            {
                var pixelSize = Math.Min(_viewMenuConsole.HEIGHT, _viewMenuConsole.WIDTH) / Math.Max(rowCount, colCount);
                var startLeft = ((_viewMenuConsole.WIDTH - (colCount * pixelSize)) / 2);
                var startTop = ((_viewMenuConsole.HEIGHT - (rowCount * pixelSize)) / 2);
                /* if ((rowCount - 1) * pixelSize + startLeft >= _viewMenuConsole.WIDTH)
                 {
                     startLeft -= 6;
                     if (startLeft < 0)
                     {
                         startLeft = 0;
                     }
                 }
                 if ((colCount - 1) * pixelSize + startTop >= _viewMenuConsole.HEIGHT)
                 {
                     startTop -= 6;
                     if (startTop < 0)
                     {
                         startTop = 0;
                     }
                 }*/


                /*for (var row = 0; row < rowCount; row++)
                {
                    startTop++;
                    var left = startLeft;
                    for (var col = 0; col < colCount; col++)
                    {
                        left++;
                        _cellButtonLocations.Add(new ViewCellLocation(left, startTop, row, col));
                        Cell cell = _game.Level[row, col];
                        //SetLeftTopConsoleCursor(startTop, left);
                        //DrawCell(cell);
                        DrawCell(cell, left, startTop);
                    }
                }*/
                Thread t = new(() => 
                {
                    DrawCellUtils.Level = _game.Level;
                    DrawCellUtils.InitLevelField(colCount, rowCount, startLeft, startTop, pixelSize);
                    DrawCellUtils.Draw();
                });
                t.Start();
               
            }
            else
            {
                PrintMessage("Error!!!\n Incorrect row or column's level");
            }

        }
        /// <summary>
        /// Redraw the current game's level
        /// </summary>
        public void Reedraw()
        {
            _cellButtonLocations.ForEach(c =>
            {
                Cell cell = Game.Level[c.X, c.Y];
                if (!cell.Name.Equals("Wall"))
                {
                    /*SetLeftTopConsoleCursor(c.YMap, c.XMap);
                    DrawCell(cell);*/
                    DrawCell(cell, c.XMap, c.YMap);
                }
            });
        }
        /// <summary>
        /// Draw a level's cell
        /// </summary>
        /// <param name="parCell">The level's cell to draw</param>
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
        private void DrawCell(Cell parCell, int parX, int parY)
        {
            CellContents cellContents = parCell.CellContents;
            switch (parCell.Name)
            {
                case ("Wall"):
                    DrawCellUtils.DrawWall(parX, parY);
                    break;
                case ("Floor"):
                    if (cellContents != null)
                    {
                        switch (cellContents.Name)
                        {
                            case ("Treasure"):
                                DrawCellUtils.DrawTreasureOnFloor(parX, parY);
                                break;
                            case ("Actor"):
                                DrawCellUtils.DrawActorOnFloor(parX, parY);
                                break;
                        }
                    }
                    else
                    {
                        DrawCellUtils.DrawEmptyFloor(parX, parY);
                    }
                    break;
                case ("Space"):
                    DrawCellUtils.DrawSpace(parX, parY);
                    break;
                case ("Goal"):
                    if (cellContents != null)
                    {
                        if (cellContents.Name.Equals("Treasure"))
                        {
                            DrawCellUtils.DrawTreasureOnGoal(parX, parY);
                        }
                        else
                        {
                            DrawCellUtils.DrawActorOnFloor(parX, parY);
                        }
                    }
                    else
                    {
                        DrawCellUtils.DrawEmptyGoal(parX, parY);
                    }
                    break;
            }
        }
        /// <summary>
        /// Set the console cursor's left and top
        /// </summary>
        /// <param name="parRow">The row's number as the console cursor's top</param>
        /// <param name="parCol">The column's number as the console cursor's left</param>
        public void SetLeftTopConsoleCursor(int parRow, int parCol)
        {
            Console.CursorLeft = parCol;
            Console.CursorTop = parRow;
        }
        /// <summary>
        /// Back to main's menu
        /// </summary>
        public void BackToMainMenu()
        {
            _viewMenuConsole.Draw();
        }
        /// <summary>
        /// Try to load and start the first or last played level of the game.
        /// </summary>
        public override void TryToStartFirstLevel()
        {
            try
            {
                Game.Start();
            }
            catch (Exception ex)
            {
                PrintMessage("Problem loading game. " + ex.Message);
            }
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
            }
            DrawGameLevel();
        }
    }
}
