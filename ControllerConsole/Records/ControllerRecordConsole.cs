using Controller.Records;
using System;
using System.Threading;
using View.Record;
using ViewConsole.Records;

namespace ControllerConsole.Records
{
    /// <summary>
    /// The record's controller
    /// </summary>
    public class ControllerRecordConsole : ControllerRecordBase
    {
        /// <summary>
        /// The record's view
        /// </summary>
        private readonly ViewRecordConsole _viewRecordConsole;
        /// <summary>
        /// Indicates whether is need to print the record
        /// </summary>
        private bool _needPrint = true;
        /// <summary>
        /// Initializes the record's controller
        /// </summary>
        /// <param name="parViewRecordBase">The record's base view</param>
        public ControllerRecordConsole(ViewRecordBase parViewRecordBase) : base(parViewRecordBase)
        {
            _viewRecordConsole = parViewRecordBase as ViewRecordConsole;
            _viewRecordConsole.PrintColumnsName();
            while (true)
            {
                if (_needPrint)
                {
                    Thread t = new(() => 
                    {
                        _viewRecordConsole.ProcessPrintRecord(GetRecordDictionary());
                    });
                    t.Name = "Thread record's view";
                    t.Start();
                    
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
