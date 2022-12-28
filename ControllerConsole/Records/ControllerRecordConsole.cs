using Controller.Records;
using Model.GameRecord;
using System;
using System.Collections.Generic;
using View.Record;
using ViewConsole.Record;

namespace ControllerConsole.Records
{
    public class ControllerRecordConsole : ControllerRecordBase
    {
        private ViewRecordConsole _viewRecordConsole;
        private bool _needPrint = true;
        public ControllerRecordConsole(ViewRecordBase parViewRecordBase) : base(parViewRecordBase)
        {
            _viewRecordConsole = parViewRecordBase as ViewRecordConsole;
            _viewRecordConsole.PrintTitle();
            while (true)
            {
                if (_needPrint)
                {
                    ProcessPrintRecord();
                }
                _needPrint = false;
                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                if (keyPressed.Key == ConsoleKey.Escape)
                {
                    _viewRecordConsole.BackToMainMenu();
                    break;

                }

            }

        }
        public void ProcessPrintRecord()
        {
            Dictionary<int, Record> dictionary = GetRecordDictionary();
            int[] keyValues = new int[dictionary.Count];
            var count = 0;
            foreach (KeyValuePair<int, Record> entry in dictionary)
            {
                keyValues[count] = entry.Key;
                count++;
            }

            for (var j = 0; j < dictionary.Count; j++)
            {
                Console.CursorLeft = 2;
                Console.Write(keyValues[j].ToString());
                Console.CursorLeft = 15;
                Console.Write(dictionary[keyValues[j]].MoveCount.ToString());
                Console.CursorLeft = 35;
                Console.Write(dictionary[keyValues[j]].LastDateTime.ToString() + "\n");
            }

        }
    }
}
