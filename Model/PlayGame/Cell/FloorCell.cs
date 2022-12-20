using Model.PlayGame.Levels;
using Model.PlayGame.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.Cell
{
    public class FloorCell : Cell
    {
		const string cellName = "Floor";

		/// <summary>
		/// Initializes a new instance of the <see cref="FloorCell"/> class.
		/// </summary>
		/// <param name="location">The location of the cell.</param>
		/// <param name="level">The level on which the cell is located.</param>
		public FloorCell(Location location, Level level)
			: base(cellName, location, level)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FloorCell"/> class.
		/// </summary>
		/// <param name="location">The location of the cell.</param>
		/// <param name="level">The level on which the cell is located.</param>
		/// <param name="contents">The contents of this cell.</param>
		public FloorCell(Location location, Level level, CellContents contents)
			: base(cellName, location, level, contents)
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
