using Model.PlayGame.Commands;
using Model.PlayGame.Levels;
using Model.PlayGame.Locations;
using Model.PlayGame.NewGame;
using System;
using System.IO;
namespace ConsoleApp2
{
    public class ClassT
    {
         Level level;
         Game game;
         CommandManager commandManager;
        CommandBase command;
        const Direction RIGHT = Direction.Right;
        const Direction LEFT = Direction.Left;
        const Direction UP = Direction.Up;
        const Direction DOWN = Direction.Down;
        Location expectedInitialActorLocation;
         bool isLevelCompleted = false;
         int a = 0;
        private void MoveTo(Direction parDirection)
        {
            command = new MoveCommand(level, parDirection);
            commandManager.Execute(command);
        }
        private void MoveTo(Direction parDirection, int parNTime)
        {

            for (var i = 0; i < parNTime; i++)
            {
                MoveTo(parDirection);
            }
        }

        public  void Init()
        {
            commandManager = new CommandManager();
            string LevelDirectory = @"..\..\..\..\Levels\";
            game = new Game();
            level = new Level(game, 0);
            string fileName = string.Format(@"{0}LevelTest.skbn", LevelDirectory);
            using (StreamReader reader = File.OpenText(fileName))
            {
                level.Load(reader);
            }
            game.StartLevel();
            expectedInitialActorLocation = new Location(1, 1);
        }
        public ClassT()
        {
            Init();
        }
        public void TestLevelCompletedAfterAllActorMove()
        {
            level.LevelCompleted += Level_LevelCompleted;
            MoveTo(RIGHT, 4);
            MoveTo(DOWN);

            MoveTo(RIGHT);

            MoveTo(DOWN, 2);
            if (a == 2)
            {
                Console.WriteLine("Ok one");
            }
            else
            {
                Console.WriteLine("No one");
            }
            MoveTo(LEFT, 4);
            if (a == 2)
            {
                Console.WriteLine("Ok two");
            }
            else
            {
                Console.WriteLine("No two");
            }
            /*MoveTo(RIGHT);
            MoveTo(UP, 3);
            MoveTo(LEFT, 2);
            MoveTo(DOWN);
            MoveTo(RIGHT, 2);
            MoveTo(UP);
            MoveTo(RIGHT);
            MoveTo(DOWN, 4);*/




            Location actorLocationAfterPlacedTreasureOnGoal = new Location(4, 4);

        }
        private void Level_LevelCompleted(object sender, EventArgs e)
        {
            a = 2;
            isLevelCompleted = true;
        }
    }
}
