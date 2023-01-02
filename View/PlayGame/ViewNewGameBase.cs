using Model.PlayGame.Commands;
using Model.PlayGame.NewGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.PlayGame
{
    /// <summary>
    /// Base view for the new game
    /// </summary>
    public abstract class ViewNewGameBase: ViewNewGameHelpRecordBase
    {
        /// <summary>
        /// Provides for execution and undoing a command
        /// </summary>
        public CommandManager CommandManager = new CommandManager();
        /// <summary>
        /// Indicates whether it is the first level, first time to selected the new game menu
        /// </summary>
        public bool FirstStartLevel = true;
        /// <summary>
        /// Attempts to start the game's first level
        /// </summary>
        public abstract void TryToStartFirstLevel();
        /// <summary>
        ///Process drawing a game Level
        /// </summary>
        public abstract void ProcessDrawGameLevel();
        
    }
}
