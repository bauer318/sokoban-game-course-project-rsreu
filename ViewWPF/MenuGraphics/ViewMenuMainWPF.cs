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
using ViewWPF.Records;

namespace ViewWPF.MenuGraphics
{
    /// <summary>
    /// Representes the main menu's view
    /// </summary>
    public class ViewMenuMainWPF : ViewMenuWPF
    {
		/// <summary>
        /// The main windows as the main's application container
        /// </summary>
		public static MainWindow MainWindow = null;
        /// <summary>
        /// The main's stackpanel 
        /// </summary>
        private static  StackPanel _mainStackPanel = null;
        /// <summary>
        /// Indicates whether the main's menu is active
        /// </summary>
        private bool _isMenuMainActive = true;
        /// <summary>
        /// The selected menu's item index
        /// </summary>
        private int _indexMenuItemFocused = 0;
        /// <summary>
        /// The main's menu
        /// </summary>
        private readonly Model.Menu.Menu _menu;
        /// <summary>
        /// Initializes the main's menu view
        /// </summary>
        /// <param name="parSubMenuItem">The submenu's item</param>
        public ViewMenuMainWPF(Model.Menu.Menu parSubMenuItem) : base(parSubMenuItem)
        {
            _menu = parSubMenuItem;
        }
        /// <summary>
        /// Inititializes all parameters for the main menu's view
        /// </summary>
        public void Init()
        {
            MainWindow = MainWindow.GetInstance();

            _mainStackPanel = new StackPanel();
            _mainStackPanel.VerticalAlignment = VerticalAlignment.Center;
            _mainStackPanel.HorizontalAlignment = HorizontalAlignment.Center;
            StackPanel textStackPanel = new StackPanel();
            textStackPanel.VerticalAlignment = VerticalAlignment.Center;
            textStackPanel.HorizontalAlignment = HorizontalAlignment.Center;
            Label label = new()
            {
                Content = "SOKOBAN",
                FontSize = 25,
                Margin = new Thickness(0, 20, 0, 45)
            };
            textStackPanel.Children.Add(label);
            _mainStackPanel.Children.Add(textStackPanel);
            MainWindow.Content = _mainStackPanel;

            SetParentControl(_mainStackPanel);
            Draw();
            MainWindow.PreviewKeyDown += new KeyEventHandler(HandleEsc);
            MainWindow.Show();
        }
        /// <summary>
        /// Close the main windows - stop the application's process
        /// </summary>
        public void Close()
        {
            MainWindow.Close();
        }
        /// <summary>
        /// Set the selected menu's item index when the NewGame's menu is selected
        /// And disables the main's menu
        /// </summary>
        public void NewGame()
        {
            _indexMenuItemFocused = 0;
            DisablesMainMenu();
        }

        /// <summary>
        /// Set the selected menu's item index when the Help's menu is selected
        /// And disables the main's menu
        /// </summary>
        public void Help()
        {
            _indexMenuItemFocused = 1;
            DisablesMainMenu();

        }
        /// <summary>
        /// Set the selected menu's item index when the Record's menu is selected
        /// And disables the main's menu
        /// </summary>
        public void Record()
        {
            _indexMenuItemFocused = 3;
            DisablesMainMenu();
        }
        /// <summary>
        /// Disables the main menu
        /// </summary>
        private void DisablesMainMenu()
        {
            _isMenuMainActive = false;
        }
        /// <summary>
        /// Controll the KeyDown - especially for Escape key to back to the main's menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape && !_isMenuMainActive)
            {
                _menu.FocusItemById(_indexMenuItemFocused);
                BackToMainMenu();
            }
        }
        /// <summary>
        /// Back to main's menu
        /// </summary>
        public static void BackToMainMenu()
        {
            MainWindow.Content = _mainStackPanel;
        }
        /// <summary>
        /// Draw the main's menu
        /// </summary>
        public override void Draw()
        {

            foreach (View.Menu.ViewMenuItem elViewMenuItem in Menu)
            {
                elViewMenuItem.Draw();
            }
        }

    }
}
