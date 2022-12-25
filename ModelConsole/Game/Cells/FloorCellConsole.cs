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
	/// Represents a vacant floor cell in the level grid.
	/// </summary>
    public class FloorCellConsole:CellConsole
    {
		/// <summary>
		/// Cell's name
		/// </summary>
		private const string CELL_NAME = "Floor";

		/// <summary>
		/// Initializes a new instance of the <see cref="FloorCellConsole"/> class.
		/// </summary>
		/// <param name="parLocation">The location of the cell.</param>
		/// <param name="parLevel">The level on which the cell is located.</param>
		public FloorCellConsole(Location parLocation, LevelConsole parLevel)
			: base(CELL_NAME, parLocation, parLevel)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FloorCellConsole"/> class.
		/// </summary>
		/// <param name="parLocation">The location of the cell.</param>
		/// <param name="parLevel">The level on which the cell is located.</param>
		/// <param name="parContents">The contents of this cell.</param>
		public FloorCellConsole(Location parLocation, LevelConsole parLevel, CellContentsConsole parContents)
			: base(CELL_NAME, parLocation, parLevel, parContents)
		{
		}
	}
}
