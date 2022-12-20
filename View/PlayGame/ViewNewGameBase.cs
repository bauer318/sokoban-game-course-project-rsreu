using Model.PlayGame.NewGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.PlayGame
{
    public abstract class ViewNewGameBase
    {
        public Game Game;
        public abstract void InitialiseLevel();
    }
}
