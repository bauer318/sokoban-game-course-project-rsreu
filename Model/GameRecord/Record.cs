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
    [Serializable]
    public class Record
    {
        /// <summary>
        /// The move count made by the actor
        /// </summary>
        private int _moveCount;
        /// <summary>
        /// The last date annd time updated this record
        /// </summary>
        private DateTime _lasteDateTime;
        /// <summary>
        /// Get or Set the move count made by the actor
        /// </summary>
        public int MoveCount 
        { 
            get 
            {
                return _moveCount;
            } 
            set 
            {
                _moveCount = value;
            } 
        }
        /// <summary>
        /// Get or Set the last date and time updated this record
        /// </summary>
        public DateTime LastDateTime 
        {
            get
            {
                return _lasteDateTime;
            }
            set
            {
                _lasteDateTime = value;
            }
        }
        /// <summary>
        /// Initializes a new record
        /// </summary>
        /// <param name="parMoveCount">the move count made by the actor</param>
        /// <param name="parDateTime">the last date and time updated this record</param>
        public Record(int parMoveCount, DateTime parDateTime)
        {
            _moveCount = parMoveCount;
            _lasteDateTime = parDateTime;
        }
    }
}
