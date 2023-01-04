using Model.PlayGame.Locations;
using Model.SokobanSolvers;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string level = "#######," +
                            "#     #," +
                            "# @$  #," +
                            "#  # .#," +
                            "# $# .#," +
                            "#     #," +
                            "#######";
            System.Console.WriteLine("Level:\n");
            foreach (string line in level.Split(','))
            {
                System.Console.WriteLine(line);
            }
            System.Console.WriteLine("\nSolution:\n");
            new SokobanSolver(level.Split(',')).Solve();
            //System.Console.WriteLine(new SokobanSolver(level.Split(',')));//.Solve()) ;
            /*SokobanSolver s = new SokobanSolver();
            s.InitBoxDictionaries(level.Split(','));
            foreach(Location l in s.goalDictionaries.Values)
            {
                Console.WriteLine("row " + l.RowNumber + " col " + l.ColumnNumber);
            }*/
            Console.ReadLine();
        }
    }
}
