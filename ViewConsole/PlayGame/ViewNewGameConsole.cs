using System;
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(parMessage);
        }

        public void TestFirst()
        {
            Console.Clear();
            Console.CursorLeft = 20;
            Console.Write("Here we go!");
        }

        public void BackToMainMenu()
        {
            _viewMenuConsole.Draw();
        }

    }
}
