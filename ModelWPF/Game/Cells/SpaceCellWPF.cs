using Model.PlayGame.Locations;
using ModelWPF.Game.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWPF.Game.Cells
{
    /// <summary>
	/// Represents a space on the level grid
	/// </summary>
    public class SpaceCellWPF : CellWPF
    {
        /// <summary>
        /// Represents a cell containing nothing. 
        /// This is not a cell that is used to place <see cref="CellContentsWPF"/>.
        /// </summary>
        public SpaceCellWPF(Location parLocation, LevelWPF parLevel)
            : base("Space", parLocation, parLevel)
        {
        }
    }
}
