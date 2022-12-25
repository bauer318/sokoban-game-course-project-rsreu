using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using View.PlayGame;

namespace ViewWPF.PlayGame
{
    public partial class ViewNewGameWPF : ViewNewGameBase
    {
        private DockPanel _dockPanel;
        private List<ButtonCellLocation> _cellButtons = new List<ButtonCellLocation>();
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
        public List<ButtonCellLocation> CellButtons
        {
            get
            {
                return _cellButtons;
            }
        }
        public DockPanel DockPanel
        {
            get
            {
                return _dockPanel;
            }
        }

        public void DrawGameLevel(int parRowCount, int parColumnCount)
        {
            Border border = new Border();
            border.Padding = new Thickness(20, 0, 0, 0);
            border.CornerRadius = new CornerRadius(12);
            border.BorderThickness = new Thickness(0, 0, 0, 0);

            Viewbox viewbox = new Viewbox();
            viewbox.Stretch = Stretch.Uniform;

            Grid gridGame = new Grid();
            gridGame.Children.Clear();
            gridGame.RowDefinitions.Clear();
            gridGame.ColumnDefinitions.Clear();

            _gridMain = new Grid();
            _gridMain.Children.Clear();
            _gridMain.RowDefinitions.Clear();
            _gridMain.ColumnDefinitions.Clear();

            var rowCount = parRowCount;
            var columnCount = parColumnCount;
            for (var i = 0; i < rowCount; i++)
            {
                gridGame.RowDefinitions.Add(new RowDefinition());

            }
            for (var i = 0; i < columnCount; i++)
            {
                gridGame.ColumnDefinitions.Add(new ColumnDefinition());

            }

            for (var row = 0; row < rowCount; row++)
            {

                for (var column = 0; column < columnCount; column++)
                {
                    ButtonCellLocation button = new ButtonCellLocation(row, column);
                    button.Focusable = false;
                    button.Padding = new Thickness(0, 0, 0, 0);
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, column);
                    gridGame.Children.Add(button);
                    _cellButtons.Add(button);
                }
            }
            viewbox.Child = gridGame;
            _gridMain.RowDefinitions.Add(new RowDefinition());
            _gridMain.ColumnDefinitions.Add(new ColumnDefinition());
            _gridMain.Children.Add(viewbox);
            _gridMain.Focus();
            _dockPanel = new DockPanel();
            _dockPanel.Children.Add(_gridMain);
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
