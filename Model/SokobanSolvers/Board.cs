using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.SokobanSolvers
{
    public class Board
    {
        public string Cur { get;  set; }
        public string Sol { get;  set; }
        public int X { get;  set; }
        public int Y { get;  set; }

        public Board(string cur, string sol, int x, int y)
        {
            Cur = cur;
            Sol = sol;
            X = x;
            Y = y;
        }
    }
}
