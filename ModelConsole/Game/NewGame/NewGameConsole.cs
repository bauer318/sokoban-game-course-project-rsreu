using Model.PlayGame.Locations;
using Model.PlayGame.NewGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelConsole.Game.NewGame
{
    public class NewGameConsole : NewGameBase
    {
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
            }
        }
        public override void GotoNextLevel()
        {
            throw new NotImplementedException();
        }

        public override bool InBounds(Location parLocation)
        {
            throw new NotImplementedException();
        }

        public override void Level_LevelCompleted(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void LoadLevel(int parLevelNumber)
        {
            throw new NotImplementedException();
        }

        public override void RestartLevel()
        {
            throw new NotImplementedException();
        }

        public override void StartLevel()
        {
            throw new NotImplementedException();
        }
    }
}
