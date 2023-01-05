using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewConsole
{
    /// <summary>
    /// Provides for drawing the level's cells
    /// </summary>
    public class DrawCellUtils
    {
        /// <summary>
        /// Draw a Wall
        /// </summary>
        public static void DrawWall()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        /// <summary>
        /// Draw a enpty goal - a goal without treasure
        /// </summary>
        public static void DrawEmptyGoal()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(".");
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
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
        /// <summary>
        /// Draw a empty floor - where the actor can move
        /// </summary>
        public static void DrawEmptyFloor()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(".");
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
        /// <summary>
        /// Draw an actor on floor
        /// </summary>
        public static void DrawActorOnFloor()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        /// <summary>
        /// Draw the space
        /// </summary>
        public static void DrawSpace()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write(" ");
        }

    }
}
