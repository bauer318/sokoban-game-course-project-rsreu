using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ViewWPF.MenuGraphics;

namespace ViewWPF.Record
{
    public class ViewRecordWPF : IMenuChosen
    {
        public void InitChosenMenu()
        {
            Button button = new Button();
            button.Content = "here will be the record page.";
            StackPanel stackPanel = new StackPanel();
            stackPanel.VerticalAlignment = VerticalAlignment.Center;
            stackPanel.HorizontalAlignment = HorizontalAlignment.Center;
            stackPanel.Children.Add(button);
            ViewMenuMainWPF.MainWindow.Content = stackPanel;
        }
    }
}
