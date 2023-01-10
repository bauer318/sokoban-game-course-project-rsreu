using Model.GameRecord;

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
        private RecordUtils _recordUtils;
        /// <summary>
        /// Get or Set the record's utils
        /// </summary>
        public RecordUtils RecordUtils
        {
            get 
            { 
                return _recordUtils;
            }
            private set 
            { 
                _recordUtils = value;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public ControllerNewGameRecordBase()
        {
            _recordUtils = new RecordUtils(true);
        }
        
    }
}
