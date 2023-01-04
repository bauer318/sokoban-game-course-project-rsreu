using Controller.Records;
using System;
using View.Record;
using ViewConsole.Records;

namespace ControllerConsole.Records
{
    public class ControllerRecordConsole : ControllerRecordBase
    {
        private ViewRecordConsole _viewRecordConsole;
        private bool _needPrint = true;
        public ControllerRecordConsole(ViewRecordBase parViewRecordBase) : base(parViewRecordBase)
        {
            _viewRecordConsole = parViewRecordBase as ViewRecordConsole;
            _viewRecordConsole.PrintTitle();
            while (true)
            {
                if (_needPrint)
                {
                    _viewRecordConsole.ProcessPrintRecord(GetRecordDictionary());
                }
                _needPrint = false;
                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                if (keyPressed.Key == ConsoleKey.Escape)
                {
                    _viewRecordConsole.BackToMainMenu();
                    break;

                }

            }

        }

    }
}
