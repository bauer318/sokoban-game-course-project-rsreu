using Model.PlayGame.Levels;
using Model.PlayGame.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.Cell
{
    public abstract class CellBase
    {
		/// <summary>
		/// Gets or sets the name of this cell.
		/// The name can be used to identify the type
		/// of the cell without using GetType().
		/// </summary>
		/// <value>The name of the cell. 
		/// The conceptual type name of the cell, 
		/// such as <em>Wall</em> or <em>Floor</em></value>
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the location on the <see cref="Level"/>.
		/// </summary>
		/// <value>The location of the cell on the <see cref="Level"/>.</value>
		public Location Location
		{
			get;
			set;
		}

		public CellBase(string name, Location location)
        {
			Name = name;
			Location = location;
        }
	}
}
