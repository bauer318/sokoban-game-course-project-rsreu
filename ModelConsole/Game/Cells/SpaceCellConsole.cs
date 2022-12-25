using Model.PlayGame.Locations;
using ModelConsole.Game.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelConsole.Game.Cells
{
    /// <summary>
	/// Represents a space on the level
	/// </summary>
    public class SpaceCellConsole:CellConsole
    {
        /// <summary>
        /// Represents a cell containing nothing. 
        /// This is not a cell that is used to place <see cref="CellContentsConsole"/>.
        /// </summary>
        public SpaceCellConsole(Location parLocation, LevelConsole parLevel)
            : base("Space", parLocation, parLevel)
        {
        }
    }
}
