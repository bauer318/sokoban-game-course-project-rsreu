using Model.CommonWork;
using System;
using System.Collections.Generic;

namespace Model.GameRecord
{
    /// <summary>
    /// Provides for working with the Game's Record
    /// </summary>
    public class RecordUtils
    {
        /// <summary>
        /// Indicates whether a new record has been set
        /// </summary>
        private bool _newRecordHasBeenSet = false;
        /// <summary>
        /// The Record manager
        /// </summary>
        private RecordManager _recordManager;

        /// <summary>
        /// Provides for write and read the files
        /// </summary>
        private OutputInputFileWriterReader _fileWriterReader = new();
        /// <summary>
        /// Get or Set the <seealso cref="_newRecordHasBeenSet"/>
        /// </summary>
        public bool NewRecordHasBeenSet 
        {
            get
            {
                return _newRecordHasBeenSet;
            }
            private set
            {
                _newRecordHasBeenSet = value;
            }
        }
        
        /// <summary>
        /// Get or Set the Record manager
        /// </summary>
        public RecordManager RecordManager
        {
            get
            {
                return _recordManager;
            }
            private set
            {
                _recordManager = value;
            }
        }
        /// <summary>
        /// Initialize the RecordUtils
        /// </summary>
        /// <param name="parExistRecordManagerBinaryFile">Indicates whether already exist the binary's file</param>
        public RecordUtils(bool parExistRecordManagerBinaryFile)
        {
            if (!parExistRecordManagerBinaryFile)
            {
                _fileWriterReader.WriteRecordBinaryFile(new RecordManager(new Dictionary<int, Record>()));
            }
            _recordManager = _fileWriterReader.GetRecordManagerByRecordBinaryFile();
        }
        /// <summary>
        /// Update a record after that a level has been completed succefuly
        /// </summary>
        /// <param name="parLevelNumber">The current level's number</param>
        /// <param name="parMoveCount">The Actor move count</param>
        public void UpdateRecord(int parLevelNumber, int parMoveCount)
        {
            _newRecordHasBeenSet = false;
            Dictionary<int, Record> dictionary = _recordManager.RecordsDictionary;
            if (dictionary.ContainsKey(parLevelNumber))
            {
                var oldMoveCount = dictionary[parLevelNumber].MoveCount;
                if (parMoveCount <= oldMoveCount)
                {
                    dictionary[parLevelNumber].MoveCount = parMoveCount;
                    dictionary[parLevelNumber].LastDateTime = DateTime.Now;
                    _fileWriterReader.WriteRecordBinaryFile(new RecordManager(dictionary));
                    _newRecordHasBeenSet = true;
                }
            }
            else
            {
                dictionary.Add(parLevelNumber, new Record(parMoveCount, DateTime.Now));
                _fileWriterReader.WriteRecordBinaryFile(new RecordManager(dictionary));
                _newRecordHasBeenSet = true;
            }

        }


    }
}
