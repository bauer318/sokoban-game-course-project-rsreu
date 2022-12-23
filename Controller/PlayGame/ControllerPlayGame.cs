using Model.PlayGame.Commands;
using Model.PlayGame.Levels;
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
    public abstract class ControllerPlayGame
    {
        public ViewNewGameBase ViewNewGameBase;
        public ControllerPlayGame(ViewNewGameBase parViewNewGameBase)
        {
            ViewNewGameBase = parViewNewGameBase;
        }
    }
}