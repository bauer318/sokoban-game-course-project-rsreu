using Controller.Records;
using Model.GameRecord;
using System.Collections.Generic;
using View.Record;
using ViewWPF.MenuGraphics;
using ViewWPF.Records;

namespace ControllerWPF.Records
{
    public class ControllerRecordWPF : ControllerRecordBase
    {
        private readonly ViewRecordWPF _viewRecordWPF;

        public ControllerRecordWPF(ViewRecordBase parViewRecordBase) : base(parViewRecordBase)
        {
            _viewRecordWPF = parViewRecordBase as ViewRecordWPF;
            ProcessPrintRecord();
            ViewMenuMainWPF.MainWindow.Content = _viewRecordWPF.DockPanel;
        }

        public void ProcessPrintRecord()
        {
            Dictionary<int, Record> dictionary = GetRecordDictionary();
            _viewRecordWPF.ProcessPrintRecord(dictionary);
        }

    }
}
