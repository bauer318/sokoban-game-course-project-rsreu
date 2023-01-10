using Model.GameRecord;
using Model.PlayGame.Exceptions;
using Model.PlayGame.LevelsPlayed;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Model.CommonWork
{
    /// <summary>
    /// Provides for write and read the files
    /// </summary>
    public class OutputInputFileWriterReader
    {
        /// <summary>
        /// Directory path for the Record's file folder
        /// </summary>
        private const string DIRECTORY_RECORD_FILE = @"..\..\..\..\Record\";
        /// <summary>
        /// Directory path for the Help's file folder
        /// </summary>
        private const string DIRECTORY_HELP_FILE = @"..\..\..\..\Help\";
        /// <summary>
        /// Directory path for the levels's played file folder
        /// </summary>
        private const string DIRECTORY_LEVEL_PLAYED_FILE = @"..\..\..\..\LevelsPlayed\";
        /// <summary>
        /// Reads the help file
        /// </summary>
        /// <param name="parIsConsoleApp">Indicates if it is the console version</param>
        /// <returns>Text array of the Help's file</returns>
        public string[] ReadHelpFile(bool parIsConsoleApp)
        {
            var filename = parIsConsoleApp == true ? "console_help" : "wpf_help";
            var file = string.Format(@"{0}{1}.skbn", DIRECTORY_HELP_FILE, filename);
            if (File.Exists(file))
            {
                return File.ReadAllLines(file);
            }
            else
            {
                throw new SokobanException("Help file doesn't exist");
            }

        }
        /// <summary>
        /// Write the Record's binary file
        /// </summary>
        /// <param name="parRecordManager">Record manager</param>
        public void WriteRecordBinaryFile(RecordManager parRecordManager)
        {
            if (Directory.Exists(DIRECTORY_RECORD_FILE))
            {
                var fileName = string.Format(@"{0}Record.bin", DIRECTORY_RECORD_FILE);
                BinaryFormatter formatter = new();
                FileStream fileStream = new(fileName, FileMode.OpenOrCreate);
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                formatter.Serialize(fileStream, parRecordManager.RecordsDictionary);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
                fileStream.Close();
            }
            else
            {
                Directory.CreateDirectory(DIRECTORY_RECORD_FILE);
                WriteRecordBinaryFile(parRecordManager);
            }

        }
        /// <summary>
        /// Write the Level played's  binary file
        /// </summary>
        /// <param name="parRecordManager">Level payed</param>
        public void WriteLevelsPlayedBinaryFile(LevelPlayed parLevelPlayed)
        {
            if (Directory.Exists(DIRECTORY_LEVEL_PLAYED_FILE))
            {
                var fileName = string.Format(@"{0}LevelsPlayed.bin", DIRECTORY_LEVEL_PLAYED_FILE);
                BinaryFormatter formatter = new();
                FileStream fileStream = new(fileName, FileMode.OpenOrCreate);
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                formatter.Serialize(fileStream, parLevelPlayed);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
                fileStream.Close();
            }
            else
            {
                Directory.CreateDirectory(DIRECTORY_LEVEL_PLAYED_FILE);
                WriteLevelsPlayedBinaryFile(parLevelPlayed);
            }

        }
        /// <summary>
        /// Get the Record Manager from the saved Binary file
        /// </summary>
        /// <returns>Record Manager</returns>
        public RecordManager GetRecordManagerByRecordBinaryFile()
        {
            var fileName = string.Format(@"{0}Record.bin", DIRECTORY_RECORD_FILE);
            if (File.Exists(fileName))
            {
                var file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                try
                {
                    BinaryFormatter binaryFormatter = new();
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                    var dictionaryRecord = (Dictionary<int, Record>)binaryFormatter.Deserialize(file);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
                    return new RecordManager(dictionaryRecord);
                }
                catch (SerializationException e)
                {
                    throw new SokobanException(e.Message);
                }
                finally
                {
                    file.Close();
                }
            }
            else
            {
                throw new SokobanException("record's file doesn't existe");
            }

        }
        /// <summary>
        /// Get the Level Played from the saved Binary file
        /// </summary>
        /// <returns>Level Played</returns>
        public LevelPlayed GetLevelPlayedBinaryFile()
        {
            var fileName = string.Format(@"{0}LevelsPlayed.bin", DIRECTORY_LEVEL_PLAYED_FILE);
            if (File.Exists(fileName))
            {
                var file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                try
                {
                    BinaryFormatter binaryFormatter = new();
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                    var levelPlayed = (LevelPlayed)binaryFormatter.Deserialize(file);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
                    return levelPlayed;
                }
                catch (SerializationException e)
                {
                    throw new SokobanException(e.Message);
                }
                finally
                {
                    file.Close();
                }
            }
            else
            {
                throw new SokobanException("record's file doesn't existe");
            }
        }

    }
}
