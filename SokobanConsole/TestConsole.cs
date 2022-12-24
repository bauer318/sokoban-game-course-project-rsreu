using System;

namespace SokobanConsole
{
    public class TestConsole
    {
        private static int heroX = 10;
        private static int heroY = 10;
        private static int[,] map = {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,0,0,0,0,0,0,1,0,0,2,0,0,0,3,0,0,0,1 },
            {1,0,0,0,0,4,0,1,1,1,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,1,0,0,2,0,0,0,3,0,0,0,1 },
            {1,0,0,0,0,0,0,1,0,0,2,0,2,0,3,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,1,0,0,2,0,0,0,3,0,0,0,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 }};
        public static void DrawMap()
        {
            for (var y = 0; y < map.GetLength(1); y++)
            {
                for (var x = 0; x < map.GetLength(0); x++)
                {
                    Console.CursorLeft = y;
                    Console.CursorTop = x;
                    if (map[x, y] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Gray;

                        Console.Write((char)166);
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else if (map[x, y] == 2)
                    {
                        Console.Write("O");
                    }
                    else if (map[x, y] == 3)
                    {
                        Console.Write("#");
                    }
                    else if (map[x, y] == 4)
                    {
                        heroX = y;
                        heroY = x;
                    }
                }
            }

        }
        public static bool HeroCanStep(int x, int y)
        {
            return map[y, x] != 1;
        }
        public static void DrawHero()
        {

            Console.CursorLeft = heroX;
            Console.CursorTop = heroY;
            Console.Write("X");
        }

        public static bool HeroCanMoveBoxLeft(int x, int y)
        {
            if (map[y, x] == 2)
            {
                if (map[y, x - 1] == 0)
                {
                    map[y, x] = 0;
                    map[y, x - 1] = 2;
                    Console.CursorLeft = x - 1;
                    Console.CursorTop = y;
                    Console.Write("0");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public static bool HeroCanMoveBoxRight(int x, int y)
        {
            if (map[y, x] == 2)
            {
                if (map[y, x + 1] == 0)
                {
                    map[y, x] = 0;
                    map[y, x + 1] = 2;
                    Console.CursorLeft = x + 1;
                    Console.CursorTop = y;
                    Console.Write("0");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public static bool HeroCanMoveBoxUp(int x, int y)
        {
            if (map[y, x] == 2)
            {
                if (map[y-1, x] == 0)
                {
                    map[y, x] = 0;
                    map[y-1, x] = 2;
                    Console.CursorLeft = x;
                    Console.CursorTop = y-1;
                    Console.Write("0");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public static bool HeroCanMoveBoxDown(int x, int y)
        {
            if (map[y, x] == 2)
            {
                if (map[y+1, x] == 0)
                {
                    map[y, x] = 0;
                    map[y+1, x] = 2;
                    Console.CursorLeft = x;
                    Console.CursorTop = y+1;
                    Console.Write("0");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public static void HideHero()
        {

            Console.CursorLeft = heroX;
            Console.CursorTop = heroY;
            if (map[heroY, heroX] == 3)
            {
                Console.Write("#");
            }
            else
            {
                Console.Write(" ");
            }

        }
        public static void main()
        {
            Console.CursorVisible = false;
            DrawMap();
            DrawHero();
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (HeroCanStep(heroX, heroY - 1))
                    {
                        if(HeroCanMoveBoxUp(heroX, heroY - 1))
                        {
                            HideHero();
                            heroY--;
                            DrawHero();
                        }
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (HeroCanStep(heroX, heroY + 1))
                    {
                        if (HeroCanMoveBoxDown(heroX, heroY + 1))
                        {
                            HideHero();
                            heroY++;
                            DrawHero();
                        }
                    }
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (HeroCanStep(heroX - 1, heroY))
                    {
                        if (HeroCanMoveBoxLeft(heroX - 1, heroY))
                        {
                            HideHero();
                            heroX--;
                            DrawHero();
                        }
                    }
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    if (HeroCanStep(heroX + 1, heroY))
                    {
                        if (HeroCanMoveBoxRight(heroX + 1, heroY))
                        {
                            HideHero();
                            heroX++;
                            DrawHero();
                        }
                    }
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}
