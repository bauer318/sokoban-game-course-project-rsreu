using Model.PlayGame.Cells;
using Model.PlayGame.Cells.Actors;
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
	/// <summary>
	/// Represents a single stage within a game.
	/// A level instance is able to load itself
	/// from a map resource.
	/// </summary>
	public class Level
	{
		/// <summary>
		/// All cells of the this level
		/// </summary>
		private Cell[][] _cells;
		/// <summary>
		/// All Goals cell of this level
		/// </summary>
		private List<GoalCell> _goals = new();
		/// <summary>
		/// The Level's Actor
		/// </summary>
		private Actor _actor;
		/// <summary>
		/// The level number
		/// </summary>
		private int _levelNumber;
		/// <summary>
		/// The game that this level is located
		/// </summary>
		private Game _game;

		/// <summary>
		/// Gets the single Actor instance
		/// located on each level.
		/// </summary>
		/// <value>The actor. (The user moveable guy) </value>
		public Actor Actor
		{
			get
			{
				return _actor;

			}
			private set
			{
				_actor = value;
			}
		}

		/// <summary>
		/// Gets the Cells with the specified row number
		/// and column number.
		/// </summary>
		/// <value>The cell at the specified row number and column number.</value>
		public Cell this[int rowNumber, int columnNumber]
		{
			get
			{
				return _cells[rowNumber][columnNumber];
			}
		}

		/// <summary>
		/// Gets the Cells with the specified location.
		/// </summary>
		/// <value>The cell at the specified location.</value>
		public Cell this[Location location]
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
		/// Gets the number of rows in the level.
		/// </summary>
		/// <value>The number of rows in the level.</value>
		public int RowCount
		{
			get
			{
				return _cells != null ? _cells.Length : 0;
			}
		}

		/// <summary>
		/// Gets the number of columns in the level.
		/// </summary>
		/// <value>The number of columns in the level.</value>
		public int ColumnCount
		{
			get
			{
				return _cells != null && _cells.Length > 0 ? _cells[0].Length : 0;
			}
		}
		
		/// <summary>
		/// Gets the level number.
		/// </summary>
		/// <value>The level number.</value>
		public int LevelNumber
		{
			get
			{
				return _levelNumber;
			}
			set
			{
				_levelNumber = value;
			}
		}

		/// <summary>
		/// Gets or sets the game that this level is located.
		/// </summary>
		/// <value>The game that this level is located.</value>
		public Game Game
		{
			get
			{
				return _game;
			}
			set
			{
				_game = value;
			}
		}
		/// <summary>
		/// Level's contructor
		/// </summary>
		/// <param name="parGame">The game that this level is located</param>
		/// <param name="levelNumber">The level number</param>
		public Level(Game parGame, int parLevelNumber)
		{
			Game = parGame;
			LevelNumber = parLevelNumber;
		}
		#region LevelCompleted event

		private event EventHandler _levelCompleted;

		/// <summary>
		/// Occurs when a level has been completed successfully.
		/// </summary>
		public event EventHandler LevelCompleted
		{
			add
			{
				_levelCompleted += value;
			}
			remove
			{
				_levelCompleted -= value;
			}
		}

		/// <summary>
		/// Raises the LevelCompleted event.
		/// </summary>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected void OnLevelCompleted(EventArgs e)
		{
			if (_levelCompleted != null)
			{
				_levelCompleted(this, e);

			}
		}
		#endregion
		/// <summary>
		/// Loads the level data from the specified map stream.
		/// </summary>
		/// <param name="parMapStream">The map stream to load the level.</param>
		public  void Load(TextReader parMapStream)
        {
			if (parMapStream == null)
			{
				throw new ArgumentNullException("mapStream");
			}

			List<List<Cell>> rows = new();

			string gridRowText;
			int rowCount = 0;
			while ((gridRowText = parMapStream.ReadLine()) != null && gridRowText.Trim() != string.Empty)
			{
				rows.Add(BuildCells(gridRowText, rowCount++));
			}

			_cells = new Cell[rowCount][];
			for (int i = 0; i < rowCount; i++)
			{
				_cells[i] = rows[i].ToArray();
			}
		}
		/// <summary>
		/// Build the level's cells for text row
		/// </summary>
		/// <param name="parRowText">The row text in Level's file</param>
		/// <param name="parRowNumber">The row number in Level's file</param>
		/// <returns></returns>
		private List<Cell> BuildCells(string parRowText, int parRowNumber)
		{
			List<Cell> row = new(parRowText.Length);

			int columnNumber = 0;

			foreach (char c in parRowText)
			{
				Location location = new(parRowNumber, columnNumber++);
				switch (c)
				{
					case '#': /* Wall. */
						row.Add(new WallCell(location, this));
						break;
					case ' ': /* Empty. */
						row.Add(new FloorCell(location, this));
						break;
					case '$': /* Treasure in a square. */
						row.Add(new FloorCell(location, this, new Treasure(location, this)));
						break;
					case '*': /* Treasure in a Goal. */
						GoalCell goalCellWithTreasure = new(location, this, new Treasure(location, this));
						goalCellWithTreasure.CompletedGoalChanged += new EventHandler(GoalCell_CompletedGoalChanged);
						_goals.Add(goalCellWithTreasure);
						row.Add(goalCellWithTreasure);
						break;
					case '.': /* Goal. */
						GoalCell goalCell = new(location, this);
						goalCell.CompletedGoalChanged += new EventHandler(GoalCell_CompletedGoalChanged);
						_goals.Add(goalCell);
						row.Add(goalCell);
						break;
					case '@': /* Actors in a floor cell. */
						Actor actor = new(location, this);
						row.Add(new FloorCell(location, this, actor));
						_actor = actor;
						break;
					case '!': /* Space. */
						row.Add(new SpaceCell(location, this));
						break;
					default:
						throw new FormatException("Invalid Levels symbol found: " + c);
				}
			}
			return row;
		}
		/// <summary>
		/// Occurs when the Goal's cell change and whether the level is Completed
		/// </summary>
		///<param name = "e" > The < see cref="System.EventArgs"/> instance containing the event data.</param>
		private void GoalCell_CompletedGoalChanged(object sender, EventArgs e)
		{
			foreach (GoalCell goal in _goals)
			{
				if (!goal.HasTreasure)
				{
					return;
				}
			}
			OnLevelCompleted(EventArgs.Empty);
		}

		/// <summary>
		/// Tests whether the specified location is within 
		/// the Levels grid.
		/// </summary>
		/// <param name="location">The location to test
		/// whether it is within the level grid.</param>
		/// <returns><code>true</code> if the location
		/// is within the <see cref="LevelBase"/>; 
		/// <code>false</code> otherwise.</returns>
		public bool InBounds(Location location)
        {
			return (location.RowNumber >= 0
				&& location.RowNumber < RowCount
				&& location.ColumnNumber >= 0
				&& location.ColumnNumber < ColumnCount);
		}

	}
}
