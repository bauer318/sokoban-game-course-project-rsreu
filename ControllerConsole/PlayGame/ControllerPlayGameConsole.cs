using Controller.PlayGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using View.PlayGame;
using ViewConsole.PlayGame;

namespace ControllerConsole.PlayGame
{
    public class ControllerPlayGameConsole:ControllerPlayGame
    {
        private ViewNewGameConsole _viewNewGameConsole;

        public ControllerPlayGameConsole(ViewNewGameBase parViewNewGameBase):base(parViewNewGameBase)
        {
            _viewNewGameConsole = parViewNewGameBase as ViewNewGameConsole;
            _viewNewGameConsole.TestFirst();
            Thread.Sleep(1000);
            _viewNewGameConsole.BackToMainMenu();
        }
    }
}
