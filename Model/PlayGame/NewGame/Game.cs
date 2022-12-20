using Model.PlayGame.Levels;
using Model.PlayGame.Locations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model.PlayGame.NewGame
{
    public abstract class Game
    {
        string levelDirectory = @"..\..\..\..\Levels\";
        ISokobanService sokobanService;
        SynchronizationContext context = SynchronizationContext.Current;
		/// <summary>
		/// Gets the number of levels available
		/// to be played in a game.
		/// </summary>
		/// <value>The the number of levels in the game.</value>
		public int LevelCount
		{
			get;
			private set;
		}

		private GameState gameState;

		/// <summary>
		/// Gets the state of the game. That is, whether
		/// it is running, loading etc.
		/// <see cref="GameState"/>
		/// </summary>
		/// <value>The state of the game.</value>
		public  GameState GameState
		{
			get
			{
				return gameState;
			}
			private set
			{
				gameState = value;
			}
		}

		/// <summary>
		/// Gets the current level of the game.
		/// </summary>
		/// <value>The current level. May be <code>null</code>.</value>
		public Level Level
		{
			get;
			private set;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GameLevel"/> class.
		/// </summary>
		public Game()
		{
		}

		public Game(ISokobanService sokobanService)
		{
			this.sokobanService = sokobanService;
		}

		/// <summary>
		/// Loads the level specified with the specified level number.
		/// </summary>
		/// <param name="levelNumber">The level number of the level to load.</param>
		public abstract void LoadLevel(int levelNumber);
		
		/// <summary>
		/// Tests whether the specified location is within 
		/// the Levels grid.
		/// </summary>
		/// <param name="location">The location to test
		/// whether it is within the level grid.</param>
		/// <returns><code>true</code> if the location
		/// is within the <see cref="Level"/>; 
		/// <code>false</code> otherwise.</returns>
		public bool InBounds(Location location)
		{
			return Level.InBounds(location);
		}

		void Level_LevelCompleted(object sender, EventArgs e)
		{
			if (Level.LevelNumber < LevelCount - 1)
			{
				GameState = GameState.LevelCompleted;
			}
			else
			{
				/* Do finished game stuff. */
				GameState = GameState.GameCompleted;
			}
		}

		/// <summary>
		/// Attempts to go to the next level.
		/// </summary>
		public void GotoNextLevel()
		{
			if (Level.LevelNumber < LevelCount)
			{
				LoadLevel(Level.LevelNumber + 1);
			}
		}

		void StartLevel()
		{
			GameState = GameState.Running;
		}

		/// <summary>
		/// Starts the game by loading the first level.
		/// </summary>
		public void Start()
		{

			if (sokobanService != null)
			{
				LevelCount = sokobanService.LevelCount;
			}
			else
			{   /* This should be refactored into the DefaultSokobanService. */
				string[] files = Directory.GetFiles(levelDirectory, "*.skbn");
				LevelCount = files.Length;
			}
			LoadLevel(51);
		}

		/// <summary>
		/// Reloads and then starts the current level
		/// from the beginning.
		/// </summary>
		public void RestartLevel()
		{
			LoadLevel(Level != null ? Level.LevelNumber : 0);
		}
	}
}
