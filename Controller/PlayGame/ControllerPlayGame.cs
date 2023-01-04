using Model.PlayGame.Commands;
using Model.PlayGame.Levels;
using Model.PlayGame.LevelsPlayed;
using Model.PlayGame.Locations;
using Model.PlayGame.NewGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public ViewNewGameBase ViewNewGameBase;
        /// <summary>
        /// Provides for working with level's played file
        /// </summary>
        public LevelPlayedUtils LevelPlayedUtils { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parViewNewGameBase">The base view for a new game</param>
        public ControllerPlayGame(ViewNewGameBase parViewNewGameBase) : base()
        {
            ViewNewGameBase = parViewNewGameBase;
            LevelPlayedUtils = new LevelPlayedUtils(true);
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