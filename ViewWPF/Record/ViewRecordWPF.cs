using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using View.Record;
using ViewWPF.MenuGraphics;

namespace ViewWPF.Record
{
    public class ViewRecordWPF : ViewRecordBase
    {
        private DockPanel _dockPanel;
        public string[] ColumsnName { get; private set; }
        public DockPanel DockPanel
        {
            get
            {
                return _dockPanel;
            }
        }
        private Grid _gridMain;

        public Grid GridMain
        {
            get
            {
                return _gridMain;
            }
            private set
            {
                _gridMain = value;
            }
        }
        public override void PrintExceptionMessage(string parMessage)
        {
            MessageBox.Show(parMessage);
        }
        public DataGrid CreateRecordDataGrid()
        {

            DataGrid dataGrid = new DataGrid();
            dataGrid.Margin = new Thickness(0, 20, 0, 0);

            ColumsnName = new string[] { "Уровень", "Количество шагов", "Дата и время" };

            foreach (string label in ColumsnName)
            {
                DataGridTextColumn column = new DataGridTextColumn();
                column.Header = label;
                column.Binding = new Binding(label.Replace(' ', '_'));
                column.Width = 235;
                dataGrid.Columns.Add(column);
            }
            dataGrid.Width = ViewMenuMainWPF.MainWindow.Width;
            return dataGrid;

        }
        public void DataGridToScrollView(DataGrid parDataGrid)
        {
            ScrollViewer scrollViewer = new ScrollViewer();
            scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            scrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            scrollViewer.Content = parDataGrid;

            _gridMain = new Grid();
            _gridMain.Children.Clear();
            _gridMain.RowDefinitions.Clear();
            _gridMain.ColumnDefinitions.Clear();
            _gridMain.RowDefinitions.Add(new RowDefinition());
            _gridMain.ColumnDefinitions.Add(new ColumnDefinition());
            _gridMain.Children.Add(scrollViewer);

            _dockPanel = new DockPanel();
            _dockPanel.Children.Add(_gridMain);
        }
    }
}
