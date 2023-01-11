using System.Collections.Generic;

namespace ViewConsole.PlayGame
{
    /// <summary>
    /// Represent a Cell's view with location for working with console layout
    /// </summary>
    public class CellLocation
    {
        /// <summary>
        /// Get or Set the console cursor's left
        /// </summary>
        public int XMap { get; set; }
        /// <summary>
        /// Get or Set the console cursor's top
        /// </summary>
        public int YMap { get; set; }
        /// <summary>
        /// Get or Set the cell's row number
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Get or Set the cell's column number
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// Initializes the cell's view
        /// </summary>
        /// <param name="parXMap">the console cursor's left</param>
        /// <param name="parYMap">the console cursor's top</param>
        /// <param name="parX">the cell's row number</param>
        /// <param name="parY">the cell's column number</param>
        public CellLocation(int parX, int parY, int parXMap, int parYMap)
        {
            XMap = parXMap;
            YMap = parYMap;
            X = parX;
            Y = parY;
        }

        public static CellLocation GetCellLocationByCoordinate(int parX, int parY, List<CellLocation> parCellLocationList)
        {
            return parCellLocationList.Find(elCellLocation => elCellLocation.X == parX && elCellLocation.Y == parY);
        }

    }
}
