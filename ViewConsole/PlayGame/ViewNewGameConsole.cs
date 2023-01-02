using Model.PlayGame.Cells;
using ModelConsole.PlayGame.NewGame;
using System;
using System.Collections.Generic;
using View.PlayGame;
using ViewConsole.Menu;

namespace ViewConsole.PlayGame
{
    public class ViewNewGameConsole : ViewNewGameBase
    {
        private ViewMenuConsole _viewMenuConsole;
        private List<CellButtonLocation> _cellButtonLocations = new List<CellButtonLocation>();
        private GameConsole _game;
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
        public ViewNewGameConsole() : base()
        {
            _game = new GameConsole();
        }
        public override void PrintMessage(string parMessage)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft = Console.WindowWidth / 4;
            Console.CursorTop = Console.WindowHeight / 2;
            Console.Write(parMessage);
        }

        public void DrawGameLevel()
        {
            _cellButtonLocations.Clear();
            var rowCount = _game.Level.RowCount;
            var colCount = _game.Level.ColumnCount;
            if (rowCount <= _viewMenuConsole.HEIGHT && colCount <= _viewMenuConsole.WIDTH)
            {
                Console.Clear();
                var startLeft = (_viewMenuConsole.WIDTH - colCount) / 2;
                var startTop = (_viewMenuConsole.HEIGHT - rowCount) / 2;
                for (var row = 0; row < rowCount; row++)
                {
                    startTop++;
                    var left = startLeft;
                    for (var col = 0; col < colCount; col++)
                    {
                        left++;
                        //_cellButtonLocations.Add(new CellButtonLocation(left, startTop, row, col));
                        _cellButtonLocations.Add(new CellButtonLocation(row, col, row, col));
                        Cell cell = _game.Level[row, col];
                        /*SetLeftTopConsoleCursor(startTop, left);
                        DrawCell(cell);*/
                        DrawCell(cell, col, row);
                    }
                }
            }
            else
            {
                PrintMessage("Error!!!");
            }

        }
        public void Reedraw()
        {
            _cellButtonLocations.ForEach(c =>
            {
                Cell cell = Game.Level[c.X, c.Y];
                if (!cell.Name.Equals("Wall"))
                {
                    //SetLeftTopConsoleCursor(c.YMap, c.XMap);
                    //DrawCell(cell);
                    DrawCell(cell, c.YMap, c.XMap);
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
        public void SetLeftTopConsoleCursor(int parRow, int parCol)
        {
            Console.CursorLeft = parCol;
            Console.CursorTop = parRow;
        }
        public void BackToMainMenu()
        {
            _viewMenuConsole.Draw();
        }

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
