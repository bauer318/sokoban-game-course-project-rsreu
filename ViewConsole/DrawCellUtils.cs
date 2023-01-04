using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewConsole
{
    public class DrawCellUtils
    {
        
        public static void DrawWall()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void DrawTreasure()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("#");
            Console.BackgroundColor = ConsoleColor.Gray;
        }
        public static void DrawEmptyGoal()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(".");
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        public static void DrawTreasureOnGoal()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.BackgroundColor = ConsoleColor.Gray;
        }
        public static void DrawEmptyFloor()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(".");
        }
        public static void DrawTreasureOnFloor()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("#");
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        public static void DrawActorOnFloor()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        public static void DrawSpace()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write(" ");
        }

    }
}
