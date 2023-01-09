using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;


namespace ViewConsole.PlayGame
{
    /// <summary>
    /// Provides the console output for the new game's view
    /// </summary>
    public class ConsoleOutput
    {
        /// <summary>
        /// Representes the Consoleoutput's instance
        /// </summary>
        private static ConsoleOutput _instance;
        /// <summary>
        /// Representes the ConsoleFastOutput
        /// </summary>
        private static ConsoleFastOutput _consoleFastOutput;
        /// <summary>
        /// Provides to block when working with multithreading
        /// </summary>
        private static object _lock = new();
        /// <summary>
        /// Private default's contructor
        /// </summary>
        private ConsoleOutput()
        {
            _consoleFastOutput = new ConsoleFastOutput();
        }
        /// <summary>
        /// Get the ConsoleOutput's instance
        /// </summary>
        /// <returns>The instance of ConsoleOutput</returns>
        public static ConsoleOutput GetInstance()
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new ConsoleOutput();
                }
            }
            return _instance;
        }
        /// <summary>
        /// Get the ConsoleFastOutout
        /// </summary>
        /// <returns>The Consolefastoutput</returns>
        public ConsoleFastOutput GetConsoleFastOutput()
        {
            return _consoleFastOutput;
        }
    }
}
