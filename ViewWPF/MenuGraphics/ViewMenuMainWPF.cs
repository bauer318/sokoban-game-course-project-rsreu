using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using View.PlayGame;
using ViewWPF.Help;
using ViewWPF.PlayGame;
using ViewWPF.Record;

namespace ViewWPF.MenuGraphics
{
    public class ViewMenuMainWPF : ViewMenuWPF
    {
		
		public static MainWindow MainWindow = null;
        private static  StackPanel _mainStackPanel = null;
        private bool _isMenuMainActive = true;
       
        public ViewMenuMainWPF(Model.Menu.Menu parSubMenuItem) : base(parSubMenuItem)
        {
          
        }
        public void Init()
        {
            MainWindow = new MainWindow();

            _mainStackPanel = new StackPanel();
            _mainStackPanel.VerticalAlignment = VerticalAlignment.Center;
            _mainStackPanel.HorizontalAlignment = HorizontalAlignment.Center;
            StackPanel textStackPanel = new StackPanel();
            textStackPanel.VerticalAlignment = VerticalAlignment.Center;
            textStackPanel.HorizontalAlignment = HorizontalAlignment.Center;
            Label label = new Label();
            label.Content = "SOKOBAN";
            label.FontSize = 25;
            label.Margin = new Thickness(0, 20, 0, 45);
            textStackPanel.Children.Add(label);
            _mainStackPanel.Children.Add(textStackPanel);
            MainWindow.Content = _mainStackPanel;

            SetParentControl(_mainStackPanel);
            Draw();
            MainWindow.PreviewKeyDown += new KeyEventHandler(HandleEsc);
            MainWindow.Show();
        }
        public void Close()
        {
            MainWindow.Close();
        }
        public void NewGame()
        {
            DesactivesMainMenu();
        }
     

        public void Help()
        {
            DesactivesMainMenu();

        }

        public void CreateGameMap()
        {
            DesactivesMainMenu();
        }

        public void Record()
        {
            DesactivesMainMenu();
        }
        private void DesactivesMainMenu()
        {
            _isMenuMainActive = false;
        }
        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape && !_isMenuMainActive)
            {
                BackToMainMenu();
            }
        }
        public static void BackToMainMenu()
        {
            MainWindow.Content = _mainStackPanel;
        }
        public override void Draw()
        {

            foreach (View.Menu.ViewMenuItem elViewMenuItem in Menu)
            {
                elViewMenuItem.Draw();
            }
        }

    }
}
