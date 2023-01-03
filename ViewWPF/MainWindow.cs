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
    public class MainWindow:Window
    {
        private static MainWindow instance;
        private static readonly object syncRoot = new();
        private MainWindow()
        {
            ShowActivated = true;
            Width = 720;
            Height = 450;
            ResizeMode = ResizeMode.NoResize;
            WindowStyle = WindowStyle.None;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

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
