using Model.PlayGame.Locations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.NewGame
{
    public abstract class NewGameBase
    {
        public string levelDirectory = @"..\..\..\..\Levels\";
		/// <summary>
		/// Gets the number of levels available
		/// to be played in a game.
		/// </summary>
		/// <value>The the number of levels in the game.</value>
		public int LevelCount
		{
			get;
			set;
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="NewGameBase"/> class.
		/// </summary>
		public NewGameBase()
		{
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
		public abstract bool InBounds(Location location);

		public abstract void Level_LevelCompleted(object sender, EventArgs e);

		/// <summary>
		/// Attempts to go to the next level.
		/// </summary>
		public abstract void GotoNextLevel();
		public abstract void StartLevel();
		
		/// <summary>
		/// Starts the game by loading the first level.
		/// </summary>
		public void Start()
		{
			string[] files = Directory.GetFiles(levelDirectory, "*.skbn");
			LevelCount = files.Length;
			LoadLevel(52);
		}

		/// <summary>
		/// Reloads and then starts the current level
		/// from the beginning.
		/// </summary>
		public abstract void RestartLevel();
	}
}
