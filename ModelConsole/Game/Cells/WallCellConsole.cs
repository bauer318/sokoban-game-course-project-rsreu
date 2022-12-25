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
	/// Represents a wall in the <see cref="LevelConsole"/> grid.
	/// </summary>
    public class WallCellConsole:CellConsole
    {
		/// <summary>
		/// Gets a value indicating whether the Actor/> 
		/// or other <see cref="CellContentsConsole"/>
		/// instance can enter this cell.
		/// </summary>
		/// <value><c>false</c></value>
		public override bool CanEnter
		{
			get
			{
				return false;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="WallCell"/> class.
		/// </summary>
		/// <param name="parLocation">The location where this wall is located.</param>
		/// <param name="parLevel">The level where this cell is located.</param>
		public WallCellConsole(Location parLocation, LevelConsole parLevel)
			: base("Wall", parLocation, parLevel)
		{
		}
	}
}
