using Model.GameRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Records
{
    /// <summary>
    /// Base class for the Record's controller
    /// </summary>
    public abstract class ControllerRecordBase:ControllerNewGameRecordBase
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ControllerRecordBase() : base()
        {

        }
        /// <summary>
        /// Get the Game's record dictionary
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, Record> GetRecordDictionary()
        {
            return RecordUtils.RecordManager.RecordsDictionary;
        }
    }
}
