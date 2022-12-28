using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.GameRecord
{
    /// <summary>
    /// A record mamager
    /// </summary>
    public class RecordManager
    {
        /// <summary>
        /// Get or Set the record's dictionary by level number
        /// </summary>
        public  Dictionary<int,Record> RecordsDictionary { get; set; }
        /// <summary>
        /// Initialize the record manager
        /// </summary>
        /// <param name="parRecordsDictionary">the record's dictionary</param>
        public RecordManager(Dictionary<int, Record> parRecordsDictionary)
        {
            RecordsDictionary = parRecordsDictionary;
        }
    }
}
