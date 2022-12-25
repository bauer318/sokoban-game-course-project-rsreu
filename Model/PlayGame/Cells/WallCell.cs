using Model.PlayGame.Levels;
using Model.PlayGame.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.Cells
{
    public class WallCell:Cell
    {
		/// <summary>
		/// Gets a value indicating whether the Actor/> 
		/// or other <see cref="CellContents"/>
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
		public WallCell(Location parLocation, Level parLevel)
			: base("Wall", parLocation, parLevel)
		{
		}
	}
}
