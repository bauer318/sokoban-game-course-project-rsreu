using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace ViewWPF
{
    /// <summary>
    /// The main window
    /// </summary>
    public class MainWindow:Window
    {
        /// <summary>
        /// The main window's instance
        /// </summary>
        private static MainWindow instance;
        /// <summary>
        /// The lock's object 
        /// </summary>
        private static readonly object syncRoot = new();
        /// <summary>
        /// Initializes the main window
        /// </summary>
        private MainWindow()
        {
            ShowActivated = true;
            Width = 720;
            Height = 450;
            ResizeMode = ResizeMode.NoResize;
            WindowStyle = WindowStyle.None;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        /// <summary>
        /// Get the Main window's instance - pattern singleton
        /// </summary>
        /// <returns></returns>
        public static MainWindow getInstance()
        {
            lock (syncRoot)
            {
                if (instance == null)
                {
                    instance = new MainWindow();
                }
            }
            return instance;
        }
    }
}
