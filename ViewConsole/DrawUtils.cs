using System;
using static System.Console;

namespace ViewConsole
{
    /// <summary>
    /// Provides for drawing
    /// </summary>
    public class DrawUtils
    {
        /// <summary>
        /// The current console's background color
        /// </summary>
        private static ConsoleColor _savevBackgroundColor;
        /// <summary>
        /// The current console's foreground color
        /// </summary>
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
    }
}
