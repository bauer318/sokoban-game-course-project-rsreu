using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.GameRecord
{
    /// <summary>
    /// Represent a Game's level record of the minimal move count made by the actor
    /// </summary>
    [System.Serializable]
    public class Record
    {
        /// <summary>
        /// Get or Set the move count made by the actor
        /// </summary>
        public int MoveCount { get; set; }
        /// <summary>
        /// The last date and time updated this record
        /// </summary>
        public DateTime LastDateTime { get; set; }
        /// <summary>
        /// Initializes a new record
        /// </summary>
        /// <param name="parMoveCount">the move count made by the actor</param>
        /// <param name="parDateTime">the last date and time updated this record</param>
        public Record(int parMoveCount, DateTime parDateTime)
        {
            MoveCount = parMoveCount;
            LastDateTime = parDateTime;
        }
    }
}
