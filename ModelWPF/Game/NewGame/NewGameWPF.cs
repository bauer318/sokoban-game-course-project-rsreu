//using Model.PlayGame.Locations;
//using Model.PlayGame.NewGame;
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
    public class NewGameWPF : NewGameBase, INotifyPropertyChanged
    {
        private SynchronizationContext context = SynchronizationContext.Current;
		
		private GameState gameState;
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
		public LevelWPF Level
		{
			get;
			private set;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GameLevel"/> class.
		/// </summary>
		public NewGameWPF():base()
		{
		}


		/// <summary>
		/// Loads the level specified with the specified level number.
		/// </summary>
		/// <param name="levelNumber">The level number of the level to load.</param>
		public override void LoadLevel(int levelNumber)
		{
			GameState = GameState.Loading;

			if (Level != null)
			{
				/* Detach the level completed event. */
				Level.LevelCompleted -= new EventHandler(Level_LevelCompleted);
			}

			Level = new LevelWPF(this, levelNumber);
			Level.LevelCompleted += new EventHandler(Level_LevelCompleted);
			
			string fileName = string.Format(@"{0}Level{1:000}.skbn", LevelDirectory, levelNumber);
			using (StreamReader reader = File.OpenText(fileName))
			{
				Level.Load(reader);
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
		public override bool InBounds(Location location)
		{
			return Level.InBounds(location);
		}

		public override void Level_LevelCompleted(object sender, EventArgs e)
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
		public override void GotoNextLevel()
		{
			if (Level.LevelNumber < LevelCount)
			{
				LoadLevel(Level.LevelNumber + 1);
			}
		}

		public override void StartLevel()
		{
			GameState = GameState.Running;
		}

		/// <summary>
		/// Reloads and then starts the current level
		/// from the beginning.
		/// </summary>
		public override void RestartLevel()
		{
			LoadLevel(Level != null ? Level.LevelNumber : 0);
		}
	}
}
