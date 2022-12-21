using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ViewWPF.MenuGraphics;

namespace ViewWPF.GameMap
{
    public class ViewCreateGameMapWPF : IMenuChosen
    {
        public void InitChosenMenu()
        {
            Button button = new Button();
            button.Content = "here will be map's editor page.";
            StackPanel stackPanel = new StackPanel();
            stackPanel.VerticalAlignment = VerticalAlignment.Center;
            stackPanel.HorizontalAlignment = HorizontalAlignment.Center;
            stackPanel.Children.Add(button);
            ViewMenuMainWPF.MainWindow.Content = stackPanel;
        }
    }
}
