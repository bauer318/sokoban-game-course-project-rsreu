using System.Runtime.Versioning;

namespace SokobanConsole
{
    class Program
    {
        [SupportedOSPlatform("windows")]
        static void Main(string[] args)
        {
            new ControllerConsole.Menu.ControllerMenuMainConsole().Start();
        }
    }
}
