using Model.PlayGame.Levels;
using Model.PlayGame.LevelsPlayed;
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
	public class Game
	{
		/// <summary>
		/// The last played level's number
		/// </summary>
		private int _lastPlayedLevelNumber;
		/// <summary>
		/// The current level of the game
		/// </summary>
		private Level _level;
		/// <summary>
		/// The state of Game
		/// </summary>
		private GameState _gameState;
		/// <summary>
		/// The the number of levels in the game
		/// </summary>
		private int _levelCount;
		/// <summary>
		/// Gets the current level of the game.
		/// </summary>
		/// <value>The current level. May be <code>null</code>.</value>
		/// /// <summary>
		/// The levels'folder directory
		/// </summary>
		public const string LevelDirectory = @"..\..\..\..\Levels\";
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
		/// Initializes a new instance of the <see cref="Game"/> class.
		/// </summary>
		public Game()
		{
			LevelPlayedUtils levelPlayedUtils = new(true);
			_lastPlayedLevelNumber = levelPlayedUtils.LevelPlayed.GetLastLevelPlayed();
		}
		/// <summary>
		/// Start the current level
		/// </summary>
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
			LoadLevel(_lastPlayedLevelNumber);
		}
		/// <summary>
		/// Get the level's filename by the level's number
		/// </summary>
		/// <param name="parLevelNumber">The level's number</param>
		/// <returns></returns>
		public string GetFileNameByLevelNumber(int parLevelNumber)
        {
			return string.Format(@"{0}Level{1:000}.skbn", LevelDirectory, parLevelNumber);
		}

		/// <summary>
		/// Reloads and then starts the current level
		/// from the beginning.
		/// </summary>
		public void RestartLevel()
        {
			LoadLevel(Level != null ? Level.LevelNumber : 0);
		}
		/// <summary>
		/// Loads the level specified with the specified level number.
		/// </summary>
		/// <param name="parLevelNumber">The level number of the level to load.</param>
		public void LoadLevel(int parLevelNumber)
        {
			GameState = GameState.Loading;

			if (Level != null)
			{
				/* Detach the level completed event. */
				Level.LevelCompleted -= new EventHandler(Level_LevelCompleted);
			}

			Level = new Level(this, parLevelNumber);
			Level.LevelCompleted += new EventHandler(Level_LevelCompleted);

			string fileName = GetFileNameByLevelNumber(parLevelNumber);
			using (StreamReader reader = File.OpenText(fileName))
			{
				Level.Load(reader);
			}
			StartLevel();

		}


		/// <summary>
		/// Tests whether the specified location is within 
		/// the Levels grid.
		/// </summary>
		/// <param name="parLocation">The location to test
		/// whether it is within the level grid.</param>
		/// <returns><code>true</code> if the location
		/// is within the Level>; 
		/// <code>false</code> otherwise.</returns>
		public bool InBounds(Location parLocation)
        {
			return Level.InBounds(parLocation);
		}
		/// <summary>
		/// Occurs when the current level is completed succefuly
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void Level_LevelCompleted(object sender, EventArgs e)
        {
			if (Level.LevelNumber < LevelCount - 1)
			{
				GameState = GameState.LevelCompleted;
			}
			else
			{
				/* Do finished game stuff. */
				GameState = GameState.GameOver;
			}
		}

		/// <summary>
		/// Attempts to go to the next level.
		/// </summary>
		public  void GotoNextLevel()
        {

			if (Level.LevelNumber < LevelCount)
			{
				LoadLevel(Level.LevelNumber + 1);
			}
		}
		/// <summary>
		/// Attemps to back to the previous level
		/// </summary>
		public void BackToPreviousLevel()
        {
			if(Level.LevelNumber > 0)
            {
				LoadLevel(Level.LevelNumber - 1);
            }
        }
		
	}
}
