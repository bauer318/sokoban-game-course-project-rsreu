using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewConsole.PlayGame
{
    public class CellButtonLocation
    {
        public int XMap { get; set; } //Left Console
        public int YMap { get; set; } //Top Console
        public int X { get; set; } //Row level
        public int Y { get; set; } //Col level
        public CellButtonLocation(int parXMap, int parYMap, int parX, int parY)
        {
            XMap = parXMap;
            YMap = parYMap;
            X = parX;
            Y = parY;
        }

    }
}
