using Model.CommonWork;
using Model.GameRecord;
using System;
using System.Collections.Generic;

namespace TestRecordFile
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputInputFileWriterReader c = new OutputInputFileWriterReader();
            //c.WriteRecordBinaryFile(new RecordManager(new Dictionary<int, Record>()));*/
            /*RecordUtils rec = new RecordUtils();
            rec.UpdateRecord(0, 14);
            rec.UpdateRecord(1, 15);
            Console.WriteLine("0 " + rec.RecordManager.RecordsDictionary[0].MoveCount + " at " + rec.RecordManager.RecordsDictionary[0].LastDateTime);
            Console.WriteLine("1 " + rec.RecordManager.RecordsDictionary[1].MoveCount + " at " + rec.RecordManager.RecordsDictionary[1].LastDateTime);
            Console.ReadLine();*/
             string[] f = c.ReadHelpFile(true);
            foreach(string s in f)
            {
                foreach(char c2 in s)
                {
                    if (c2.Equals('.'))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    if (c2.Equals('@'))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.Write(c2);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
