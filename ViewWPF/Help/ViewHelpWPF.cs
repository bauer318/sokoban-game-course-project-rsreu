using System.Windows;
using System.Windows.Controls;
using View.Help;

namespace ViewWPF.Help
{
    public class ViewHelpWPF : ViewHelpBase
    {
        private DockPanel _dockPanel;
        private Grid _gridMain;
        public DockPanel DockPanel
        {
            get
            {
                return _dockPanel;
            }
        }

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
        public override void PrintMessage(string parMessage)
        {
            MessageBox.Show(parMessage);
        }
        public void PrintTextHelpGame(string[] parTextHelpArray)
        {
            TextBox textBox = new()
            {
                Margin = new Thickness(10, 20, 10, 0),
                TextWrapping = TextWrapping.Wrap,
                AcceptsReturn = true,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto
            };

            foreach (string s in parTextHelpArray)
            {
                textBox.Text += s + "\n";

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

        }
    }
}
