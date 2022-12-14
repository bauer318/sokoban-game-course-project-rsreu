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
    public partial class MainWindow:Window
    {
        public MainWindow()
        {
            ShowActivated = true;
            Width = 720;
            Height = 450;
            ResizeMode = ResizeMode.NoResize;
            WindowStyle = WindowStyle.None;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
    }
}
