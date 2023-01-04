using Model.PlayGame.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.SokobanSolvers
{
    public class SokobanSolver
    {
        private string destBoard, currBoard;
        private int playerX, playerY, nCols;
        public Dictionary<int, Location> boxDictionaries = new Dictionary<int, Location>();
        public Dictionary<int, Location> goalDictionaries = new Dictionary<int, Location>();
        public SokobanSolver(string[] board)
        {
            nCols = board[0].Length;
            StringBuilder destBuf = new StringBuilder();
            StringBuilder currBuf = new StringBuilder();

            for (int r = 0; r < board.Length; r++)
            {
                for (int c = 0; c < nCols; c++)
                {

                    char ch = board[r][c];

                    destBuf.Append(ch != '$' && ch != '@' ? ch : ' ');
                    currBuf.Append(ch != '.' ? ch : ' ');

                    if (ch == '@')
                    {
                        this.playerX = c;
                        this.playerY = r;
                    }
                }
            }
            destBoard = destBuf.ToString();
            currBoard = currBuf.ToString();
        }
        public SokobanSolver() { }
        public void InitBoxDictionaries(string[] parLevels)
        {
            var countBox = 0;
            var countGoal = 0;
            for(var row = 0; row < parLevels.Length; row++)
            {
                for(var col = 0; col < parLevels[0].Length; col++)
                {
                    char c = parLevels[row][col];
                    if (c == '$')
                    {
                        boxDictionaries.Add(countBox++, new Location(row, col));
                    }
                    else if (c == '.')
                    {
                        goalDictionaries.Add(countGoal++, new Location(row, col));
                    }
                }
            }
        }
        private string Move(int x, int y, int dx, int dy, string trialBoard)
        {

            int newPlayerPos = (y + dy) * nCols + x + dx;

            if (trialBoard[newPlayerPos] != ' ')
                return null;

            char[] trial = trialBoard.ToCharArray();
            trial[y * nCols + x] = ' ';
            trial[newPlayerPos] = '@';

            return new string(trial);
        }

        private string Push(int x, int y, int dx, int dy, string trialBoard)
        {

            int newBoxPos = (y + 2 * dy) * nCols + x + 2 * dx;

            if (trialBoard[newBoxPos] != ' ')
                return null;

            char[] trial = trialBoard.ToCharArray();
            trial[y * nCols + x] = ' ';
            trial[(y + dy) * nCols + x + dx] = '@';
            trial[newBoxPos] = '$';

            return new string(trial);
        }

        private bool IsSolved(string trialBoard)
        {
            for (int i = 0; i < trialBoard.Length; i++)
                if ((destBoard[i] == '.')
                        != (trialBoard[i] == '$'))
                    return false;
            return true;
        }

        public string Solve()
        {
            char[,] dirLabels = { { 'u', 'U' }, { 'r', 'R' }, { 'd', 'D' }, { 'l', 'L' } };
            int[,] dirs = { { 0, -1 }, { 1, 0 }, { 0, 1 }, { -1, 0 } };
            ISet<string> history = new HashSet<string>();
            LinkedList<Board> open = new LinkedList<Board>();

            history.Add(currBoard);
            open.AddLast(new Board(currBoard, string.Empty, playerX, playerY));

            while (!open.Count.Equals(0))
            {
                Board item = open.First();
                open.RemoveFirst();
                string cur = item.Cur;
                string sol = item.Sol;
                int x = item.X;
                int y = item.Y;

                for (int i = 0; i < dirs.GetLength(0); i++)
                {
                    string trial = cur;
                    int dx = dirs[i, 0];
                    int dy = dirs[i, 1];

                    // are we standing next to a box ?
                    if (trial[(y + dy) * nCols + x + dx] == '$')
                    {
                        // can we push it ?
                        if ((trial = Push(x, y, dx, dy, trial)) != null)
                        {
                            // or did we already try this one ?
                            if (!history.Contains(trial))
                            {

                                string newSol = sol + dirLabels[i, 1];
                                Console.WriteLine("Sol 1 " + newSol);

                                if (IsSolved(trial))
                                    return newSol;

                                open.AddLast(new Board(trial, newSol, x + dx, y + dy));
                                history.Add(trial);
                            }
                        }
                        // otherwise try changing position
                    }
                    else if ((trial = Move(x, y, dx, dy, trial)) != null)
                    {
                        if (!history.Contains(trial))
                        {
                            string newSol = sol + dirLabels[i, 0];
                            Console.WriteLine("Sol 2 " + newSol);
                            open.AddLast(new Board(trial, newSol, x + dx, y + dy));
                            history.Add(trial);
                        }
                    }
                }
            }
            return "No solution";
        }

    }
}
