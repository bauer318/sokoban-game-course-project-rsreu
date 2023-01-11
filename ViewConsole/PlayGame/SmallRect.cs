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
        public short left;
        /// <summary>
        /// The y-coordinate of the upper left corner of the rectangle
        /// </summary>
        public short top;
        /// <summary>
        /// The x-coordinate of the lower right corner of the rectangle
        /// </summary>
        public short right;
        /// <summary>
        /// The y-coordinate of the lower right corner of the rectangle
        /// </summary>
        public short bottom;
        /// <summary>
        /// Get the rectangle located on the defined possition
        /// </summary>
        /// <param name="parLeft">The x-coordinate of the upper left corner of the rectangle</param>
        /// <param name="parTop">The rigth's possition</param>
        /// <param name="parPixelSize">The y-coordinate of the upper left corner of the rectangle</param>
        /// <returns></returns>
        public static SmallRect GetRect(short parLeft, short parTop, short parPixelSize)
        {
            int right = parLeft + parPixelSize;
            int bottom = parTop + parPixelSize;
            return new SmallRect()
            {
                left = parLeft,
                top = parTop,
                right = Convert.ToInt16(right),
                bottom = Convert.ToInt16(bottom)
            };
        }
    }
    
}
