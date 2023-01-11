using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ViewConsole.PlayGame
{
    /// <summary>
    /// Representes the cell's char information
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct CharInfo
    {
        /// <summary>
        /// Representes the cell's char union as the cell's char char to print
        /// </summary>
        [FieldOffset(0)] public CharUnion charUnion;
        /// <summary>
        /// Representes the cell's char attributes as the backgound and foreground's color
        /// </summary>
        [FieldOffset(2)] public short attributes;
    }
}
