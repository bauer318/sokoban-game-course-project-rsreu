using Model.PlayGame.Locations;
using Model.PlayGame.NewGame;
using ModelWPF.Game.Levels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModelWPF.Game.NewGame
{
    public class GameLevel : INotifyPropertyChanged
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

		GameState gameState;

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
				return gameState;
			}
			private set
			{
				gameState = value;
				OnPropertyChanged("GameState");
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
		public GameLevel()
		{
		}

		public GameLevel(ISokobanService sokobanService)
		{
			this.sokobanService = sokobanService;
		}

		/// <summary>
		/// Loads the level specified with the specified level number.
		/// </summary>
		/// <param name="levelNumber">The level number of the level to load.</param>
		void LoadLevel(int levelNumber)
		{
			GameState = GameState.Loading;

			if (Level != null)
			{
				/* Detach the level completed event. */
				Level.LevelCompleted -= new EventHandler(Level_LevelCompleted);
			}

			Level = new Level(this, levelNumber);
			Level.LevelCompleted += new EventHandler(Level_LevelCompleted);
			string levelMap;

			if (sokobanService != null)
			{
				levelMap = sokobanService.GetMap(levelNumber);
				using (StringReader reader = new StringReader(levelMap))
				{
					Level.Load(reader);
				}
			}
			else
			{
				string fileName = string.Format(@"{0}Level{1:000}.skbn", levelDirectory, levelNumber);
				using (StreamReader reader = File.OpenText(fileName))
				{
					Level.Load(reader);
				}
			}

			OnPropertyChanged("Level");
			StartLevel();
		}
		event PropertyChangedEventHandler propertyChanged;

		/// <summary>
		/// Occurs when a property value changes.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged
		{
			add
			{
				propertyChanged += value;
			}
			remove
			{
				propertyChanged -= value;
			}
		}

		/// <summary>
		/// Raises the <see cref="E:PropertyChanged"/> event.
		/// </summary>
		/// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> 
		/// instance containing the event data.</param>
		void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			if (propertyChanged != null)
			{
				propertyChanged(this, e);
			}
		}

		/// <summary>
		/// Raises the <see cref="E:PropertyChanged"/> event.
		/// </summary>
		/// <param name="property">The name of the property that changed.</param>
		protected void OnPropertyChanged(string property)
		{
			/* We use the SynchronizationContext context
			 to ensure that we don't cause an InvalidOperationException
			 if the property change triggers something occuring
			 in the main UI thread. */
			if (context != null)
			{
				context.Send(delegate
				{
					OnPropertyChanged(new PropertyChangedEventArgs(property));
				}, null);
			}
			else
			{
				context = SynchronizationContext.Current;
				if (context == null)
				{
					OnPropertyChanged(new PropertyChangedEventArgs(property));
				}
				else
				{
					OnPropertyChanged(property);
				}
			}
		}

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
				GameState = GameState.GameOver;
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
			LoadLevel(52);
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
