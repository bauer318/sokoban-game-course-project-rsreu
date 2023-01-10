using ControllerWPF.Menu;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SokobanWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Occurs when the WPF's application startup
        /// </summary>
        /// <param name="parSender">The sender's object</param>
        /// <param name="parEvent">The event sended</param>
        private void Application_Startup(object parSender, StartupEventArgs parEvent)
        {
            new ControllerMenuMainWPF().Start();
        }
    }
}
