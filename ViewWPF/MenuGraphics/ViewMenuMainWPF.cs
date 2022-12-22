using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using View.PlayGame;
using ViewWPF.GameMap;
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
            //Draw();
        }
        public void Init()
        {
            MainWindow = new MainWindow();

            _mainStackPanel = new StackPanel();
            _mainStackPanel.VerticalAlignment = VerticalAlignment.Center;
            _mainStackPanel.HorizontalAlignment = HorizontalAlignment.Center;
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
            _isMenuMainActive = false;
           
        }
     

        public void Help()
        {
            _isMenuMainActive = false;
           

        }

        public void CreateGameMap()
        {
            _isMenuMainActive = false;
        }

        public void Record()
        {
            _isMenuMainActive = false;
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape && !_isMenuMainActive)
            {
                ReturnToMainMenu();
            }
        }
        public static void ReturnToMainMenu()
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
