using Model.PlayGame.Locations;
using Model.PlayGame.NewGame;
using ModelWPF.Game.Levels;
using System;
using System.IO;

namespace ModelWPF.Game.NewGame
{
    /// <summary>
    /// The main class for the game of Sokoban.
    /// </summary>
    public class NewGameWPF : NewGameBase
    {
        /// <summary>
        /// The state of Game
        /// </summary>
        private GameState _gameState;
        /// <summary>
        /// The current level of the game
        /// </summary>
        private LevelWPF _level;
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
            private set
            {
                _gameState = value;
                //OnPropertyChanged("GameState");
            }
        }

        /// <summary>
        /// Gets the current level of the game.
        /// </summary>
        /// <value>The current level. May be <code>null</code>.</value>
        public LevelWPF Level
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
        /// Initializes a new instance of the <see cref="NewGameWPF"/> class.
        /// </summary>
        public NewGameWPF() : base()
        {
        }
        /// <summary>
        /// Loads the level specified with the specified level number.
        /// </summary>
        /// <param name="parLevelNumber">The level number of the level to load.</param>
        public override void LoadLevel(int parLevelNumber)
        {
            GameState = GameState.Loading;

            if (Level != null)
            {
                /* Detach the level completed event. */
                Level.LevelCompleted -= new EventHandler(Level_LevelCompleted);
            }

            Level = new LevelWPF(this, parLevelNumber);
            Level.LevelCompleted += new EventHandler(Level_LevelCompleted);

            string fileName = string.Format(@"{0}Level{1:000}.skbn", LevelDirectory, parLevelNumber);
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
        /// is within the <see cref="LevelWPF"/>; 
        /// <code>false</code> otherwise.</returns>
        public override bool InBounds(Location parLocation)
        {
            return Level.InBounds(parLocation);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Start the Level
        /// </summary>
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
