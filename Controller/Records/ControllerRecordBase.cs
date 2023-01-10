using Model.GameRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Record;

namespace Controller.Records
{
    /// <summary>
    /// Base class for the Record's controller
    /// </summary>
    public abstract class ControllerRecordBase:ControllerNewGameRecordBase
    {
        /// <summary>
        /// The base view for a record
        /// </summary>
        private ViewRecordBase _viewRecordBase;
        /// <summary>
        /// The base view for a record
        /// </summary>
        public ViewRecordBase ViewRecordBase
        {
            get
            {
                return _viewRecordBase;
            }
            set
            {
                _viewRecordBase = value;
            }
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        public ControllerRecordBase(ViewRecordBase parViewRecordBase) : base()
        {
            _viewRecordBase = parViewRecordBase;
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
