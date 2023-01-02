using System;
using static System.Console;
namespace ViewConsole
{
    public class DrawCellUtils
    {
        public static int pixelSize = 3;
        public static void DrawWall(int parX, int parY)
        {
            for (int x = 0; x < pixelSize; x++)
            {
                for (int y = 0; y < pixelSize; y++)
                {
                    SetCursorPosition(parX * pixelSize + x, parY * pixelSize + y);
                    DrawWall();
                }
            }
        }
        public static void DrawTreasure(int parX, int parY)
        {
            for (int x = 0; x < pixelSize; x++)
            {
                for (int y = 0; y < pixelSize; y++)
                {
                    SetCursorPosition(parX * pixelSize + x, parY * pixelSize + y);
                    DrawTreasure();
                }
            }
        }
        public static void DrawEmptyGoal(int parX, int parY)
        {
            for (int x = 0; x < pixelSize; x++)
            {
                for (int y = 0; y < pixelSize; y++)
                {

                    SetCursorPosition(parX * pixelSize + x, parY * pixelSize + y);
                    if(x==1 && y == 1)
                    {
                        DrawSpace();
                    }
                    else
                    {
                        DrawEmptyGoal();
                    }
                }
            }
        }
        public static void DrawTreasureOnGoal(int parX, int parY)
        {
            for (int x = 0; x < pixelSize; x++)
            {
                for (int y = 0; y < pixelSize; y++)
                {
                    SetCursorPosition(parX * pixelSize + x, parY * pixelSize + y);
                    DrawTreasureOnGoal();
                }
            }
        }
        public static void DrawEmptyFloor(int parX, int parY)
        {
            for (int x = 0; x < pixelSize; x++)
            {
                for (int y = 0; y < pixelSize; y++)
                {
                    SetCursorPosition(parX * pixelSize + x, parY * pixelSize + y);
                    DrawEmptyFloor();
                }
            }
        }
        public static void DrawTreasureOnFloor(int parX, int parY)
        {
            for (int x = 0; x < pixelSize; x++)
            {
                for (int y = 0; y < pixelSize; y++)
                {

                    SetCursorPosition(parX * pixelSize + x, parY * pixelSize + y);
                    if (x == 1 && y == 1)
                    {
                        DrawSpace();
                    }
                    else
                    {
                        DrawTreasureOnFloor();
                    }

                }
            }
        }
        public static void DrawActorOnFloor(int parX, int parY)
        {
            for (int x = 0; x < pixelSize; x++)
            {
                for (int y = 0; y < pixelSize; y++)
                {
                    SetCursorPosition(parX * pixelSize + x, parY * pixelSize + y);
                    if (x == 1 && y == 1)
                    {
                        DrawActorOnFloor();
                    }
                    else
                    {
                        BackgroundColor = ConsoleColor.Black;
                        Write('#');
                    }
                    BackgroundColor = ConsoleColor.Black;
                }
            }
        }
        public static void DrawSpace(int parX, int parY)
        {
            for (int x = 0; x < pixelSize; x++)
            {
                for (int y = 0; y < pixelSize; y++)
                {
                    SetCursorPosition(parX * pixelSize + x, parY * pixelSize + y);
                    DrawSpace();
                }
            }
        }
        public static void DrawWall()
        {
            ForegroundColor = ConsoleColor.Cyan;
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
            //Write("*");
            Write("█");
            BackgroundColor = ConsoleColor.Black;
            ForegroundColor = ConsoleColor.White;
        }
        public static void DrawTreasureOnGoal()
        {
            ForegroundColor = ConsoleColor.Red;
            //Write("#");
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
            Write("█");
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
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
        }

    }
}
