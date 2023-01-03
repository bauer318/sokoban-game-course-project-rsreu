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
    public class ControllerHelpWPF:ControllerHelpBase
    {
        private readonly ViewHelpWPF _viewHelpWPF;
        public ControllerHelpWPF(ViewHelpBase parViewHelpBase) : base(parViewHelpBase)
        {
            _viewHelpWPF = parViewHelpBase as ViewHelpWPF;
            ProcessPrintHelpText();
            ViewMenuMainWPF.MainWindow.Content = _viewHelpWPF.DockPanel;
        }

        public void ProcessPrintHelpText()
        {
            string[] textHelpArray = GetArrayTextHelpFile(false);
            _viewHelpWPF.PrintTextHelpGame(textHelpArray);
        }
    }
}
