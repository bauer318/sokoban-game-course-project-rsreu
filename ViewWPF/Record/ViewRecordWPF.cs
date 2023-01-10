﻿using Model.GameRecord;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using View.Record;
using ViewWPF.MenuGraphics;

namespace ViewWPF.Records
{
    /// <summary>
    /// Representes the record's view
    /// </summary>
    public class ViewRecordWPF : ViewRecordBase
    {
        /// <summary>
        /// Main dockpanel as main container's record view
        /// </summary>
        private DockPanel _dockPanel;
        /// <summary>
        /// The record grid columns's name
        /// </summary>
        private string[] _columnsName;
        /// <summary>
        /// The main's grid
        /// </summary>
        private Grid _gridMain;

        private DataGrid _datagrid;

        public ViewRecordWPF()
        {
            CreateRecordDataGrid();
        }
        /// <summary>
        /// Print a message
        /// </summary>
        /// <param name="parMessage">The message to print</param>
        public override void PrintMessage(string parMessage)
        {
            MessageBox.Show(parMessage);
        }
        /// <summary>
        /// Creates the record's datagrid
        /// </summary>
        /// <returns>The record's datagrid with columns's name</returns>
        private void CreateRecordDataGrid()
        {
            Application.Current.Dispatcher.Invoke(() => 
            {
                _datagrid = new()
                {
                    Margin = new Thickness(0, 20, 0, 0)
                };
                _columnsName = new string[] { "Уровень", "Количество шагов", "Дата и время" };

                foreach (string label in _columnsName)
                {
                    DataGridTextColumn column = new()
                    {
                        Header = label,
                        Binding = new Binding(label.Replace(' ', '_')),
                        Width = 235
                    };
                    _datagrid.Columns.Add(column);
                }
                _datagrid.Width = ViewMenuMainWPF.MainWindow.Width;
            });
        }
        /// <summary>
        /// Processes to print game's record
        /// </summary>
        /// <param name="parRecordDictionary">The record's dictionary as a pair of level's number and record</param>
        public void ProcessPrintRecord(Dictionary<int, Record> parRecordDictionary)
        {
            int[] keyValues = new int[parRecordDictionary.Count];
            var count = 0;
            foreach (KeyValuePair<int, Record> entry in parRecordDictionary)
            {
                keyValues[count] = entry.Key;
                count++;
            }
            ParallelOptions options = new()
            {
                MaxDegreeOfParallelism = 3
            };
            for (var j = 0; j < parRecordDictionary.Count; j++)
            {
                dynamic row = new ExpandoObject();
                string[] dataGridColumnsValues = new string[3];
                dataGridColumnsValues[0] = (keyValues[j]+1).ToString();
                dataGridColumnsValues[1] = parRecordDictionary[keyValues[j]].MoveCount.ToString();
                dataGridColumnsValues[2] = parRecordDictionary[keyValues[j]].LastDateTime.ToString();
                Parallel.ForEach(_columnsName, options, (line, state, index) => 
                {
                    ((IDictionary<String, Object>)row)[line.Replace(' ', '_')] = dataGridColumnsValues[index];
                });   
                Application.Current.Dispatcher.Invoke(() => 
                {
                    _datagrid.Items.Add(row);
                });
                
            }
            DataGridIntoScrollViewer();
            Application.Current.Dispatcher.Invoke(() =>
            {
                ViewMenuMainWPF.MainWindow.Content = _dockPanel;
            });
            
        }
        /// <summary>
        /// Add the datagrid in the scrollview 
        /// </summary>
        /// <param name="parDataGrid">The datagrid</param>
        private void DataGridIntoScrollViewer()
        {
            Application.Current.Dispatcher.Invoke(() => 
            {
                ScrollViewer scrollViewer = new()
                {
                    VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                    HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled,
                    Content = _datagrid
                };
                _gridMain = new Grid();
                _gridMain.Children.Clear();
                _gridMain.RowDefinitions.Clear();
                _gridMain.ColumnDefinitions.Clear();
                _gridMain.RowDefinitions.Add(new RowDefinition());
                _gridMain.ColumnDefinitions.Add(new ColumnDefinition());
                _gridMain.Children.Add(scrollViewer);

                _dockPanel = new DockPanel();
                _dockPanel.Children.Add(_gridMain);
            });
        }
    }
}
