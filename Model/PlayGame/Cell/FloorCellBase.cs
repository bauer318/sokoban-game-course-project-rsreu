using Model.PlayGame.Levels;
using Model.PlayGame.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.Cell
{
    public class FloorCellBase:CellBase
    {
		const string cellName = "Floor";

		/// <summary>
		/// Initializes a new instance of the <see cref="FloorCell"/> class.
		/// </summary>
		/// <param name="location">The location of the cell.</param>
		/// <param name="level">The level on which the cell is located.</param>
		public FloorCellBase(Location location)
			: base(cellName, location)
		{
		}

	}
}
