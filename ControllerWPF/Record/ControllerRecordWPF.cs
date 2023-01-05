using Controller.Records;
using Model.GameRecord;
using System.Collections.Generic;
using View.Record;
using ViewWPF.MenuGraphics;
using ViewWPF.Records;

namespace ControllerWPF.Records
{
    /// <summary>
    /// The record's controller
    /// </summary>
    public class ControllerRecordWPF : ControllerRecordBase
    {
        /// <summary>
        /// The record's view
        /// </summary>
        private readonly ViewRecordWPF _viewRecordWPF;
        /// <summary>
        /// Initializes the record's controller
        /// </summary>
        /// <param name="parViewRecordBase">The record's base view</param>
        public ControllerRecordWPF(ViewRecordBase parViewRecordBase) : base(parViewRecordBase)
        {
            _viewRecordWPF = parViewRecordBase as ViewRecordWPF;
            ProcessPrintRecord();
            ViewMenuMainWPF.MainWindow.Content = _viewRecordWPF.DockPanel;
        }
        /// <summary>
        /// Processes to print the record
        /// </summary>
        public void ProcessPrintRecord()
        {
            Dictionary<int, Record> dictionary = GetRecordDictionary();
            _viewRecordWPF.ProcessPrintRecord(dictionary);
        }

    }
}
