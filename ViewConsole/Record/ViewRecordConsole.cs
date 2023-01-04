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
    public class ViewRecordConsole : ViewRecordBase
    {
        private ViewMenuConsole _viewMenuConsole;
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
        public override void PrintMessage(string parMessage)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(parMessage);
        }
        public void PrintTitle()
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
        public void BackToMainMenu()
        {
            _viewMenuConsole.Draw();
        }
        public void ProcessPrintRecord(Dictionary<int, Record> parRecordDictionary)
        {

            int[] keyValues = new int[parRecordDictionary.Count];
            var count = 0;
            foreach (KeyValuePair<int, Record> entry in parRecordDictionary)
            {
                keyValues[count] = entry.Key;
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

        }
    }
}
