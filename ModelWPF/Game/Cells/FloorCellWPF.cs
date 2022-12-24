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
	/// Represents a vacant floor cell in the level grid.
	/// </summary>
	public class FloorCellWPF : CellWPF
	{
		/// <summary>
		/// Cell's name
		/// </summary>
		private const string CELL_NAME = "Floor";

		/// <summary>
		/// Initializes a new instance of the <see cref="FloorCellWPF"/> class.
		/// </summary>
		/// <param name="parLocation">The location of the cell.</param>
		/// <param name="parLevel">The level on which the cell is located.</param>
		public FloorCellWPF(Location parLocation, LevelWPF parLevel)
			: base(CELL_NAME, parLocation, parLevel)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FloorCellWPF"/> class.
		/// </summary>
		/// <param name="parLocation">The location of the cell.</param>
		/// <param name="parLevel">The level on which the cell is located.</param>
		/// <param name="parContents">The contents of this cell.</param>
		public FloorCellWPF(Location parLocation, LevelWPF parLevel, CellContentsWPF parContents)
			: base(CELL_NAME, parLocation, parLevel, parContents)
		{
		}
	}
}
