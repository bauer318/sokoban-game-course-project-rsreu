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
    /// <summary>
    /// Help's controller
    /// </summary>
    public class ControllerHelpConsole:ControllerHelpBase
    {
        /// <summary>
        /// Help's View
        /// </summary>
        private ViewHelpConsole _viewHelpConsole;
        /// <summary>
        /// Indicates whether is need to print the help's text
        /// </summary>
        private bool _needPrint = true;
        /// <summary>
        /// Initializes the Help's controller
        /// </summary>
        /// <param name="parViewHelpBase">Help's base view</param>
        public ControllerHelpConsole(ViewHelpBase parViewHelpBase) : base(parViewHelpBase)
        {
            _viewHelpConsole = parViewHelpBase as ViewHelpConsole;
            ProcessPrintHelpText();
        }
        /// <summary>
        /// Processes to print the help's text
        /// </summary>
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
