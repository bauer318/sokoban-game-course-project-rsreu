using ModelWPF.Game.Levels;
using ModelWPF.Game.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWPF.Game.Cells
{
    public class SpaceCell : Cell
    {
        /// <summary>
        /// Represents a cell containing nothing. 
        /// This is not a cell that is used to place <see cref="CellContents"/>.
        /// </summary>
        public SpaceCell(Location location, Level level)
            : base("Space", location, level)
        {
        }
    }
}
