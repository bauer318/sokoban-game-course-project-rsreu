using Model.PlayGame.LevelsPlayed;
using View.PlayGame;

namespace Controller.PlayGame
{
    /// <summary>
    /// Base class for a New Game Controller
    /// </summary>
    public abstract class ControllerPlayGame : ControllerNewGameRecordBase
    {
        /// <summary>
        /// The base view for a new game
        /// </summary>
        private ViewNewGameBase _viewNewGameBase;
        /// <summary>
        /// Provides for working with the level's played file
        /// </summary>
        private LevelPlayedUtils _levelPlayedUtils;
        /// <summary>
        /// Get or Set the base view for a new game
        /// </summary>
        public ViewNewGameBase ViewNewGameBase
        {
            get
            {
                return _viewNewGameBase;
            }
            private set
            {
                _viewNewGameBase = value;
            }
        }
        /// <summary>
        /// Get or Set the level's played utils
        /// </summary>
        public LevelPlayedUtils LevelPlayedUtils
        {
            get
            {
                return _levelPlayedUtils;
            }
            set
            {
                _levelPlayedUtils = value;
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parViewNewGameBase">The base view for a new game</param>
        public ControllerPlayGame(ViewNewGameBase parViewNewGameBase) : base()
        {
            _viewNewGameBase = parViewNewGameBase;
            _levelPlayedUtils = new LevelPlayedUtils(true);
        }
        /// <summary>
        /// Update a record after that a level has been completed succefuly
        /// </summary>
        /// <param name="parLevelNumber">The current level's number</param>
        /// <param name="parMoveCount">The Actor move count</param>
        public void UpdateRecord(int parLevelNumber, int parMoveCount)
        {
            RecordUtils.UpdateRecord(parLevelNumber, parMoveCount);
        }
        /// <summary>
        /// Process go to the next level by doing ctrl + N
        /// </summary>
        public abstract void ProcessNextLevel();
        /// <summary>
        /// Process back to previous level by doing ctrl + P
        /// </summary>
        public abstract void ProcessPreviousLevel();
    }
}