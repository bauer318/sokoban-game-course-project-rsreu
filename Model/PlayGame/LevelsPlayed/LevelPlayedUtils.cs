﻿using Model.CommonWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.LevelsPlayed
{
    public class LevelPlayedUtils
    {
        /// <summary>
        /// Provides for write and read the files
        /// </summary>
        private OutputInputFileWriterReader _fileWriterReader = new();
        /// <summary>
        /// Level Played
        /// </summary>
        public LevelPlayed LevelPlayed { get; set; }
        /// <summary>
        /// Initializes the LevelPlayedUtils
        /// </summary>
        /// <param name="parExistLevelPlayedBinaryFile">Indicates whether already exist the binary's file</param>
        public LevelPlayedUtils(bool parExistLevelPlayedBinaryFile)
        {
            if (!parExistLevelPlayedBinaryFile)
            {
                _fileWriterReader.WriteLevelsPlayedBinaryFile(new LevelPlayed(new List<int>()));
            }
            LevelPlayed = _fileWriterReader.GetLevelPlayedBinaryFile();
        }

        public void UpdateLevelPlayed(int parLevelNumber)
        {
            LevelPlayed.AddLevelPlayed(parLevelNumber);
            _fileWriterReader.WriteLevelsPlayedBinaryFile(new LevelPlayed(LevelPlayed.LevelsPlayed));
        }


    }
}
