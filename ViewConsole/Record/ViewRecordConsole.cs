using Model.GameRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Record;
using ViewConsole.Menu;

namespace ViewConsole.Records
{
    /// <summary>
    /// Representes the record's view
    /// </summary>
    public class ViewRecordConsole : ViewRecordBase
    {
        /// <summary>
        /// The menu's view
        /// </summary>
        private ViewMenuConsole _viewMenuConsole;
        /// <summary>
        /// Get or Set the menu's view
        /// </summary>
        public ViewMenuConsole ViewMenuConsole
        {
            get
            {
                return _viewMenuConsole;
            }
            set
            {
                _viewMenuConsole = value;
            }
        }
        /// <summary>
        /// Print a message
        /// </summary>
        /// <param name="parMessage">The message to print</param>
        public override void PrintMessage(string parMessage)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(parMessage);
        }
        /// <summary>
        /// Print the record columns's name
        /// </summary>
        public void PrintColumnsName()
        {
            Console.Clear();
            Console.CursorLeft = 2;
            Console.Write("Уровень");
            Console.CursorLeft = 15;
            Console.Write("Количество шагов");
            Console.CursorLeft = 35;
            Console.Write("Дата и время");
            Console.WriteLine();
        }
        /// <summary>
        /// Back to main menu
        /// </summary>
        public void BackToMainMenu()
        {
            _viewMenuConsole.Draw();
        }
        /// <summary>
        /// Processes to print game's record
        /// </summary>
        /// <param name="parRecordDictionary">The record's dictionary as a pair of level's number and record</param>
        public void ProcessPrintRecord(Dictionary<int, Record> parRecordDictionary)
        {
            DrawUtils.SaveColors();
            Console.ForegroundColor = ConsoleColor.Black;
            int[] keyValues = new int[parRecordDictionary.Count];
            var count = 0;
            foreach (KeyValuePair<int, Record> elRecord in parRecordDictionary)
            {
                keyValues[count] = elRecord.Key;
                count++;
            }

            for (var j = 0; j < parRecordDictionary.Count; j++)
            {
                Console.CursorLeft = 2;
                Console.Write((keyValues[j]+1).ToString());
                Console.CursorLeft = 15;
                Console.Write(parRecordDictionary[keyValues[j]].MoveCount.ToString());
                Console.CursorLeft = 35;
                Console.Write(parRecordDictionary[keyValues[j]].LastDateTime.ToString() + "\n");
            }
            DrawUtils.PutColorsBack();

        }
    }
}
