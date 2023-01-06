using Model.PlayGame.Cells;
using Model.PlayGame.Cells.Actors;
using ModelConsole.PlayGame.NewGame;
using System;
using System.Collections.Generic;
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
        private object _drawCellLock = new();
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
            var rowCount = _game.Level.RowCount;
            var colCount = _game.Level.ColumnCount;
            if (rowCount <= _viewMenuConsole.HEIGHT && colCount <= _viewMenuConsole.WIDTH)
            {
                var pixelSize = 3;
                var startLeft = (_viewMenuConsole.WIDTH - colCount * pixelSize) / 6;
                var startTop = (_viewMenuConsole.HEIGHT - rowCount * pixelSize) / 6;
                
                for (var row = 0; row < rowCount; row++)
                {
                    var top = startTop + row;
                    for (var col = 0; col < colCount; col++)
                    {
                        var left = startLeft + col;
                        _cellButtonLocations.Add(new ViewCellLocation(row, col, top, left));
                        DrawCell(_game.Level[row, col], left, top);
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
        public void ReedrawForUndo()
        {
            Parallel.ForEach(_cellButtonLocations, c =>
            {
                Cell cell = Game.Level[c.X, c.Y];
                if (!cell.Name.Equals("Wall"))
                {
                    DrawCell(cell, c.YMap, c.XMap);
                }
            });
        }
        /// <summary>
        /// Redraw the actor's cell and those who arround him
        /// </summary>
        public void Reedraw()
        {
            Actor actor = _game.Level.Actor;
            var actorX = actor.Location.RowNumber;
            var actorY = actor.Location.ColumnNumber;
            Parallel.ForEach(_cellButtonLocations, c =>
            {
                Cell cell = Game.Level[c.X, c.Y];
                if (!cell.Name.Equals("Wall"))
                {
                    if ((c.X <= actorX + 1 && c.X >= actorX - 1) && (c.Y <= actorY + 1 && c.Y >= actorY - 1))
                    {
                        DrawCell(cell, c.YMap, c.XMap);
                    }

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
            lock (_drawCellLock)
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
