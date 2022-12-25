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
	public abstract class LevelBase
	{
		/// <summary>
		/// The level number
		/// </summary>
		private int _levelNumber;
		/// <summary>
		/// The game that this level is located
		/// </summary>
		private NewGameBase _newGameBase;
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
		public NewGameBase Game
		{
			get
			{
				return _newGameBase;
			}
			set
			{
				_newGameBase = value;
			}
		}
		/// <summary>
		/// LevelBase's contructor
		/// </summary>
		/// <param name="newGameBase">The game that this level is located</param>
		/// <param name="levelNumber">The level number</param>
		public LevelBase(NewGameBase parNewGameBase, int parLevelNumber)
		{
			Game = parNewGameBase;
			LevelNumber = parLevelNumber;
		}
		#region LevelCompleted event

		private event EventHandler levelCompleted;

		/// <summary>
		/// Occurs when a level has been completed successfully.
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

		/// <summary>
		/// Raises the LevelCompleted event.
		/// </summary>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected void OnLevelCompleted(EventArgs e)
		{
			if (levelCompleted != null)
			{
				levelCompleted(this, e);

			}
		}
		#endregion
		/// <summary>
		/// Loads the level data from the specified map stream.
		/// </summary>
		/// <param name="parMapStream">The map stream to load the level.</param>
		public abstract void Load(TextReader parMapStream);
		/// <summary>
		/// Tests whether the specified location is within 
		/// the Levels grid.
		/// </summary>
		/// <param name="location">The location to test
		/// whether it is within the level grid.</param>
		/// <returns><code>true</code> if the location
		/// is within the <see cref="LevelBase"/>; 
		/// <code>false</code> otherwise.</returns>
		public abstract bool InBounds(Location location);

	}
}
