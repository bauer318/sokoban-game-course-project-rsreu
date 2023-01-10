using Model.PlayGame.Cells;
using ModelConsole.PlayGame.NewGame;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
        /// The pixel's size
        /// </summary>
        private int _pixelSize;
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
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.CursorLeft = Console.WindowWidth / 4;
            Console.CursorTop = Console.WindowHeight / 2;
            Console.Write(parMessage);
            Thread.Sleep(3000);
        }
        /// <summary>
        /// Draw the current sokoban's game level
        /// </summary>
        public void DrawGameLevel()
        {

            Console.Clear();
            _cellButtonLocations.Clear();
            var rowCount = _game.Level.RowCount;
            var colCount = _game.Level.ColumnCount;
            if (rowCount <= _viewMenuConsole.HEIGHT && colCount <= _viewMenuConsole.WIDTH)
            {

                _pixelSize = 3;
                if (_pixelSize * rowCount > _viewMenuConsole.HEIGHT ||
                    _pixelSize * colCount > _viewMenuConsole.WIDTH)
                {
                    PrintMessage("The game's level may not be displayed on your screen because the dimensions are small");
                }
                else
                {
                    var startLeft = (_viewMenuConsole.WIDTH - colCount * _pixelSize) / 2;
                    var startTop = (_viewMenuConsole.HEIGHT - rowCount * _pixelSize) / 2;
                    if (startLeft < 0)
                    {
                        startLeft = 0;
                    }
                    if (startTop < 0)
                    {
                        startTop = 0;
                    }

                    for (var row = 0; row < rowCount; row++)
                    {
                        for (var col = 0; col < colCount; col++)
                        {
                            _cellButtonLocations.Add(new ViewCellLocation(row, col, col * _pixelSize + startLeft, row * _pixelSize + startTop));
                            DrawCell(_game.Level[row, col], col * _pixelSize + startLeft, row * _pixelSize + startTop);
                        }
                    }
                }
            }
            else
            {
                PrintMessage("Error!!! Level's dimension must be less or equal Console's Window dimension");
            }


        }
        /// <summary>
        /// Redraw the current game's level
        /// </summary>
        public void Reedraw()
        {
            Parallel.ForEach(_cellButtonLocations, c =>
            {
                Cell cell = Game.Level[c.X, c.Y];
                if (!cell.Name.Equals("Wall"))
                {
                    DrawCell(cell, c.XMap, c.YMap);
                }
            });
        }

        /// <summary>
        /// Draw the level's cell
        /// </summary>
        /// <param name="parCell">The level's cell to be drawn</param>
        /// <param name="parX">The x coordinate as the cursor's top</param>
        /// <param name="parY">The y coordinate as the cursor's left</param>
        private void DrawCell(Cell parCell, int parX, int parY)
        {
            ConsoleFastOutput consoleFastOutput = ConsoleOutput.GetInstance().GetConsoleFastOutput();
            CellContents cellContents = parCell.CellContents;
            switch (parCell.Name)
            {
                case ("Wall"):
                    consoleFastOutput.DrawWall(
                        Convert.ToInt16(parX),
                        Convert.ToInt16(parY),
                        Convert.ToInt16(_pixelSize));
                    break;
                case ("Floor"):
                    if (cellContents != null)
                    {
                        switch (cellContents.Name)
                        {
                            case ("Treasure"):
                                consoleFastOutput.DrawTreasureOnFloor(
                                    Convert.ToInt16(parX),
                                    Convert.ToInt16(parY),
                                    Convert.ToInt16(_pixelSize));
                                break;
                            case ("Actor"):
                                consoleFastOutput.DrawActorOnFloor(
                                    Convert.ToInt16(parX),
                                    Convert.ToInt16(parY),
                                    Convert.ToInt16(_pixelSize)); break;
                        }
                    }
                    else
                    {
                        consoleFastOutput.DrawEmptyFloor(
                                    Convert.ToInt16(parX),
                                    Convert.ToInt16(parY),
                                    Convert.ToInt16(_pixelSize));
                    }
                    break;
                case ("Space"):
                    consoleFastOutput.DrawSpace(
                                    Convert.ToInt16(parX),
                                    Convert.ToInt16(parY),
                                    Convert.ToInt16(_pixelSize));
                    break;
                case ("Goal"):
                    if (cellContents != null)
                    {
                        if (cellContents.Name.Equals("Treasure"))
                        {
                            consoleFastOutput.DrawTreasureOnGoal(
                                    Convert.ToInt16(parX),
                                    Convert.ToInt16(parY),
                                    Convert.ToInt16(_pixelSize));
                        }
                        else
                        {
                            consoleFastOutput.DrawActorOnFloor(
                                    Convert.ToInt16(parX),
                                    Convert.ToInt16(parY),
                                    Convert.ToInt16(_pixelSize));
                        }
                    }
                    else
                    {
                        consoleFastOutput.DrawEmptyGoalOnFloor(
                                    Convert.ToInt16(parX),
                                    Convert.ToInt16(parY),
                                    Convert.ToInt16(_pixelSize));
                    }
                    break;
            }
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
