using ModelWPF.Game.Command;
using ModelWPF.Game.Levels;
using ModelWPF.Game.Locations;
using ModelWPF.Game.NewGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using View.PlayGame;
//using ViewWPF;
//using ViewWPF.PlayGame;
using CommandManager = ModelWPF.Game.Command.CommandManager;

namespace ControllerWPF.PlayGame
{
    public class ControllerPlayGame
    {
        public delegate CommandBase dCommand(Level parLevel, Direction parDirection);
        public event dCommand Comman;
        private ViewNewGameBase _viewNewGameWPF;
        public static GameLevel Game;
        public static readonly CommandManager commandManager = new CommandManager();
        private Window _mainWindow;
        public delegate void dReinitChoseenMenu(Window mainWindow);
        public event dReinitChoseenMenu ReinitChoseenMenu;
        public ControllerPlayGame(ViewNewGameBase parViewNewGameWPF, Window parMainWindow)
        {
            _viewNewGameWPF = parViewNewGameWPF;
            //Game = _viewNewGameWPF.Game;
            _mainWindow = parMainWindow;
            commandManager.Clear();
            parMainWindow.KeyDown += new KeyEventHandler(Window_KeyDown);
            TryToStartFirstLevel();
            //_viewNewGameWPF.InitChosenMenu(_mainWindow);
        }

        private void TryToStartFirstLevel()
        {
            try
            {
                /* Load and start the first level of the game. */
                Game.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem loading game. " + ex.Message);
            }
        }
        public  void Window_KeyDown(object sender, KeyEventArgs e)
        {
            CommandBase command = null;
            Level level = Game.Level;
            if (Game != null)
            {
                if (Game.GameState == GameState.Running)
                {
                    switch (e.Key)
                    {
                        case Key.Up:
                            command = new MoveCommand(level, Direction.Up);
                            break;
                        case Key.Down:
                            command = new MoveCommand(level, Direction.Down);
                            break;
                        case Key.Left:
                            command = new MoveCommand(level, Direction.Left);
                            break;
                        case Key.Right:
                            command = new MoveCommand(level, Direction.Right);
                            break;
                        case Key.Z:
                            if (Keyboard.Modifiers == ModifierKeys.Control)
                            {
                                commandManager.Undo();
                            }
                            break;
                        case Key.Y:
                            if (Keyboard.Modifiers == ModifierKeys.Control)
                            {
                                commandManager.Redo();
                            }
                            break;
                    }
                }
                else
                {
                    switch (Game.GameState)
                    {
                        case GameState.GameOver:
                            Game.Start();
                            break;
                        case GameState.LevelCompleted:
                            Game.GotoNextLevel();
                            /*_viewNewGameWPF.firstStartLevel = false;
                            ReinitChoseenMenu += new dReinitChoseenMenu(_viewNewGameWPF.InitChosenMenu);
                            ReinitChoseenMenu.Invoke(_mainWindow);*/
                            break;
                    }
                }
            }
            if (command != null)
            {
                commandManager.Execute(command);
            }
        }
    }
}
