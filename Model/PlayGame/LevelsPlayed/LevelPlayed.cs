using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.LevelsPlayed
{
    [Serializable]
    public class LevelPlayed
    {
        public List<int> LevelsPlayed { get; set; }

        public LevelPlayed(List<int> parLevelsPlayed)
        {
            LevelsPlayed = parLevelsPlayed;
        }


        public void AddLevelPlayed(int parLevelNumber)
        {
            if (!IsLevelPlayed(parLevelNumber))
            {
                LevelsPlayed.Add(parLevelNumber);
            }
        }

        public bool IsLevelPlayed(int parLevelNumber)
        {
            return LevelsPlayed.Last() >= parLevelNumber && parLevelNumber >= 0;
        }

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

        public void ReInitializeLevelsPlayed()
        {
            LevelsPlayed = new List<int>();
        }


    }
}
