using Controller.Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Help;
using ViewWPF.Help;
using ViewWPF.MenuGraphics;

namespace ControllerWPF.Help
{
    /// <summary>
    /// Help's controller
    /// </summary>
    public class ControllerHelpWPF:ControllerHelpBase
    {
        /// <summary>
        /// Help's View
        /// </summary>
        private readonly ViewHelpWPF _viewHelpWPF;
        /// <summary>
        /// Initializes the Help's controller
        /// </summary>
        /// <param name="parViewHelpBase">Help's base view</param>
        public ControllerHelpWPF(ViewHelpBase parViewHelpBase) : base(parViewHelpBase)
        {
            _viewHelpWPF = parViewHelpBase as ViewHelpWPF;
            ProcessPrintHelpText();
            ViewMenuMainWPF.MainWindow.Content = _viewHelpWPF.DockPanel;
        }
        /// <summary>
        /// Processes to print the help's text
        /// </summary>
        public void ProcessPrintHelpText()
        {
            string[] textHelpArray = GetArrayTextHelpFile(false);
            _viewHelpWPF.PrintTextHelpGame(textHelpArray);
        }
    }
}
