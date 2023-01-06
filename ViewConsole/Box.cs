using Model.PlayGame.Levels;
using System;

namespace ViewConsole
{
    public class Box
    {
        public int x;
        public int y;
        public int row;
        public int col;
        public ConsoleColor color;
        
        char[,] symbols = new char[3, 3];
        private string _boxName;
        private object _colorLock = new();
        public static Level Level { get; set; }
        public Box(int x, int y, ConsoleColor color) : this(x, y)
        {
            this.color = color;
        }
        public Box(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Box(int x, int y, ConsoleColor color, int row, int col, string boxName) : this(x, y, color)
        {
            this.row = row;
            this.col = col;
            this._boxName = boxName;
        }

        public void InitBox(char symbol)
        {
            for (var i = 0; i < symbols.GetLength(0); i++)
            {
                for (var j = 0; j < symbols.GetLength(1); j++)
                {
                    symbols[i, j] = symbol;
                }
            }
        }
        public void DrawBox()
        {

            Console.ForegroundColor = this.color;
            switch (_boxName)
            {
                case ("Wall"):
                    DrawWall();
                    break;
                case ("TreasureOnFloor"):
                    DrawTreasureOnFloor();
                    break;
                case ("ActorOnFloor"):
                    DrawActor();
                    break;
                case ("EmptyFloor"):
                    DrawEmptyFloor();
                    break;
                case ("Space"):
                    DrawSpace();
                    break;
                case ("TreasureOnGoal"):
                    DrawTreasureOnFloor();
                    break;
                case ("EmptyGoal"):
                    DrawGoal();
                    break;

            }
           
        }

        private void DrawWall()
        {
            for (var i = 0; i < this.symbols.GetLength(0); i++)
            {
                for (var j = 0; j < this.symbols.GetLength(1); j++)
                {
                    Console.SetCursorPosition(this.x + i, this.y + j);
                    Console.Write(this.symbols[i, j]);
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        private void DrawSpace()
        {
            for (var i = 0; i < this.symbols.GetLength(0); i++)
            {
                for (var j = 0; j < this.symbols.GetLength(1); j++)
                {
                    Console.SetCursorPosition(this.x + i, this.y + j);
                    Console.Write(" ");
                }
            }
            
        }
        private void DrawEmptyFloor()
        {
            for (var i = 0; i < this.symbols.GetLength(0); i++)
            {
                for (var j = 0; j < this.symbols.GetLength(1); j++)
                {
                    Console.SetCursorPosition(this.x + i, this.y + j);
                    Console.Write(".");
                }
            }

        }
        private void DrawActor()
        {
            for (var i = 0; i < this.symbols.GetLength(0); i++)
            {
                for (var j = 0; j < this.symbols.GetLength(1); j++)
                {
                    Console.SetCursorPosition(this.x + i, this.y + j);
                    /*if(i==1 && j == 1)
                    {
                        ConsoleColor backg = Console.BackgroundColor;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("*");
                        Console.ForegroundColor = this.color;
                        Console.BackgroundColor = backg;
                    }
                    else*/
                    //{
                        Console.Write(this.symbols[i, j]);
                    //}
                    /*if ((i == 0 && j == 0) || (i == 0 && j == 2) || (i == 2 && j == 1))
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(" ");
                        Console.ForegroundColor = this.color;
                    }
                    else if ((i == 0 || i == 1) && j == 1)
                    {
                        Console.Write("|");
                    }
                    else if ((i==1 || i==2) && j==0)
                    {
                        Console.Write("/");
                    }
                    else
                    {
                        Console.Write("\\");
                    }*/
                }
            }
            //Console.ForegroundColor = ConsoleColor.Blue;
        }
        private void DrawTreasureOnGoal()
        {
            for (var i = 0; i < this.symbols.GetLength(0); i++)
            {
                for (var j = 0; j < this.symbols.GetLength(1); j++)
                {
                    Console.SetCursorPosition(this.x + i, this.y + j);
                    if ((i == 0 && j == 0) || (i == 0 && j == 2) || (i == 2 && j == 0) || (i == 2 && j == 2))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("*");
                        Console.ForegroundColor = this.color;
                    }
                    else
                    {
                        Console.Write(this.symbols[i, j]);
                    }
                }
            }
            Console.BackgroundColor = ConsoleColor.Gray;
        }
        private void DrawTreasureOnFloor()
        {
            for (var i = 0; i < this.symbols.GetLength(0); i++)
            {
                for (var j = 0; j < this.symbols.GetLength(1); j++)
                {
                    Console.SetCursorPosition(this.x + i, this.y + j);
                    /*if((i==0 && j == 0) || (i == 0 && j == 2) || (i == 2 && j == 0) || (i == 2 && j == 2))
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("*");
                        Console.ForegroundColor = this.color;
                    }
                    else
                    {*/
                        Console.Write(this.symbols[i, j]);
                    //}
                }
            }
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        private void DrawGoal()
        {
            for (var i = 0; i < this.symbols.GetLength(0); i++)
            {
                for (var j = 0; j < this.symbols.GetLength(1); j++)
                {
                    Console.SetCursorPosition(this.x + i, this.y + j);
                    /*if ((i == 0 && j == 1) || (i == 2 && j == 1))
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(".");
                        Console.ForegroundColor = this.color;
                    }
                    else if(i==1 && j == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(" ");
                        Console.ForegroundColor = this.color;
                    }
                    else
                    {*/
                        Console.Write(this.symbols[i, j]);
                    //}
                }
            }
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        
    }
}
