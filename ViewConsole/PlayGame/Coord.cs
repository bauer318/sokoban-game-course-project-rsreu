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
        /// Get or Set The X coordinate
        /// </summary>
        public short X { get; set; }
        /// <summary>
        /// Get or Set the Y coordinate
        /// </summary>
        public short Y { get; set; }
        /// <summary>
        /// Initializes a coord's struct
        /// </summary>
        /// <param name="parX">The X coordinate</param>
        /// <param name="parY">The Y coordiante</param>
        public Coord(short parX, short parY)
        {
            this.X = parX;
            this.Y = parY;
        }
    }
}
