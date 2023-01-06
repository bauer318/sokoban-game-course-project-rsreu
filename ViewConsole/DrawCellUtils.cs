using System;
using static System.Console;

namespace ViewConsole
{
    /// <summary>
    /// Provides for drawing the level's cells
    /// </summary>
    public class DrawCellUtils
    {
        private static int pixelSize = 3;
        private static ConsoleColor savevBackgroundColor;
        private static ConsoleColor savedForegroundColor;

        private static void SaveColors()
        {
            savevBackgroundColor = BackgroundColor;
            savedForegroundColor = ForegroundColor;
        }
        private static void PutColorsBack()
        {
            BackgroundColor = savevBackgroundColor;
            ForegroundColor = savedForegroundColor;
        }
        public static void DrawWall(int parX, int parY)
        {
            SaveColors();
            for (int x = 0; x < pixelSize; x++)
            {
                for (int y = 0; y < pixelSize; y++)
                {
                    SetCursorPosition(parX * pixelSize + x, parY * pixelSize + y);
                    DrawWall();
                }
            }
            PutColorsBack();
        }
        public static void DrawTreasure(int parX, int parY)
        {
            SaveColors();
            for (int x = 0; x < pixelSize; x++)
            {
                for (int y = 0; y < pixelSize; y++)
                {
                    SetCursorPosition(parX * pixelSize + x, parY * pixelSize + y);
                    DrawTreasure();
                }
            }
            PutColorsBack();
        }
        public static void DrawEmptyGoal(int parX, int parY)
        {
            for (int x = 0; x < pixelSize; x++)
            {
                for (int y = 0; y < pixelSize; y++)
                {
                    SaveColors();
                    SetCursorPosition(parX * pixelSize + x, parY * pixelSize + y);
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
        public static void DrawTreasureOnGoal(int parX, int parY)
        {
            for (int x = 0; x < pixelSize; x++)
            {
                for (int y = 0; y < pixelSize; y++)
                {
                    SaveColors();
                    SetCursorPosition(parX * pixelSize + x, parY * pixelSize + y);
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
        public static void DrawEmptyFloor(int parX, int parY)
        {
            SaveColors();
            for (int x = 0; x < pixelSize; x++)
            {
                for (int y = 0; y < pixelSize; y++)
                {
                    SetCursorPosition(parX * pixelSize + x, parY * pixelSize + y);
                    DrawEmptyFloor();
                }
            }
            PutColorsBack();
        }
        public static void DrawTreasureOnFloor(int parX, int parY)
        {
            for (int x = 0; x < pixelSize; x++)
            {
                for (int y = 0; y < pixelSize; y++)
                {
                    SaveColors();
                    SetCursorPosition(parX * pixelSize + x, parY * pixelSize + y);
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
        public static void DrawActorOnFloor(int parX, int parY)
        {
            for (int x = 0; x < pixelSize; x++)
            {
                for (int y = 0; y < pixelSize; y++)
                {
                    SaveColors();
                    SetCursorPosition(parX * pixelSize + x, parY * pixelSize + y);
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
        public static void DrawSpace(int parX, int parY)
        {
            SaveColors();
            for (int x = 0; x < pixelSize; x++)
            {
                for (int y = 0; y < pixelSize; y++)
                {
                    SetCursorPosition(parX * pixelSize + x, parY * pixelSize + y);
                    DrawSpace();

                }
            }
            PutColorsBack();
        }
        public static void DrawWall()
        {
            ForegroundColor = ConsoleColor.DarkCyan;
            Write('█');
            ForegroundColor = ConsoleColor.Black;
        }
        public static void DrawTreasure()
        {
            ForegroundColor = ConsoleColor.Yellow;
            Write("█");
            ForegroundColor = ConsoleColor.Black;
        }
        public static void DrawEmptyGoal()
        {
            ForegroundColor = ConsoleColor.Red;
            Write("*");
            BackgroundColor = ConsoleColor.Black;
            ForegroundColor = ConsoleColor.White;
        }
        public static void DrawTreasureOnGoal()
        {
            ForegroundColor = ConsoleColor.Red;
            Write("█");
            BackgroundColor = ConsoleColor.Black;
        }
        public static void DrawEmptyFloor()
        {
            ForegroundColor = ConsoleColor.White;
            Write(".");
        }
        public static void DrawTreasureOnFloor()
        {
            ForegroundColor = ConsoleColor.Yellow;
            Write("#");
            BackgroundColor = ConsoleColor.Black;
            ForegroundColor = ConsoleColor.Yellow;
        }
        public static void DrawActorOnFloor()
        {
            ForegroundColor = ConsoleColor.White;
            Write("@");
            ForegroundColor = ConsoleColor.Black;
        }
        public static void DrawSpace()
        {
            BackgroundColor = ConsoleColor.Gray;
            Write(" ");
        }
        private static void DrawSpace(ConsoleColor parBackgroundColor)
        {
            BackgroundColor = parBackgroundColor;
            Write(" ");
        }
        public static void DrawLeftTopLimit()
        {
            Write("┌");
        }
        public static void DrawLeftDowLimit()
        {
            Write("└");
        }
        public static void DrawRightTopLimit()
        {
            Write("┐");
        }
        public static void DrawRightDownLimit()
        {
            Write("┘");
        }
        private static void SetLimitColors(ConsoleColor parBackgroundColor, ConsoleColor parForegroundColor)
        {
            ForegroundColor = parForegroundColor;
            BackgroundColor = parBackgroundColor;
        }

    }
}
