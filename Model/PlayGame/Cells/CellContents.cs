using Model.PlayGame.Levels;
using Model.PlayGame.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.Cells
{
	/// <summary>
	/// Represents the contents of a Cells.
	/// This is provided as a base implementation
	/// for other cell contents.
	/// </summary>
	public class CellContents : CellBase
	{
		/// <summary>
		/// The level where this instance is located
		/// </summary>
		private Level _level;
		/// <summary>
		/// Gets or sets the level where this instance is located.
		/// </summary>
		/// <value>The level where this instance is located.</value>
		public Level Level
		{
			get
			{
				return _level;
			}
			private set
			{
				_level = value;
			}
		}

		/// <summary>
		/// Gets or sets the cell where this instance is located.
		/// </summary>
		/// <value>The cell where this instance is located.</value>
		public Cell Cell
		{
			get
			{
				return _level[Location];
			}
			set
			{
				Location = value.Location;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CellContents"/> class.
		/// </summary>
		/// <param name="parName">The name of this cell contents. <seealso cref="Name"/></param>
		/// <param name="parLocation">The location on the level. <seealso cref="Location"/></param>
		/// <param name="parLevel">The level where this instance is located. <seealso cref="Level"/></param>
		public CellContents(string parName, Location parLocation, Level parLevel) : base(parName, parLocation)
		{
			_level = parLevel;
		}

	}
}
