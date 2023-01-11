using Model.GameRecord;
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
        /// The main's grid
        /// </summary>
        private Grid _gridMain;

        /// <summary>
        /// Print a message
        /// </summary>
        /// <param name="parMessage">The message to print</param>
        public override void PrintMessage(string parMessage)
        {
            MessageBox.Show(parMessage);
        }

        /// <summary>
        /// Print game's record text
        /// </summary>
        /// <param name="parTextHelpArray"></param>
        public void PrintRecordText(Dictionary<int, Record> parRecordDictionary)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                TextBox textBox = new()
                {
                    Margin = new Thickness(10, 20, 10, 0),
                    TextWrapping = TextWrapping.Wrap,
                    AcceptsReturn = true,
                    VerticalScrollBarVisibility = ScrollBarVisibility.Auto
                };
                int[] keyValues = new int[parRecordDictionary.Count];
                var count = 0;
                foreach (KeyValuePair<int, Record> elRecordDictionr in parRecordDictionary)
                {
                    keyValues[count] = elRecordDictionr.Key;
                    count++;
                }
                
                textBox.Text = String.Format("{0,10}", "Уровень");
                textBox.Text += String.Format("{0,75}", "Количество шагов");
                textBox.Text += String.Format("{0,75}", "Дата и время\n\n");
                for (var j=0; j<parRecordDictionary.Count; j++)
                {
                    textBox.Text += String.Format("{0,10}",(keyValues[j] + 1).ToString());
                    textBox.Text += String.Format("{0,80}",parRecordDictionary[keyValues[j]].MoveCount.ToString());
                    textBox.Text += String.Format("{0,90}",parRecordDictionary[keyValues[j]].LastDateTime.ToString() + "\n\n");
                }
                _gridMain = new Grid();
                _gridMain.Children.Clear();
                _gridMain.RowDefinitions.Clear();
                _gridMain.ColumnDefinitions.Clear();
                _gridMain.RowDefinitions.Add(new RowDefinition());
                _gridMain.ColumnDefinitions.Add(new ColumnDefinition());
                _gridMain.Children.Add(textBox);

                _dockPanel = new DockPanel();
                _dockPanel.Children.Add(_gridMain);
                ViewMenuMainWPF.MainWindow.Content = _dockPanel;
            });
            

        }
    }
}
