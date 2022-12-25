using Model.PlayGame.Levels;
using Model.PlayGame.Locations;
using ModelWPF.Game.Cells;
using ModelWPF.Game.Cells.Actors;
using ModelWPF.Game.NewGame;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWPF.Game.Levels
{
	/// <summary>
	/// Represents a single stage within a game.
	/// A level instance is able to load itself
	/// from a map resource.
	/// </summary>
	public class LevelWPF:LevelBase
	{
		/// <summary>
		/// All cells of the this level
		/// </summary>
		private CellWPF[][] _cells;
		/// <summary>
		/// All Goals cell of this level
		/// </summary>
		private List<GoalCellWPF> _goals = new List<GoalCellWPF>();
		/// <summary>
		/// The Level's Actor
		/// </summary>
		private Actor _actor;

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
		/// Gets the Cell with the specified row number
		/// and column number.
		/// </summary>
		/// <value>The cell at the specified row number and column number.</value>
		public CellWPF this[int rowNumber, int columnNumber]
		{
			get
			{
				return _cells[rowNumber][columnNumber];
			}
		}

		/// <summary>
		/// Gets the Cell with the specified location.
		/// </summary>
		/// <value>The cell at the specified location.</value>
		public CellWPF this[Location location]
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
		/// Initializes a new instance of the <see cref="LevelWPF"/> class.
		/// </summary>
		/// <param name="parGame">The game that the level belongs.</param>
		/// <param name="parLevelNumber">The level number for this level.</param>
		public LevelWPF(NewGameWPF parGame, int parLevelNumber):base(parGame,parLevelNumber)
		{
		}

		/// <summary>
		/// Loads the level data from the specified map stream.
		/// </summary>
		/// <param name="parMapStream">The map stream to load the level.</param>
		public override void Load(TextReader parMapStream)
		{
			if (parMapStream == null)
			{
				throw new ArgumentNullException("mapStream");
			}

			List<List<CellWPF>> rows = new List<List<CellWPF>>();

			string gridRowText;
			int rowCount = 0;
			while ((gridRowText = parMapStream.ReadLine()) != null && gridRowText.Trim() != string.Empty)
			{
				rows.Add(BuildCells(gridRowText, rowCount++));
			}

			_cells = new CellWPF[rowCount][];
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
		private List<CellWPF> BuildCells(string parRowText, int parRowNumber)
		{
			List<CellWPF> row = new List<CellWPF>(parRowText.Length);

			int columnNumber = 0;

			foreach (char c in parRowText)
			{
				Location location = new Location(parRowNumber, columnNumber++);
				switch (c)
				{
					case '#': /* Wall. */
						row.Add(new WallCellWPF(location, this));
						break;
					case ' ': /* Empty. */
						row.Add(new FloorCellWPF(location, this));
						break;
					case '$': /* TreasureWPF in a square. */
						row.Add(new FloorCellWPF(location, this, new TreasureWPF(location, this)));
						break;
					case '*': /* TreasureWPF in a Goal. */
						GoalCellWPF goalCellWithTreasure = new GoalCellWPF(location, this, new TreasureWPF(location, this));
						goalCellWithTreasure.CompletedGoalChanged += new EventHandler(GoalCell_CompletedGoalChanged);
						_goals.Add(goalCellWithTreasure);
						row.Add(goalCellWithTreasure);
						break;
					case '.': /* Goal. */
						GoalCellWPF goalCell = new GoalCellWPF(location, this);
						goalCell.CompletedGoalChanged += new EventHandler(GoalCell_CompletedGoalChanged);
						_goals.Add(goalCell);
						row.Add(goalCell);
						break;
					case '@': /* Actors in a floor cell. */
						Actor actor = new Actor(location, this);
						row.Add(new FloorCellWPF(location, this, actor));
						_actor = actor;
						break;
					case '!': /* Space. */
						row.Add(new SpaceCellWPF(location, this));
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
			foreach (GoalCellWPF goal in _goals)
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
		/// is within the <see cref="LevelWPF"/>; 
		/// <code>false</code> otherwise.</returns>
		public override bool InBounds(Location location)
		{
			return (location.RowNumber >= 0
				&& location.RowNumber < RowCount
				&& location.ColumnNumber >= 0
				&& location.ColumnNumber < ColumnCount);
		}
	}
}
