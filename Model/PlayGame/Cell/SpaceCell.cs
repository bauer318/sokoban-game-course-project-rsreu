using Model.PlayGame.Levels;
using Model.PlayGame.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.Cell
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
        public override void RemoveContents()
        {
            throw new NotImplementedException();
        }

        public override bool TrySetContents(CellContents contents)
        {
            throw new NotImplementedException();
        }
    }
}
