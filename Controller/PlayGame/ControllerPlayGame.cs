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
       /* public delegate CommandBase dCommand(Level parLevel, Direction parDirection);
        public event dCommand Command;
        public readonly CommandManager CommandManager = new CommandManager();
        private Game _game;
        public Game Game
        {
            get
            {
                return _game;
            }
            set
            {
                _game = value;
            }
        }
        
        private ViewNewGameBase _viewNewGameBase;
        public ViewNewGameBase ViewNewGameBase
        {
            get
            {
                return _viewNewGameBase;
            }
            set
            {
                _viewNewGameBase = value;
            }
        }
        public ControllerPlayGame(ViewNewGameBase parViewNewGameBase)
        {
            _viewNewGameBase = parViewNewGameBase;
            _game = _viewNewGameBase.Game;
            CommandManager.Clear();
        }*/
    }
}
