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
    public abstract class ViewNewGameBase : ViewNewGameHelpRecordBase
    {
        /// <summary>
        /// Indicates whether it is the first level, first time to selected the new game menu
        /// </summary>
        public bool FirstStartLevel = true;
    }
}
