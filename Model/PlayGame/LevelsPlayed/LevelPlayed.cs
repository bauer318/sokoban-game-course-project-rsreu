using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.LevelsPlayed
{
    /// <summary>
    /// Provides the level's played
    /// </summary>
    [Serializable]
    public class LevelPlayed
    {
        /// <summary>
        /// All levels's played
        /// </summary>
        public List<int> LevelsPlayed { get; set; }
        /// <summary>
        /// Initializes instance of LevelPlayed
        /// </summary>
        /// <param name="parLevelsPlayed">List of all played levels</param>
        public LevelPlayed(List<int> parLevelsPlayed)
        {
            LevelsPlayed = parLevelsPlayed;
        }

        /// <summary>
        /// Add an new played level
        /// </summary>
        /// <param name="parLevelNumber">new played level's number</param>
        public void AddLevelPlayed(int parLevelNumber)
        {
            if (!LevelsPlayed.Contains(parLevelNumber))
            {
                LevelsPlayed.Add(parLevelNumber);
            }
        }
        /// <summary>
        /// Check whether the level's number is already played
        /// </summary>
        /// <param name="parLevelNumber">The level's number</param>
        /// <returns></returns>
        public bool IsLevelPlayed(int parLevelNumber)
        {
            if (LevelsPlayed.Count == 0)
            {
                return false;
            }
            return LevelsPlayed.Last() >= parLevelNumber && parLevelNumber >= 0;
        }
        /// <summary>
        /// Get the last played level
        /// </summary>
        /// <returns>The last played level in the list of all played levels or zero if the list was empty</returns>
        public int GetLastLevelPlayed()
        {
            if (LevelsPlayed.Count > 0)
            {
                return LevelsPlayed.Last();
            }
            else
            {
                return 0;
            }

        }
    }
}
