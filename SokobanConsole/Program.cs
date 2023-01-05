using System.Runtime.Versioning;

namespace SokobanConsole
{
    /// <summary>
    /// Runner's class
    /// </summary>
    class Program
    {
        [SupportedOSPlatform("windows")]
        static void Main(string[] args)
        {
            new ControllerConsole.Menu.ControllerMenuMainConsole().Start();
        }
    }
}
