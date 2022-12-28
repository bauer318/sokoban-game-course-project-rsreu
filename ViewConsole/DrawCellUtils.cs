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
            Console.Write("0");
            Console.ForegroundColor = ConsoleColor.Black;
        }
        public static void DrawTreasure()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("#");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static void DrawEmptyGoal()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(".");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void DrawTreasureOnGoal()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static void DrawEmptyFloor()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(".");
        }
        public static void DrawTreasureOnFloor()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("#");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void DrawActorOnFloor()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void DrawSpace()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
        }

    }
}
