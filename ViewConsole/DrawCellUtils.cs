using Model.PlayGame.Cells;
using Model.PlayGame.Levels;
using Model.PlayGame.Locations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ViewConsole
{
    /// <summary>
    /// Provides for drawing the level's cells
    /// </summary>
    public class DrawCellUtils
    {
        private static int pixelSize = 3;
        private static List<Box> listBox = new List<Box>();
        private static int threadNumber = 0;
        public static Level Level;

        public static Box[,] InitLevelField(int parRowCount, int parColCount, int parLeft, int parTop, int parPixelSize)
        {
            threadNumber = Math.Max(parRowCount, parColCount);
            Box[,] playField = new Box[parRowCount, parColCount];
            ConsoleColor color = ConsoleColor.Gray;
            char symbol = '\u2588';
            for (int i = 0; i < playField.GetLength(0); i++)
            {
                for (int j = 0; j < playField.GetLength(1); j++)
                {
                    Cell cell = Level[new Location(j, i)];
                    string boxName = null;
                    switch (cell.Name)
                    {
                        case ("Wall"):
                            boxName = "Wall";
                            color = ConsoleColor.Cyan;
                            break;
                        case ("Floor"):
                            if(cell.CellContents != null)
                            {
                                switch (cell.CellContents.Name)
                                {
                                    case ("Treasure"):
                                        boxName = "TreasureOnFloor";
                                        color = ConsoleColor.Yellow;
                                        symbol = '#';
                                        break;
                                    case ("Actor"):
                                        boxName = "ActorOnFloor";
                                        color = ConsoleColor.Blue;
                                        symbol = '\u2592';
                                        break;
                                }
                            }
                            else
                            {
                                boxName = "EmptyFloor";
                                color = ConsoleColor.Black;
                            }
                            break;
                        case ("Space"):
                            boxName = "Space";
                            color = ConsoleColor.Gray;
                            break;
                        case ("Goal"):
                            if(cell.CellContents != null)
                            {
                                if (cell.CellContents.Name.Equals("Treasure"))
                                {
                                    boxName = "TreasureOnGoal";
                                    color = ConsoleColor.Red;
                                    symbol = '\u2593';
                                }
                                else
                                {
                                    boxName = "ActorOnFloor";
                                    color = ConsoleColor.Blue;
                                    symbol = '\u2592';
                                }
                            }
                            else
                            {
                                boxName = "EmptyGoal";
                                color = ConsoleColor.Red;
                                symbol = '\u2591';
                            }
                            break;
                    }
                    playField[i, j] = new Box(i * parPixelSize + parLeft, j * parPixelSize + parTop,color, i,j,boxName);
                    playField[i, j].InitBox(symbol);
                    listBox.Add(playField[i, j]);
                }
            }
            return playField;
        }
        public static void Draw()
        {
            foreach(Box b in listBox)
            {
                b.DrawBox();
            }
        }
        /// <summary>
        /// Draw a Wall
        /// </summary>
        public static void DrawWall()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.Write("█");
            Console.Write('\u2588');
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void DrawWall(int parX, int parY)
        {
            for (var i = 0; i < pixelSize; i++)
            {
                for (var j = 0; j < pixelSize; j++)
                {
                    Console.SetCursorPosition(parX + i, parY + j);
                    DrawWall();
                }
            }
        }
        /// <summary>
        /// Draw a enpty goal - a goal without treasure
        /// </summary>
        public static void DrawEmptyGoal()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            //Console.Write(".");
            Console.Write('\u2588');
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        public static void DrawEmptyGoal(int parX, int parY)
        {
            for (var i = 0; i < pixelSize; i++)
            {
                for (var j = 0; j < pixelSize; j++)
                {
                    Console.SetCursorPosition(parX + i, parY + j);
                    DrawEmptyGoal();
                }
            }
        }
        /// <summary>
        /// Draw a Treasure on Goal
        /// </summary>
        public static void DrawTreasureOnGoal()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.BackgroundColor = ConsoleColor.Gray;
        }
        public static void DrawTreasureOnGoal(int parX, int parY)
        {
            for (var i = 0; i < pixelSize; i++)
            {
                for (var j = 0; j < pixelSize; j++)
                {
                    Console.SetCursorPosition(parX + i, parY + j);
                    DrawTreasureOnGoal();
                }
            }
        }
        /// <summary>
        /// Draw a empty floor - where the actor can move
        /// </summary>
        public static void DrawEmptyFloor()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(".");
        }
        public static void DrawEmptyFloor(int parX, int parY)
        {
            for (var i = 0; i < pixelSize; i++)
            {
                for (var j = 0; j < pixelSize; j++)
                {
                    Console.SetCursorPosition(parX + i, parY + j);
                    DrawEmptyFloor();
                }
            }
        }
        /// <summary>
        /// Draw a Treasure on floor - initial's position
        /// </summary>
        public static void DrawTreasureOnFloor()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("#");
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        public static void DrawTreasureOnFloor(int parX, int parY)
        {
            for (var i = 0; i < pixelSize; i++)
            {
                for (var j = 0; j < pixelSize; j++)
                {
                    Console.SetCursorPosition(parX + i, parY + j);
                    DrawTreasureOnFloor();
                }
            }
        }
        /// <summary>
        /// Draw an actor on floor
        /// </summary>
        public static void DrawActorOnFloor()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        public static void DrawActorOnFloor(int parX, int parY)
        {
            for (var i = 0; i < pixelSize; i++)
            {
                for (var j = 0; j < pixelSize; j++)
                {
                    Console.SetCursorPosition(parX + i, parY + j);
                    DrawActorOnFloor();
                }
            }
        }
        /// <summary>
        /// Draw the space
        /// </summary>
        public static void DrawSpace()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write(" ");
        }
        public static void DrawSpace(int parX, int parY)
        {
            for (var i = 0; i < pixelSize; i++)
            {
                for (var j = 0; j < pixelSize; j++)
                {
                    Console.SetCursorPosition(parX + i, parY + j);
                    DrawSpace();
                }
            }
        }

    }
}
