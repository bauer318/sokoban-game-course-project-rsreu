using Model.PlayGame.Commands;
using Model.PlayGame.Levels;
using Model.PlayGame.Locations;
using Model.PlayGame.NewGame;
using System;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ClassT c = new ClassT();
            c.TestLevelCompletedAfterAllActorMove();
            Console.ReadLine();
            
            
        }
       
    }
}
