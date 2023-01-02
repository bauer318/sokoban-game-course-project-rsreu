using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Record;
using ViewConsole.Menu;

namespace ViewConsole.Record
{
    public class ViewRecordConsole : ViewRecordBase
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
        public void PrintTitle()
        {
            Console.Clear();
            Console.CursorLeft = 2;
            Console.Write("Уровень");
            Console.CursorLeft = 15;
            Console.Write("Количество шагов");
            Console.CursorLeft = 35;
            Console.Write("Дата и время");
            Console.WriteLine();
        }
        public void BackToMainMenu()
        {
            _viewMenuConsole.Draw();
        }
    }
}
