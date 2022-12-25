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
	/// Represents the contents of a Cell.
	/// This is provided as a base implementation
	/// for other cell contents.
	/// </summary>
    public class CellContentsConsole:CellBaseConsole
    {
		/// <summary>
		/// The level where this instance is located
		/// </summary>
		private LevelConsole _level;
		/// <summary>
		/// Gets or sets the level where this instance is located.
		/// </summary>
		/// <value>The level where this instance is located.</value>
		public LevelConsole Level
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
		public CellConsole Cell
		{
			get
			{
				return _level[Location];
			}
			set
			{
				Location = value.Location;
				//OnPropertyChanged("Cell");
				//OnPropertyChanged("Location");
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CellContents"/> class.
		/// </summary>
		/// <param name="parName">The name of this cell contents. <seealso cref="Name"/></param>
		/// <param name="parLocation">The location on the level. <seealso cref="Location"/></param>
		/// <param name="parLevel">The level where this instance is located. <seealso cref="Level"/></param>
		public CellContentsConsole(string parName, Location parLocation, LevelConsole parLevel) : base(parName, parLocation)
		{
			_level = parLevel;
		}

	}
}
