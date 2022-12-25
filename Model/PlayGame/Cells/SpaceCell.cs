using Model.PlayGame.Levels;
using Model.PlayGame.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.Cells
{
    /// <summary>
	/// Represents a space on the level grid
	/// </summary>
    public class SpaceCell : Cell
    {
        /// <summary>
        /// Represents a cell containing nothing. 
        /// This is not a cell that is used to place <see cref="CellContents"/>.
        /// </summary>
        public SpaceCell(Location parLocation, Level parLevel)
            : base("Space", parLocation, parLevel)
        {
        }
    }
}
