using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ViewConsole.PlayGame
{
    /// <summary>
    ///Defines the coordinates of the upper left and lower right corners of a rectangle
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct  SmallRect
    {
        /// <summary>
        /// The x-coordinate of the upper left corner of the rectangle
        /// </summary>
        public short Left { get; private set; }
        /// <summary>
        /// The y-coordinate of the upper left corner of the rectangle
        /// </summary>
        public short Top { get; private set; }
        /// <summary>
        /// The x-coordinate of the lower right corner of the rectangle
        /// </summary>
        public short Right { get; private set; }
        /// <summary>
        /// The y-coordinate of the lower right corner of the rectangle
        /// </summary>
        public short Bottom { get; private set; }
        /// <summary>
        /// Get the rectangle located on the defined possition
        /// </summary>
        /// <param name="parLeft">The left's possition</param>
        /// <param name="parTop">The rigth's possition</param>
        /// <param name="parPixelSize">The pixel's size</param>
        /// <returns></returns>
        public static SmallRect GetRect(short parLeft, short parTop, short parPixelSize)
        {
            int right = parLeft + parPixelSize;
            int bottom = parTop + parPixelSize;
            return new SmallRect()
            {
                Left = parLeft,
                Top = parTop,
                Right = Convert.ToInt16(right),
                Bottom = Convert.ToInt16(bottom)
            };
        }
    }
    
}
