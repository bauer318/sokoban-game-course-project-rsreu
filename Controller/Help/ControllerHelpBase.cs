using Model.CommonWork;
using Model.GameRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Help
{
    /// <summary>
    /// Base implementation for Help's controller
    /// </summary>
    public abstract class ControllerHelpBase
    {
        /// <summary>
        /// Provides for write and read files
        /// </summary>
        private OutputInputFileWriterReader _outputInputFileWriterReader;
        /// <summary>
        /// Default's constructor
        /// </summary>
        public ControllerHelpBase()
        {
            _outputInputFileWriterReader = new OutputInputFileWriterReader();
        }
        /// <summary>
        /// Get the text array of the Help file
        /// </summary>
        /// <param name="parIsConsole">True if it is for console game</param>
        /// <returns></returns>
        public string[] GetArrayTextHelpFile(bool parIsConsole)
        {
            return _outputInputFileWriterReader.ReadHelpFile(parIsConsole);
        }
    }
}
