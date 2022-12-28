using Model.CommonWork;
using Model.GameRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Help;

namespace Controller.Help
{
    /// <summary>
    /// Base implementation for Help's controller
    /// </summary>
    public abstract class ControllerHelpBase
    {
        /// <summary>
        /// The base view for the Help
        /// </summary>
        public ViewHelpBase ViewHelpBase;
        /// <summary>
        /// Provides for write and read files
        /// </summary>
        private OutputInputFileWriterReader _outputInputFileWriterReader;
        /// <summary>
        /// Default's constructor
        /// </summary>
        public ControllerHelpBase(ViewHelpBase parViewHelpBase)
        {
            _outputInputFileWriterReader = new OutputInputFileWriterReader();
            ViewHelpBase = parViewHelpBase;
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
