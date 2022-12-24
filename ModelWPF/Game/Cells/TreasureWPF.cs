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
	/// Represents a treasure in a level grid.
	/// </summary>
	public class TreasureWPF : CellContentsWPF
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TreasureWPF"/> class.
		/// </summary>
		/// <param name="parLocation">The location where the treasure is.</param>
		/// <param name="parLevel">The level that the treasure is located.</param>
		public TreasureWPF(Location parLocation, LevelWPF parLevel)
			: base("Treasure", parLocation, parLevel)
		{
		}
	}
}
