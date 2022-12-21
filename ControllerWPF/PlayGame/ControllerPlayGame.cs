using Model.PlayGame.Commands;
using Model.PlayGame.Locations;
using Model.PlayGame.NewGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using View.PlayGame;
using CommandManager = ModelWPF.Game.Command.CommandManager;

namespace ControllerWPF.PlayGame
{
    public class ControllerPlayGame:Controller.PlayGame.ControllerPlayGame
    {
        private Window _mainWindow;
        public delegate void dReinitChoseenMenu(Window mainWindow);
        public event dReinitChoseenMenu ReinitChoseenMenu;
        public ControllerPlayGame(ViewNewGameBase parViewNewGameWPF, Window parMainWindow):base(parViewNewGameWPF)
        {
           
            _mainWindow = parMainWindow;
            parMainWindow.KeyDown += new KeyEventHandler(Window_KeyDown);
            TryToStartFirstLevel();
            
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
            Model.PlayGame.Levels.Level level = Game.Level;
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
                                CommandManager.Undo();
                            }
                            break;
                        case Key.Y:
                            if (Keyboard.Modifiers == ModifierKeys.Control)
                            {
                                CommandManager.Redo();
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
                CommandManager.Execute(command);
            }
        }
    }
}
