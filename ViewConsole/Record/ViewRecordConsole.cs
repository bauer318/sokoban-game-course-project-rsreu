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
        public override void PrintExceptionMessage(string parMessage)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(parMessage);
        }
    }
}
