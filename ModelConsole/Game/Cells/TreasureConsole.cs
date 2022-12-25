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
	/// Represents a treasure in a level.
	/// </summary>
    public class TreasureConsole:CellContentsConsole
    {
		// <summary>
		/// Initializes a new instance of the <see cref="TreasureWPF"/> class.
		/// </summary>
		/// <param name="parLocation">The location where the treasure is.</param>
		/// <param name="parLevel">The level that the treasure is located.</param>
		public TreasureConsole(Location parLocation, LevelConsole parLevel)
			: base("Treasure", parLocation, parLevel)
		{
		}
	}
}
