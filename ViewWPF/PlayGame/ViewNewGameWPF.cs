using ModelWPF.Game.Cells;
using ModelWPF.Game.NewGame;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using View.PlayGame;

namespace ViewWPF.PlayGame
{
    public partial class ViewNewGameWPF : ViewNewGameBase
    {
        private DockPanel _dockPanel;
        public DockPanel DockPanel
        {
            get
            {
                return _dockPanel;
            }
        }
        public void DrawGameLevel(GameLevel parGameLevel)
        {
            Border border = new Border();
            border.Padding = new Thickness(20, 0, 0, 0);
            border.CornerRadius = new CornerRadius(12);
            border.BorderThickness = new Thickness(0, 0, 0, 0);

            Viewbox viewbox = new Viewbox();
            viewbox.Stretch = Stretch.Uniform;

            Grid grid_Game = new Grid();
            grid_Game.Children.Clear();
            grid_Game.RowDefinitions.Clear();
            grid_Game.ColumnDefinitions.Clear();

            Grid grid_Main = new Grid();
            grid_Main.Children.Clear();
            grid_Main.RowDefinitions.Clear();
            grid_Main.ColumnDefinitions.Clear();

            var rowCount = parGameLevel.Level.RowCount;
            var columnCount = parGameLevel.Level.ColumnCount;
            for (var i = 0; i < rowCount; i++)
            {
                grid_Game.RowDefinitions.Add(new RowDefinition());

            }
            for (var i = 0; i < columnCount; i++)
            {
                grid_Game.ColumnDefinitions.Add(new ColumnDefinition());

            }

            for (var row = 0; row < rowCount; row++)
            {

                for (var column = 0; column < columnCount; column++)
                {
                    CellWPF cell = parGameLevel.Level[row, column];
                    Button button = new Button();
                    button.Focusable = false;
                    button.DataContext = cell;
                    button.Padding = new Thickness(0, 0, 0, 0);
                    button.Style = (Style)Application.Current.FindResource("Cell");
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, column);
                    grid_Game.Children.Add(button);
                }
            }
            viewbox.Child = grid_Game;
            grid_Main.RowDefinitions.Add(new RowDefinition());
            grid_Main.ColumnDefinitions.Add(new ColumnDefinition());
            grid_Main.Children.Add(viewbox);
            grid_Main.DataContext = parGameLevel.Level;
            grid_Main.Focus();
            _dockPanel = new DockPanel();
            _dockPanel.Children.Add(grid_Main);
        }
        public void SetApplicationResourceDictionary(ResourceDictionary parResourceDictionary)
        {
            Application.Current.Resources.MergedDictionaries.Add(parResourceDictionary);
        }

        public override void PrintExceptionMessage(string parMessage)
        {
            MessageBox.Show(parMessage);
        }

    }
}
