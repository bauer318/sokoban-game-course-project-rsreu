using System;
using static System.Console;

namespace ViewConsole
{
    /// <summary>
    /// Provides for drawing the level's cells
    /// </summary>
    public class DrawCellUtils
    {
        private static int _pixelSize = 3;
        private static ConsoleColor _savevBackgroundColor;
        private static ConsoleColor _savedForegroundColor;
        /// <summary>
        /// Saves the current Console's colors
        /// Background and Foreground
        /// </summary>
        public static void SaveColors()
        {
            _savevBackgroundColor = BackgroundColor;
            _savedForegroundColor = ForegroundColor;
        }
        /// <summary>
        /// Put back the console's saved colors
        /// </summary>
        public static void PutColorsBack()
        {
            BackgroundColor = _savevBackgroundColor;
            ForegroundColor = _savedForegroundColor;
        }
        /// <summary>
        /// Draw a Wall
        /// </summary>
        /// <param name="parX">The x coordinate</param>
        /// <param name="parY">The y coordinate</param>
        public static void DrawWall(int parX, int parY)
        {
            SaveColors();
            for (int x = 0; x < _pixelSize; x++)
            {
                for (int y = 0; y < _pixelSize; y++)
                {
                    SetCursorPosition(parX * _pixelSize + x, parY * _pixelSize + y);
                    DrawWall();
                }
            }
            PutColorsBack();
        }
        /// <summary>
        /// Draw an empty goal
        /// </summary>
        /// <param name="parX">The x coordinate</param>
        /// <param name="parY">The y coordinate</param>
        public static void DrawEmptyGoal(int parX, int parY)
        {
            for (int x = 0; x < _pixelSize; x++)
            {
                for (int y = 0; y < _pixelSize; y++)
                {
                    SaveColors();
                    SetCursorPosition(parX * _pixelSize + x, parY * _pixelSize + y);
                    if (x == 1 && y == 1)
                    {

                        DrawEmptyGoal();
                    }
                    else
                    {
                        SetLimitColors(ConsoleColor.Red, ConsoleColor.White);
                        if (x == 0 && y == 0)
                        {
                            DrawLeftTopLimit();
                        }
                        else if (x == 0 && y == 2)
                        {
                            DrawLeftDowLimit();
                        }
                        else if (x == 2 && y == 0)
                        {
                            DrawRightTopLimit();

                        }
                        else if (x == 2 && y == 2)
                        {
                            DrawRightDownLimit();
                        }
                        else
                        {
                            DrawSpace();
                        }

                    }
                    PutColorsBack();

                }
            }
        }
        /// <summary>
        /// Draw a Treasure on the goal
        /// </summary>
        /// <param name="parX">The x coordinate</param>
        /// <param name="parY">The y coordinate</param>
        public static void DrawTreasureOnGoal(int parX, int parY)
        {
            for (int x = 0; x < _pixelSize; x++)
            {
                for (int y = 0; y < _pixelSize; y++)
                {
                    SaveColors();
                    SetCursorPosition(parX * _pixelSize + x, parY * _pixelSize + y);
                    if (x == 1 && y == 1)
                    {

                        DrawTreasureOnFloor();
                    }
                    else
                    {
                        SetLimitColors(ConsoleColor.DarkRed, ConsoleColor.DarkGray);
                        if (x == 0 && y == 0)
                        {
                            DrawLeftTopLimit();
                        }
                        else if (x == 0 && y == 2)
                        {
                            DrawLeftDowLimit();
                        }
                        else if (x == 2 && y == 0)
                        {
                            DrawRightTopLimit();

                        }
                        else if (x == 2 && y == 2)
                        {
                            DrawRightDownLimit();
                        }
                        else
                        {
                            PutColorsBack();
                            DrawSpace();
                        }

                    }
                    PutColorsBack();

                }
            }
        }
        /// <summary>
        /// Draw an empty floor - actor's road
        /// </summary>
        /// <param name="parX">The x coordinate</param>
        /// <param name="parY">The y coordinate</param>
        public static void DrawEmptyFloor(int parX, int parY)
        {
            SaveColors();
            for (int x = 0; x < _pixelSize; x++)
            {
                for (int y = 0; y < _pixelSize; y++)
                {
                    SetCursorPosition(parX * _pixelSize + x, parY * _pixelSize + y);
                    DrawEmptyFloor();
                }
            }
            PutColorsBack();
        }
        /// <summary>
        /// Draw a Treasure on floor
        /// </summary>
        /// <param name="parX">The x coordinate</param>
        /// <param name="parY">The y coordinate</param>
        public static void DrawTreasureOnFloor(int parX, int parY)
        {
            for (int x = 0; x < _pixelSize; x++)
            {
                for (int y = 0; y < _pixelSize; y++)
                {
                    SaveColors();
                    SetCursorPosition(parX * _pixelSize + x, parY * _pixelSize + y);
                    if (x == 1 && y == 1)
                    {

                        DrawTreasureOnFloor();
                    }
                    else
                    {
                        SetLimitColors(ConsoleColor.White, ConsoleColor.Black);
                        if (x == 0 && y == 0)
                        {
                            DrawLeftTopLimit();
                        }
                        else if (x == 0 && y == 2)
                        {
                            DrawLeftDowLimit();
                        }
                        else if (x == 2 && y == 0)
                        {
                            DrawRightTopLimit();
                            
                        }else if(x==2 && y == 2)
                        {
                            DrawRightDownLimit();
                        }
                        else
                        {
                            PutColorsBack();
                            DrawSpace();
                        }
                        
                    }
                    PutColorsBack();

                }
            }
        }
        /// <summary>
        /// Draw the actor on floor
        /// </summary>
        /// <param name="parX">The x coordinate</param>
        /// <param name="parY">The y coordinate</param>
        public static void DrawActorOnFloor(int parX, int parY)
        {
            for (int x = 0; x < _pixelSize; x++)
            {
                for (int y = 0; y < _pixelSize; y++)
                {
                    SaveColors();
                    SetCursorPosition(parX * _pixelSize + x, parY * _pixelSize + y);
                    if (x == 1 && y == 1)
                    {

                        DrawActorOnFloor();
                    }
                    else
                    {
                        SetLimitColors(ConsoleColor.Green, ConsoleColor.White);
                        if (x == 0 && y == 0)
                        {
                            DrawLeftTopLimit();
                        }
                        else if (x == 0 && y == 2)
                        {
                            DrawLeftDowLimit();
                        }
                        else if (x == 2 && y == 0)
                        {
                            DrawRightTopLimit();

                        }
                        else if (x == 2 && y == 2)
                        {
                            DrawRightDownLimit();
                        }
                        else
                        {
                            DrawSpace();
                        }

                    }
                    PutColorsBack();

                }
            }
        }
        /// <summary>
        /// Draw the space
        /// </summary>
        /// <param name="parX">The x coordinate</param>
        /// <param name="parY">The y coordinate</param>
        public static void DrawSpace(int parX, int parY)
        {
            SaveColors();
            for (int x = 0; x < _pixelSize; x++)
            {
                for (int y = 0; y < _pixelSize; y++)
                {
                    SetCursorPosition(parX * _pixelSize + x, parY * _pixelSize + y);
                    DrawSpace();

                }
            }
            PutColorsBack();
        }
        /// <summary>
        /// Draw a Wall
        /// </summary>
        public static void DrawWall()
        {
            ForegroundColor = ConsoleColor.DarkCyan;
            Write('█');
            ForegroundColor = ConsoleColor.Black;
        }
        /// <summary>
        /// Draw an empty goal
        /// </summary>
        public static void DrawEmptyGoal()
        {
            ForegroundColor = ConsoleColor.Red;
            Write("*");
            BackgroundColor = ConsoleColor.Black;
            ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Draw empty floor
        /// </summary>
        public static void DrawEmptyFloor()
        {
            ForegroundColor = ConsoleColor.White;
            Write(".");
        }
        /// <summary>
        /// Draw a treasure on floor
        /// </summary>
        public static void DrawTreasureOnFloor()
        {
            ForegroundColor = ConsoleColor.Yellow;
            Write("#");
            BackgroundColor = ConsoleColor.Black;
            ForegroundColor = ConsoleColor.Yellow;
        }
        /// <summary>
        /// Draw the actor on floor
        /// </summary>
        public static void DrawActorOnFloor()
        {
            ForegroundColor = ConsoleColor.White;
            Write("@");
            ForegroundColor = ConsoleColor.Black;
        }
        /// <summary>
        /// Draw the space
        /// </summary>
        public static void DrawSpace()
        {
            BackgroundColor = ConsoleColor.Gray;
            Write(" ");
        }
        /// <summary>
        /// Draw the left top limit as a corner
        /// </summary>
        public static void DrawLeftTopLimit()
        {
            Write("┌");
        }
        /// <summary>
        /// Draw the left down limit as a corner
        /// </summary>
        public static void DrawLeftDowLimit()
        {
            Write("└");
        }
        /// <summary>
        /// Draw the right top limit as a corner
        /// </summary>
        public static void DrawRightTopLimit()
        {
            Write("┐");
        }
        /// <summary>
        /// Draw the right down limit as corner
        /// </summary>
        public static void DrawRightDownLimit()
        {
            Write("┘");
        }
        /// <summary>
        /// Set the limit's color
        /// </summary>
        /// <param name="parBackgroundColor">The limit's background color</param>
        /// <param name="parForegroundColor">The limit's foreground color</param>
        private static void SetLimitColors(ConsoleColor parBackgroundColor, ConsoleColor parForegroundColor)
        {
            ForegroundColor = parForegroundColor;
            BackgroundColor = parBackgroundColor;
        }

    }
}
