using Model.PlayGame.Levels;
using Model.PlayGame.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.Cell
{
    public class WallCellBase : CellBase
    {
		
		/// <summary>
		/// Initializes a new instance of the <see cref="WallCell"/> class.
		/// </summary>
		/// <param name="location">The location where this wall is located.</param>
		/// <param name="level">The level where this cell is located.</param>
		public WallCellBase(Location location)
			: base("Wall", location)
		{
		}
	}
}
