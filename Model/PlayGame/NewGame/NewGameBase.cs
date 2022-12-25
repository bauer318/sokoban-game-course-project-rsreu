using Model.PlayGame.Locations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.NewGame
{
	/// <summary>
	/// A Sokoban's Game
	/// </summary>
	public abstract class NewGameBase
	{
		/// <summary>
		/// The state of Game
		/// </summary>
		private GameState _gameState;
		/// <summary>
		/// The the number of levels in the game
		/// </summary>
		private int _levelCount;
		/// <summary>
		/// The levels'folder directory
		/// </summary>
		public const string LevelDirectory = @"..\..\..\..\Levels\";
		/// <summary>
		/// Gets the number of levels available
		/// to be played in a game.
		/// </summary>
		/// <value>The the number of levels in the game.</value>
		public int LevelCount
		{
			get
			{
				return _levelCount;
			}
			set
			{
				_levelCount = value;
			}
		}
		/// <summary>
		/// Gets the state of the game. That is, whether
		/// it is running, loading etc.
		/// <see cref="GameState"/>
		/// </summary>
		/// <value>The state of the game.</value>
		public GameState GameState
		{
			get
			{
				return _gameState;
			}
			set
			{
				_gameState = value;
			}
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="NewGameBase"/> class.
		/// </summary>
		public NewGameBase()
		{
		}
		public void StartLevel()
        {
			GameState = GameState.Running;
		}

		/// <summary>
		/// Starts the game by loading the first level.
		/// </summary>
		public void Start()
		{
			string[] files = Directory.GetFiles(LevelDirectory, "*.skbn");
			LevelCount = files.Length;
			LoadLevel(52);
		}
		public string GetFileNameByLevelNumber(int parLevelNumber)
        {
			return string.Format(@"{0}Level{1:000}.skbn", LevelDirectory, parLevelNumber);
		}

		/// <summary>
		/// Reloads and then starts the current level
		/// from the beginning.
		/// </summary>
		public abstract void RestartLevel();
		/// <summary>
		/// Loads the level specified with the specified level number.
		/// </summary>
		/// <param name="parLevelNumber">The level number of the level to load.</param>
		public abstract void LoadLevel(int parLevelNumber);


		/// <summary>
		/// Tests whether the specified location is within 
		/// the Levels grid.
		/// </summary>
		/// <param name="parLocation">The location to test
		/// whether it is within the level grid.</param>
		/// <returns><code>true</code> if the location
		/// is within the Level>; 
		/// <code>false</code> otherwise.</returns>
		public abstract bool InBounds(Location parLocation);

		public abstract void Level_LevelCompleted(object sender, EventArgs e);

		/// <summary>
		/// Attempts to go to the next level.
		/// </summary>
		public abstract void GotoNextLevel();
		/// <summary>
		/// Start the current level
		/// </summary>
	}
}
