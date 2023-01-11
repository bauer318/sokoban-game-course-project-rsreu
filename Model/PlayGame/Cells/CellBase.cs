using Model.PlayGame.Locations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model.PlayGame.Cells
{
	/// <summary>
	/// Base class for all cells in a Level.
	/// </summary>
	public class CellBase
	{
		/// <summary>
		/// The parName can be used to identify the type
		/// of the cell without using GetType().
		/// </summary>
		private string _name;
		/// <summary>
		/// the location on the Level.
		/// </summary>
		private Location _location;

		/// <summary>
		/// Gets or sets the parName of this cell.
		/// The parName can be used to identify the type
		/// of the cell without using GetType().
		/// </summary>
		/// <value>The parName of the cell. 
		/// The conceptual type parName of the cell, 
		/// such as <em>Wall</em> or <em>Floor</em></value>
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		/// <summary>
		/// Gets or sets the location on the Level>.
		/// </summary>
		/// <value>The location of the cell on the Level</value>
		public Location Location
		{
			get
			{
				return _location;
			}
			set
			{
				_location = value;
			}
		}
		/// <summary>
		/// CellBase's Constructor
		/// </summary>
		/// <param parName="name">Cells's Name</param>
		/// <param parName="location">Cells's location</param>
		public CellBase(string parName, Location parLocation)
		{
			_name = parName;
			_location = parLocation;
		}
	}
}
