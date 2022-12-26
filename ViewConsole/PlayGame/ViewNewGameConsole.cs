﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.PlayGame;
using ViewConsole.Menu;

namespace ViewConsole.PlayGame
{
    public class ViewNewGameConsole : ViewNewGameBase
    {
        private ViewMenuConsole _viewMenuConsole;
        public List<CellButtonLocation> CellButtonLocations { get; set; } = new List<CellButtonLocation>();

        public ViewMenuConsole ViewMenuConsole
        {
            get
            {
                return _viewMenuConsole;
            }
            set
            {
                _viewMenuConsole = value;
            }
        }
        public override void PrintExceptionMessage(string parMessage)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(parMessage);
        }

        public void InitCellButtonLocation(int parRowCount, int parColumnCount)
        {
            CellButtonLocations.Clear();
            if(parRowCount<=_viewMenuConsole.HEIGHT && parColumnCount <= _viewMenuConsole.WIDTH)
            {
                Console.Clear();
                var startLeft = (_viewMenuConsole.WIDTH - parColumnCount) / 2;
                var startTop = (_viewMenuConsole.HEIGHT - parRowCount) / 2;
                for (var row = 0; row < parRowCount; row++)
                {
                    startTop++;
                    var left = startLeft;
                    for (var col = 0; col < parColumnCount; col++)
                    {
                        left++;
                        CellButtonLocations.Add(new CellButtonLocation(left, startTop, row, col));
                    }
                }
            }
            else
            {
                PrintExceptionMessage("Error!!!");
            }

        }
        public CellButtonLocation GetCellButtonLocation(int parCellRow, int parCellCol)
        {
           return CellButtonLocations.Find(c => c.X == parCellRow && c.Y==parCellCol);
        }
        public void DrawWall()
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("0");
            Console.ForegroundColor = ConsoleColor.Black;
        }
        public void DrawTreasure()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("#");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public void DrawEmptyGoal()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(".");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void DrawTreasureOnGoal()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public void DrawEmptyFloor()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(".");
        }
        public void DrawTreasureOnFloor()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("#");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void DrawActorOnFloor()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void DrawSpace()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
        }
        public void SetLeftTopConsoleCursor(int parRow, int parCol)
        {
            Console.CursorLeft = parCol;
            Console.CursorTop = parRow;
        }
        public void BackToMainMenu()
        {
            _viewMenuConsole.Draw();
        }

    }
}
