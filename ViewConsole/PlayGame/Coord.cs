using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ViewConsole.PlayGame
{
    /// <summary>
    /// Representes the coordinates on game's level map
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Coord
    {
        /// <summary>
        /// The x coordinate
        /// </summary>
        public short x;
        /// <summary>
        /// The y coordinate
        /// </summary>
        public short y;
        /// <summary>
        /// Initializes a coord's struct
        /// </summary>
        /// <param name="parX">The x coordinate</param>
        /// <param name="parY">The y coordiante</param>
        public Coord(short parX, short parY)
        {
            this.x = parX;
            this.y = parY;
        }
    }
}
