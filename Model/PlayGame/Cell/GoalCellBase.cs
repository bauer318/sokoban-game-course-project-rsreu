using Model.PlayGame.Levels;
using Model.PlayGame.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.Cell
{
    public class GoalCellBase:CellBase
    {
        const string cellName = "Goal";
		/// <summary>
		/// Initializes a new instance of the <see cref="GoalCell"/> class.
		/// </summary>
		/// <param name="location">The location of the goal
		/// on the level grid.</param>
		/// <param name="level">The level grid where this cell
		/// is located.</param>
		public GoalCellBase(Location location)
			: base(cellName, location)
		{
		}
	}
}
