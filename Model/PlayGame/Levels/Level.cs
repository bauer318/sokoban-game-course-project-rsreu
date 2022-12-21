using Model.PlayGame.Cell;
using Model.PlayGame.Cell.Actors;
using Model.PlayGame.Locations;
using Model.PlayGame.NewGame;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.Levels
{
    public abstract class Level
    {
		public Cell.Cell[][] cells;
		public List<GoalCell> goals = new List<GoalCell>();

		/// <summary>
		/// Gets the Level number.
		/// </summary>
		/// <value>The Level number.</value>
		public int LevelNumber
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets or sets the game that this Level is located.
		/// </summary>
		/// <value>The game that this Level is located.</value>
		protected Game Game
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the single <see cref="Actor"/> instance
		/// located on each Level.
		/// </summary>
		/// <value>The actor. (The user moveable guy) </value>
		public Actor Actor
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the <see cref="Orpius.Sokoban.Cell"/> with the specified row number
		/// and column number.
		/// </summary>
		/// <value>The cell at the specified row number and column number.</value>
		public Cell.Cell this[int rowNumber, int columnNumber]
		{
			get
			{
				return cells[rowNumber][columnNumber];
			}
		}

		/// <summary>
		/// Gets the <see cref="Cell"/> with the specified location.
		/// </summary>
		/// <value>The cell at the specified location.</value>
		public Cell.Cell this[Location location]
		{
			get
			{
				if (InBounds(location))
				{
					return this[location.RowNumber, location.ColumnNumber];
				}
				return null;
			}
		}

		/// <summary>
		/// Gets the number of rows in the Level.
		/// </summary>
		/// <value>The number of rows in the Level.</value>
		public int RowCount
		{
			get
			{
				return cells != null ? cells.Length : 0;
			}
		}

		/// <summary>
		/// Gets the number of columns in the Level.
		/// </summary>
		/// <value>The number of columns in the Level.</value>
		public int ColumnCount
		{
			get
			{
				return cells != null && cells.Length > 0 ? cells[0].Length : 0;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Level"/> class.
		/// </summary>
		/// <param name="game">The game that the Level belongs.</param>
		/// <param name="levelNumber">The Level number for this Level.</param>
		public Level(Game game, int levelNumber)
		{
			Game = game;
			LevelNumber = levelNumber;
		}

		/// <summary>
		/// Loads the Level data from the specified map stream.
		/// </summary>
		/// <param name="mapStream">The map stream to load the Level.</param>
		public void Load(TextReader mapStream)
		{
			if (mapStream == null)
			{
				throw new ArgumentNullException("mapStream");
			}

			List<List<Cell.Cell>> rows = new List<List<Cell.Cell>>();

			string gridRowText;
			int rowCount = 0;
			while ((gridRowText = mapStream.ReadLine()) != null && gridRowText.Trim() != string.Empty)
			{
				rows.Add(BuildCells(gridRowText, rowCount++));
			}

			cells = new Cell.Cell[rowCount][];
			for (int i = 0; i < rowCount; i++)
			{
				cells[i] = rows[i].ToArray();
			}
		}

		public abstract List<Cell.Cell> BuildCells(string rowText, int rowNumber);
		

		/// <summary>
		/// Tests whether the specified location is within 
		/// the Levels grid.
		/// </summary>
		/// <param name="location">The location to test
		/// whether it is within the Level grid.</param>
		/// <returns><code>true</code> if the location
		/// is within the <see cref="Level"/>; 
		/// <code>false</code> otherwise.</returns>
		public bool InBounds(Location location)
		{
			return (location.RowNumber >= 0
				&& location.RowNumber < RowCount
				&& location.ColumnNumber >= 0
				&& location.ColumnNumber < ColumnCount);
		}
		#region LevelCompleted event
		public event EventHandler levelCompleted;
		/// <summary>
		/// Occurs when a Level has been completed successfully.
		/// </summary>
		public event EventHandler LevelCompleted
		{
			add
			{
				levelCompleted += value;
			}
			remove
			{
				levelCompleted -= value;
			}
		}
		#endregion
	}
}
