using System.Windows;
using System.Windows.Controls;
using View.Help;

namespace ViewWPF.Help
{
    /// <summary>
    /// The Help's view
    /// </summary>
    public class ViewHelpWPF : ViewHelpBase
    {
        /// <summary>
        /// Dockpanel as main's help view container
        /// </summary>
        private DockPanel _dockPanel;
        /// <summary>
        /// Grid as main's help view grid
        /// </summary>
        private Grid _gridMain;
        /// <summary>
        /// Get the main's dockpanel
        /// </summary>
        public DockPanel DockPanel
        {
            get
            {
                return _dockPanel;
            }
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
        /// Print the help's text
        /// </summary>
        /// <param name="parTextHelpArray"></param>
        public void PrintTextHelpGame(string[] parTextHelpArray)
        {
            TextBox textBox = new()
            {
                Margin = new Thickness(10, 20, 10, 0),
                TextWrapping = TextWrapping.Wrap,
                AcceptsReturn = true,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto
            };

            foreach (string elString in parTextHelpArray)
            {
                textBox.Text += elString + "\n";

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
