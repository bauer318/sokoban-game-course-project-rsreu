using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Help;
using ViewConsole.Menu;

namespace ViewConsole.Help
{
    public class ViewHelpConsole : ViewHelpBase
    {

        private ViewMenuConsole _viewMenuConsole;
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
        public override void PrintMessage(string parMessage)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(parMessage);
        }
        public void PrintHelpText(string[] parArrayHelpText)
        {
            Console.Clear();
            foreach(string s in parArrayHelpText)
            {
                foreach(char c in s)
                {
                    if (c.Equals('0'))
                    {
                        DrawCellUtils.DrawWall();
                    }
                    else if (c.Equals('#'))
                    {
                        DrawCellUtils.DrawTreasureOnFloor();
                    }
                    else if (c.Equals('.'))
                    {
                        DrawCellUtils.DrawEmptyGoal();
                    }
                    else if (c.Equals('@'))
                    {
                        DrawCellUtils.DrawActorOnFloor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(c);
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
        }
        public void BackToMainMenu()
        {
            _viewMenuConsole.Draw();
        }
    }
}
