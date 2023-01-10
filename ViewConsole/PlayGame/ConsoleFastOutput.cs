using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ViewConsole.PlayGame
{
    /// <summary>
    /// Provides to fast output the game's level 
    /// </summary>
    public class ConsoleFastOutput
    {
        /// <summary>
        /// Representes the handle to the current console
        /// </summary>
        public SafeFileHandle _safeFileHandle;
        /// <summary>
        /// Default's contructor
        /// </summary>
        public ConsoleFastOutput()
        {
            _safeFileHandle = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
        }

        /// <summary>
        /// Create the file to handle the current console
        /// </summary>
        /// <param name="parFileName">The file's name must be CONOUT$</param>
        /// <param name="parFileAccess">The file access - 0x40000000 as the GenericWrite</param>
        /// <param name="parFileShare">The requested sharing mode of the file, which can be read , write, or both </param>
        /// <param name="parSecurityAttributes">The pointer to Security attribute</param>
        /// <param name="parCreationDisposition">An action to take on a file that exists or does not exist</param>
        /// <param name="parFlags">The file attributes and flags</param>
        /// <param name="parTemplate">A valid handle to a template file with the GENERIC_READ access right</param>
        /// <returns></returns>
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern SafeFileHandle CreateFile(
        string parFileName,
        [MarshalAs(UnmanagedType.U4)] uint parFileAccess,
        [MarshalAs(UnmanagedType.U4)] uint parFileShare,
        IntPtr parSecurityAttributes,
        [MarshalAs(UnmanagedType.U4)] FileMode parCreationDisposition,
        [MarshalAs(UnmanagedType.U4)] int parFlags,
        IntPtr parTemplate);
        /// <summary>
        /// Writes character and color attribute data to a specified rectangular 
        /// block of character cells in a console screen buffer
        /// </summary>
        /// <param name="parHConsoleOutput">The handle to the console screen buffer</param>
        /// <param name="parLpBuffer">The data to be written to the console screen buffer</param>
        /// <param name="parDwBufferSize">The size of the buffer pointed to by the lpBuffer parameter, in character cells</param>
        /// <param name="parDwBufferCoord">The coordinates of the upper-left cell in the buffer pointed to by the lpBuffer parameter</param>
        /// <param name="parLpWriteRegion">The pointer to the SmallRect structure</param>
        /// <returns>If the function succeeds, the return value is nonzero, else - the zero</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteConsoleOutput(
        SafeFileHandle parHConsoleOutput,
        CharInfo[] parLpBuffer,
        Coord parDwBufferSize,
        Coord parDwBufferCoord,
        ref SmallRect parLpWriteRegion);

        
        /// <summary>
        /// Draw a game's level cell
        /// </summary>
        /// <param name="parRect">The smallrect struct</param>
        /// <param name="parCharInfo">The level's cell char info</param>
        /// <param name="parPixelSize">The cell's pixel size</param>
        private void DrawCell(SmallRect parRect, CharInfo[] parCharInfo, short parPixelSize)
        {
            if (!_safeFileHandle.IsInvalid)
            {
                bool b = WriteConsoleOutput(_safeFileHandle, parCharInfo,
                         new Coord() { X = parPixelSize, Y = parPixelSize },
                         new Coord() { X = 0, Y = 0 },
                         ref parRect);
            }
        }

        /// <summary>
        /// Draw a Treasure on floor
        /// </summary>
        /// <param name="parLeft">The x-coordinate of the upper left corner of the rectangle</param>
        /// <param name="parTop">The y-coordinate of the upper left corner of the rectangle</param>
        /// <param name="parPixelSize">The pixel's size</param>
        [STAThread]
        public void DrawTreasureOnFloor(short parLeft, short parTop, short parPixelSize)
        {
            int pixelSize = parPixelSize * parPixelSize;
            CharInfo[] buf = new CharInfo[Convert.ToInt16(pixelSize)];
            buf[0].Attributes = (0 | (14 << 4));
            buf[0].Char.AsciiChar = 218; //┌
            buf[2].Attributes = (0 | (14 << 4));
            buf[2].Char.AsciiChar = 191; //┐ 
            buf[6].Attributes = (0 | (14 << 4));
            buf[6].Char.AsciiChar = 192; //└
            buf[8].Attributes = (0 | (14 << 4));
            buf[8].Char.AsciiChar = 217; //┘
            buf[4].Attributes = (14 | (7 << 4));
            buf[4].Char.AsciiChar = 35; //#
            int[] spaceIndex = { 1, 3, 5, 7 };
            for (var i = 0; i < spaceIndex.Length; i++)
            {
                buf[spaceIndex[i]].Attributes = (7 | (7 << 4));
                buf[spaceIndex[i]].Char.AsciiChar = 32;
            }
            DrawCell(SmallRect.GetRect(parLeft, parTop, parPixelSize), buf, parPixelSize);
           
        }

        /// <summary>
        /// Draw an Actor on floor
        /// </summary>
        /// <param name="parLeft">The x-coordinate of the upper left corner of the rectangle</param>
        /// <param name="parTop">The y-coordinate of the upper left corner of the rectangle</param>
        /// <param name="parPixelSize">The pixel's size</param>
        [STAThread]
        public void DrawActorOnFloor(short parLeft, short parTop, short parPixelSize)
        {
            int pixelSize = parPixelSize * parPixelSize;
            CharInfo[] buf = new CharInfo[Convert.ToInt16(pixelSize)];
            buf[0].Attributes = (15 | (10 << 4));
            buf[0].Char.AsciiChar = 218; //┌
            buf[2].Attributes = (15 | (10 << 4));
            buf[2].Char.AsciiChar = 191; //┐ 
            buf[6].Attributes = (15 | (10 << 4));
            buf[6].Char.AsciiChar = 192; //└
            buf[8].Attributes = (15 | (10 << 4));
            buf[8].Char.AsciiChar = 217; //┘
            buf[4].Attributes = (15 | (7 << 4));
            buf[4].Char.AsciiChar = 64; //@
            int[] spaceIndex = { 1, 3, 5, 7 };
            for (var i = 0; i < spaceIndex.Length; i++)
            {
                buf[spaceIndex[i]].Attributes = (7 | (7 << 4));
                buf[spaceIndex[i]].Char.AsciiChar = 32;
            }
            DrawCell(SmallRect.GetRect(parLeft, parTop, parPixelSize), buf, parPixelSize);
        }

        /// <summary>
        /// Draw an empty goal on floor
        /// </summary>
        /// <param name="parLeft">The x-coordinate of the upper left corner of the rectangle</param>
        /// <param name="parTop">The y-coordinate of the upper left corner of the rectangle</param>
        /// <param name="parPixelSize">The pixel's size</param>
        [STAThread]
        public void DrawEmptyGoalOnFloor(short parLeft, short parTop, short parPixelSize)
        {
            int pixelSize = parPixelSize * parPixelSize;
            CharInfo[] buf = new CharInfo[Convert.ToInt16(pixelSize)];
            buf[0].Attributes = (15 | (12 << 4));
            buf[0].Char.AsciiChar = 218; //┌
            buf[2].Attributes = (15 | (12 << 4));
            buf[2].Char.AsciiChar = 191; //┐ 
            buf[6].Attributes = (15 | (12 << 4));
            buf[6].Char.AsciiChar = 192; //└
            buf[8].Attributes = (15 | (12 << 4));
            buf[8].Char.AsciiChar = 217; //┘
            buf[4].Attributes = (12 | (7 << 4));
            buf[4].Char.AsciiChar = 42; //*
            int[] spaceIndex = { 1, 3, 5, 7 };
            for (var i = 0; i < spaceIndex.Length; i++)
            {
                buf[spaceIndex[i]].Attributes = (7 | (7 << 4));
                buf[spaceIndex[i]].Char.AsciiChar = 32;
            }
            DrawCell(SmallRect.GetRect(parLeft, parTop, parPixelSize), buf, parPixelSize);
        }

        /// <summary>
        /// Draw a wall
        /// </summary>
        /// <param name="parLeft">The x-coordinate of the upper left corner of the rectangle</param>
        /// <param name="parTop">The y-coordinate of the upper left corner of the rectangle</param>
        /// <param name="parPixelSize">The pixel's size</param>
        [STAThread]
        public void DrawWall(short parLeft, short parTop, short parPixelSize)
        {
            int pixelSize = parPixelSize * parPixelSize;
            CharInfo[] buf = new CharInfo[Convert.ToInt16(pixelSize)];
            for (var i = 0; i < buf.Length; i++)
            {
                buf[i].Attributes = 35;
                buf[i].Char.AsciiChar = 219; //█
            }
            DrawCell(SmallRect.GetRect(parLeft, parTop, parPixelSize), buf, parPixelSize);
        }
        /// <summary>
        /// Draw an empty floor
        /// </summary>
        /// <param name="parLeft">The x-coordinate of the upper left corner of the rectangle</param>
        /// <param name="parTop">The y-coordinate of the upper left corner of the rectangle</param>
        /// <param name="parPixelSize">The pixel's size</param>
        [STAThread]
        public void DrawEmptyFloor(short parLeft, short parTop, short parPixelSize)
        {
            int pixelSize = parPixelSize * parPixelSize;
            CharInfo[] buf = new CharInfo[Convert.ToInt16(pixelSize)];
            buf[0].Attributes = (15 | (7 << 4));
            buf[0].Char.AsciiChar = 218; //┌
            buf[2].Attributes = (15 | (7 << 4));
            buf[2].Char.AsciiChar = 191; //┐ 
            buf[6].Attributes = (15 | (7 << 4));
            buf[6].Char.AsciiChar = 192; //└
            buf[8].Attributes = (15 | (7 << 4));
            buf[8].Char.AsciiChar = 217; //┘
            buf[4].Attributes = (15 | (7 << 4));
            buf[4].Char.AsciiChar = 58; //:
            int[] horizontal = { 1, 7 };
            int[] vertical = { 3, 5 };
            for (var i = 0; i < horizontal.Length; i++)
            {
                buf[horizontal[i]].Attributes = (15 | (7 << 4));
                buf[horizontal[i]].Char.AsciiChar = 196; //─
            }
            for (var i = 0; i < vertical.Length; i++)
            {
                buf[vertical[i]].Attributes = (15 | (7 << 4));
                buf[vertical[i]].Char.AsciiChar = 179; //│
            }
            DrawCell(SmallRect.GetRect(parLeft, parTop, parPixelSize), buf, parPixelSize);
        }
        /// <summary>
        /// Draw an space
        /// </summary>
        /// <param name="parLeft">The x-coordinate of the upper left corner of the rectangle</param>
        /// <param name="parTop">The y-coordinate of the upper left corner of the rectangle</param>
        /// <param name="parPixelSize">The pixel's size</param>
        [STAThread]
        public void DrawSpace(short parLeft, short parTop, short parPixelSize)
        {
            int pixelSize = parPixelSize * parPixelSize;
            CharInfo[] buf = new CharInfo[Convert.ToInt16(pixelSize)];
            for (var i = 0; i < buf.Length; i++)
            {
                buf[i].Attributes = (7 | (7 << 4));
                buf[i].Char.AsciiChar = 32; //Space
            }
            DrawCell(SmallRect.GetRect(parLeft, parTop, parPixelSize), buf, parPixelSize);
        }
        /// <summary>
        /// Draw a Treasure on goal
        /// </summary>
        /// <param name="parLeft">The x-coordinate of the upper left corner of the rectangle</param>
        /// <param name="parTop">The y-coordinate of the upper left corner of the rectangle</param>
        /// <param name="parPixelSize">The pixel's size</param>
        [STAThread]
        public void DrawTreasureOnGoal(short parLeft, short parTop, short parPixelSize)
        {
            int pixelSize = parPixelSize * parPixelSize;
            CharInfo[] buf = new CharInfo[Convert.ToInt16(pixelSize)];
            buf[0].Attributes = (15 | (36 << 4));
            buf[0].Char.AsciiChar = 218; //┌
            buf[2].Attributes = (15 | (36 << 4));
            buf[2].Char.AsciiChar = 191; //┐ 
            buf[6].Attributes = (15 | (36 << 4));
            buf[6].Char.AsciiChar = 192; //└
            buf[8].Attributes = (15 | (36 << 4));
            buf[8].Char.AsciiChar = 217; //┘
            buf[4].Attributes = (14 | (7 << 4));
            buf[4].Char.AsciiChar = 35; //#
            int[] spaceIndex = { 1, 3, 5, 7 };
            for (var i = 0; i < spaceIndex.Length; i++)
            {
                buf[spaceIndex[i]].Attributes = (7 | (7 << 4));
                buf[spaceIndex[i]].Char.AsciiChar = 32;
            }
            DrawCell(SmallRect.GetRect(parLeft, parTop, parPixelSize), buf, parPixelSize);
        }
    }
}
