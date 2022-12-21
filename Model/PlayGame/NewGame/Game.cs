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

	
		/// <summary>
		/// Gets the current Level of the game.
		/// </summary>
		/// <value>The current Level. May be <code>null</code>.</value>
		public Level Level
		{
			get;
			set;
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
		/// Loads the Level specified with the specified Level number.
		/// </summary>
		/// <param name="levelNumber">The Level number of the Level to load.</param>
		public abstract void LoadLevel(int levelNumber);
		
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
			return Level.InBounds(location);
		}
		/// <summary>
		/// Attempts to go to the next Level.
		/// </summary>
		public void GotoNextLevel()
		{
			if (Level.LevelNumber < LevelCount)
			{
				LoadLevel(Level.LevelNumber + 1);
			}
		}

		public abstract void StartLevel();
		

		/// <summary>
		/// Starts the game by loading the first Level.
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
		/// Reloads and then starts the current Level
		/// from the beginning.
		/// </summary>
		public void RestartLevel()
		{
			LoadLevel(Level != null ? Level.LevelNumber : 0);
		}
	}
}
