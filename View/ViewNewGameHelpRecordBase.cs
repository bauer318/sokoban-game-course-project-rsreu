using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    /// <summary>
    /// The base view for the new game and record
    /// </summary>
    public abstract class ViewNewGameHelpRecordBase
    {
        /// <summary>
        /// Prints an exception's message
        /// </summary>
        /// <param name="parMessage">The exception's message</param>
        public abstract void PrintMessage(string parMessage);
    }
}
