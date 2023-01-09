using System.Runtime.Versioning;

namespace SokobanConsole
{
    /// <summary>
    /// Runner's class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Console's game main method
        /// </summary>
        /// <param name="args"></param>
        [SupportedOSPlatform("windows")]
        static void Main(string[] args)
        {

            new ControllerConsole.Menu.ControllerMenuMainConsole().Start();
        }
    }
}
