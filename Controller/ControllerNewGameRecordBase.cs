using Model.CommonWork;
using Model.GameRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    /// <summary>
    /// Base class for the New Game and The Record Controller
    /// </summary>
    public abstract class ControllerNewGameRecordBase
    {
        /// <summary>
        /// Provides for working with record's file
        /// </summary>
        public RecordUtils RecordUtils { get; private set; }
        /// <summary>
        /// Default constructor
        /// </summary>
        public ControllerNewGameRecordBase()
        {
            RecordUtils = new RecordUtils(true);
        }
        
    }
}
