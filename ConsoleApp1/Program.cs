using Model.GameRecord;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            RecordUtils u = new RecordUtils();
            u.RecordManager = new RecordManager(new System.Collections.Generic.Dictionary<int, Record>());
            u.UpdateRecord(0, 10000);
        }
    }
}
