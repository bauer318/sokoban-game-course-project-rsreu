using Controller.Records;
using Model.GameRecord;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Windows.Controls;
using View.Record;
using ViewWPF.MenuGraphics;
using ViewWPF.Record;

namespace ControllerWPF.Records
{
    public class ControllerRecordWPF : ControllerRecordBase
    {
        private ViewRecordWPF _viewRecordWPF;

        public ControllerRecordWPF(ViewRecordBase parViewRecordBase) : base(parViewRecordBase)
        {
            _viewRecordWPF = parViewRecordBase as ViewRecordWPF;
            ProcessPrintRecord();
            ViewMenuMainWPF.MainWindow.Content = _viewRecordWPF.DockPanel;
        }

        public void ProcessPrintRecord()
        {
            Dictionary<int, Record> dictionary = GetRecordDictionary();
            DataGrid dataGrid = _viewRecordWPF.CreateRecordDataGrid();
            int[] keyValues = new int[dictionary.Count];
            var count = 0;
            foreach (KeyValuePair<int, Record> entry in dictionary)
            {
                keyValues[count] = entry.Key;
                count++;
            }

            for (var j = 0; j < dictionary.Count; j++)
            {
                dynamic row = new ExpandoObject();
                string[] values = new string[3];
                values[0] = keyValues[j].ToString();
                values[1] = dictionary[keyValues[j]].MoveCount.ToString();
                values[2] = dictionary[keyValues[j]].LastDateTime.ToString();
                for (int i = 0; i < _viewRecordWPF.ColumsnName.Length; i++)
                    ((IDictionary<String, Object>)row)[_viewRecordWPF.ColumsnName[i].Replace(' ', '_')] = values[i];
                dataGrid.Items.Add(row);
            }
            _viewRecordWPF.DataGridToScrollView(dataGrid);
        }

    }
}
