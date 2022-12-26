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
        private int[,] map = { 
            {1,2,2,2,3,3,3,3,3 },
            {3,2,2,2,4,5,2,2,3 },
            {3,2,4,2,2,3,2,5,3 },
            {3,3,3,3,3,3,3,3,3 } };
        public ControllerPlayGameConsole(ViewNewGameBase parViewNewGameBase):base(parViewNewGameBase)
        {
            _viewNewGameConsole = parViewNewGameBase as ViewNewGameConsole;
            _viewNewGameConsole.InitCellButtonLocation(map.GetLength(0),map.GetLength(1));
            SetCellButtonStyle();
            Thread.Sleep(1000);
            map[0, 0] = 2;
            map[0, 1] = 1;
            SetCellButtonStyle();
            Thread.Sleep(1000);
            map[0, 1] = 2;
            map[1, 1] = 1;
            SetCellButtonStyle();
            Thread.Sleep(1000);
            map[1, 1] = 2;
            map[1, 2] = 1;
            SetCellButtonStyle();
            Thread.Sleep(1000);
            map[1, 2] = 2;
            map[1, 3] = 1;
            SetCellButtonStyle();
            Thread.Sleep(1000);
            map[1, 3] = 2;
            map[1, 4] = 1;
            map[1, 5] = 4;
            SetCellButtonStyle();
        }

        public override void ProcessDrawGameLevel()
        {
            throw new NotImplementedException();
        }

        public override void SetCellButtonStyle()
        {
            _viewNewGameConsole.CellButtonLocations.ForEach(c => 
            {
                _viewNewGameConsole.SetLeftTopConsoleCursor(c.YMap, c.XMap);
                if (map[c.X, c.Y] == 1)
                {
                    _viewNewGameConsole.DrawActor();
                }
                else if (map[c.X, c.Y] == 2)
                {
                    //_viewNewGameConsole.SetLeftTopConsoleCursor(c.YMap, c.XMap);
                    _viewNewGameConsole.DrawFloorSpace();
                }
                else if(map[c.X, c.Y] == 3)
                {
                    //_viewNewGameConsole.SetLeftTopConsoleCursor(c.YMap, c.XMap);
                    _viewNewGameConsole.DrawWall();
                } 
                else if (map[c.X, c.Y] == 4)
                {
                    //_viewNewGameConsole.SetLeftTopConsoleCursor(c.YMap, c.XMap);
                    _viewNewGameConsole.DrawTreasure();
                }
                else if(map[c.X,c.Y]==5)
                {
                    _viewNewGameConsole.DrawGoal();
                }
            });
        }

        public override void TryToStartFirstLevel()
        {
            throw new NotImplementedException();
        }
    }
}
