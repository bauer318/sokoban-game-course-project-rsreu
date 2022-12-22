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
	/// Represents the contents of a <see cref="Cell"/>.
	/// This is provided as a base implementation
	/// for other cell contents.
	/// </summary>
	public class CellContentsWPF : LevelContentBase
	{
		/// <summary>
		/// Gets or sets the name of this cell contents.
		/// The name can be used to identify the type
		/// of the cell contents without using GetType().
		/// </summary>
		/// <value>The name of the cell contents. 
		/// The conceptual type name of the cell contents, 
		/// such as <em>Actors</em> or <em>TreasureWPF</em></value>
		public string Name
		{
			get;
			protected set;
		}

		/// <summary>
		/// Gets or sets the location on the <see cref="Level"/>.
		/// </summary>
		/// <value>The location of the cell on the <see cref="Level"/>.</value>
		public Location Location
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets or sets the level where this instance is located.
		/// </summary>
		/// <value>The level where this instance is located.</value>
		public Level Level
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets or sets the cell where this instance is located.
		/// </summary>
		/// <value>The cell where this instance is located.</value>
		public CellWPF Cell
		{
			get
			{
				return Level[Location];
			}
			set
			{
				Location = value.Location;
				OnPropertyChanged("Cell");
				OnPropertyChanged("Location");
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CellContents"/> class.
		/// </summary>
		/// <param name="name">The name of this cell contents. <seealso cref="Name"/></param>
		/// <param name="location">The location on the level. <seealso cref="Location"/></param>
		/// <param name="level">The level where this instance is located. <seealso cref="Level"/></param>
		public CellContentsWPF(string name, Location location, Level level)
		{
			Name = name;
			Location = location;
			Level = level;
		}
	}
}
