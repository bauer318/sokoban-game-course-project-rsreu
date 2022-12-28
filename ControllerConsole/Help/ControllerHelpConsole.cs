using Controller.Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Help;
using ViewConsole.Help;

namespace ControllerConsole.Help
{
    public class ControllerHelpConsole:ControllerHelpBase
    {
        private ViewHelpConsole _viewHelpConsole;
        private bool _needPrint = true;
        public ControllerHelpConsole(ViewHelpBase parViewHelpBase) : base(parViewHelpBase)
        {
            _viewHelpConsole = parViewHelpBase as ViewHelpConsole;
            ProcessPrintHelpText();
        }
        
        private void ProcessPrintHelpText()
        {
            while (true)
            {
                if (_needPrint)
                {
                    string[] textHelpArray = GetArrayTextHelpFile(true);
                    _viewHelpConsole.PrintHelpText(textHelpArray);
                }
                _needPrint = false;
                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                if (keyPressed.Key == ConsoleKey.Escape )
                {
                    _viewHelpConsole.BackToMainMenu();
                    break;

                }
            }
        }
    }
}
