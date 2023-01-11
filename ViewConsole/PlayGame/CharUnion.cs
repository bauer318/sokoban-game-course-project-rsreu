using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ViewConsole.PlayGame
{
    /// <summary>
    /// Representes the cell's char union as an union of the 
    /// unicode and ascii's char
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct CharUnion
    {
        /// <summary>
        /// The unicode's char
        /// </summary>
        [FieldOffset(0)] public char unicodeChar;
        /// <summary>
        /// The ascii's char
        /// </summary>
        [FieldOffset(0)] public byte asciiChar;
    }
}
