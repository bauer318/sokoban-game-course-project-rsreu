using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.PlayGame.Commands;
using Model.PlayGame.Levels;
using Model.PlayGame.Locations;
using Model.PlayGame.NewGame;
using System;
using System.ComponentModel;
using System.IO;

namespace TestSokoban
{
    [TestClass]
    public class ActorTest
    {
        /// <summary>
        /// Level's test
        /// 012345678 column
        /// ######### 0 row
        /// #@      # 1
        /// # $  $$.# 2
        /// ###  .  # 3
        /// #.$     # 4
        /// #  .    # 5
        /// ######### 6
        /// # - Wall
        /// @ - Actor
        /// $ - Treasure
        /// . - Goal
        /// </summary>
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
            
            for(var i = 0; i < parNTime; i++)
            {
                MoveTo(parDirection);
            }
        }
        [TestInitialize]
        public void Init()
        {
            isLevelCompleted = false;
            commandManager = new CommandManager();
            string LevelDirectory = @"..\..\..\..\Levels\";
            game = new Game();
            level = new Level(game, 0);
            level.LevelCompleted += Level_LevelCompleted;
            string fileName = string.Format(@"{0}LevelTest.skbn", LevelDirectory);
            using (StreamReader reader = File.OpenText(fileName))
            {
                level.Load(reader);
            }
            game.StartLevel();
            expectedInitialActorLocation = new Location(1, 1);
        }
        [TestMethod]
        public void TestPossibleMoveRight()
        {
            //Actor location before the move to the right direction
            Location actualActorLocation = level.Actor.Location;

            //Actor location after the move to the right direction
            MoveTo(RIGHT);
            Location expectedActorLocationAfterRightMove = new Location(1, 2);
            Location actualActorLocationAfterRightMove = level.Actor.Location;
            Assert.AreEqual(expectedInitialActorLocation, actualActorLocation);
            Assert.AreEqual(expectedActorLocationAfterRightMove, actualActorLocationAfterRightMove);

        }
        [TestMethod]
        public void TestPossibleMoveToTheLeft()
        {
            //Actor location before the move to the left direction
            Location actualActorLocation = level.Actor.Location;

            //Actor location after the move to the left direction
            MoveTo(RIGHT,2); // Locations 1 2, 1 3 
            //MoveTo(RIGHT); // Location 1,3
            MoveTo(LEFT);
            Location expectedActorLocationAfterLeftMove = new Location(1, 2);
            Location actualActorLocationAfterLeftMove = level.Actor.Location;
            Assert.AreEqual(expectedInitialActorLocation, actualActorLocation);
            Assert.AreEqual(expectedActorLocationAfterLeftMove, actualActorLocationAfterLeftMove);
        }
        [TestMethod]
        public void TestPossibleMoveToTheDown()
        {
            //Actor location before the move to the down direction
            Location actualActorLocation = level.Actor.Location;

            //Actor location after the move to the down direction
            MoveTo(DOWN);
            Location expectedActorLocationAfterDownMove = new Location(2, 1);
            Location actualActorLocationAfterDownMove = level.Actor.Location;
            Assert.AreEqual(expectedInitialActorLocation, actualActorLocation);
            Assert.AreEqual(expectedActorLocationAfterDownMove, actualActorLocationAfterDownMove);
        }
        [TestMethod]
        public void TestPossibleMoveToTheUp()
        {
            //Actor location before the move to the up direction
            Location actualActorLocation = level.Actor.Location;

            //Actor location after the move to the up direction
            MoveTo(DOWN); //Location 2,1
            MoveTo(UP);
            Location expectedActorLocationAfterUpMove = new Location(1, 1);
            Location actualActorLocationAfterUpMove = level.Actor.Location;
            Assert.AreEqual(expectedInitialActorLocation, actualActorLocation);
            Assert.AreEqual(expectedActorLocationAfterUpMove, actualActorLocationAfterUpMove);
        }
        [TestMethod]
        public void TestImpossibleMoveToTheRight()
        {
            //Actor location before the move to the right direction
            Location actualActorLocation = level.Actor.Location;

            //Actor location after the move to the right direction
            MoveTo(RIGHT,6); //Location 1 2, 1 , 1 4, 1 5, 1 6, 1 7
           /* MoveTo(RIGHT); //Location 1 3
            MoveTo(RIGHT); //Location 1 4
            MoveTo(RIGHT); //Location 1 5
            MoveTo(RIGHT); //Location 1 6
            MoveTo(RIGHT); //Location 1 7*/
            MoveTo(RIGHT); //he can't move because there is a wall , so the Location does not change 
            Location expectedActorLocationAfterRightMove = new Location(1, 7);
            Location actualActorLocationAfterRightMove = level.Actor.Location;

            Assert.AreEqual(expectedInitialActorLocation, actualActorLocation);
            Assert.AreEqual(expectedActorLocationAfterRightMove, actualActorLocationAfterRightMove);
        }
        [TestMethod]
        public void TestImpossibleMoveToTheLeft()
        {
            //Actor location before the move to the left direction
            Location actualActorLocation = level.Actor.Location;

            //Actor location after the move to the left direction
            MoveTo(LEFT); // he can't move because there is a wall, so the location does not change
            Location expectedActorLocationAfterLeftMove = new Location(1, 1);
            Location actualActorLocationAfterLeftMove = level.Actor.Location;

            Assert.AreEqual(expectedInitialActorLocation, actualActorLocation);
            Assert.AreEqual(expectedActorLocationAfterLeftMove, actualActorLocationAfterLeftMove);
        }

        [TestMethod]
        public void TestImpossibleMoveToTheDown()
        {
            //Actor location before the move to the down direction
            Location actualActorLocation = level.Actor.Location;

            //Actor location after the move to the down direction
            MoveTo(DOWN); //Location 2 1
            MoveTo(DOWN); //he can't move because there is a wall, so the location does not change
            Location expectedActorLocationAfterDownMove = new Location(2, 1);
            Location actualActorLocationAfterDownMove = level.Actor.Location;
            Assert.AreEqual(expectedInitialActorLocation, actualActorLocation);
            Assert.AreEqual(expectedActorLocationAfterDownMove, actualActorLocationAfterDownMove);
        }
        [TestMethod]
        public void TestImpossibleMoveToTheUp()
        {
            //Actor location before the move to the up direction
            Location actualActorLocation = level.Actor.Location;

            //Actor location after the move to the up direction
            MoveTo(UP); //Location 1 1 does not change because there is a wall 
            Location expectedActorLocationAfterUpMove = new Location(1, 1);
            Location actualActorLocationAfterUpMove = level.Actor.Location;
            Assert.AreEqual(expectedInitialActorLocation, actualActorLocation);
            Assert.AreEqual(expectedActorLocationAfterUpMove, actualActorLocationAfterUpMove);
        }
        [TestMethod]
        public void TestPossibleMoveTreasure()
        {
            //Actor location before the move to the up direction
            Location actualActorLocation = level.Actor.Location;

            //Actor moves the treasure
            MoveTo(DOWN); //Location 2 1
            MoveTo(RIGHT); //Actor's location 2 2 Treasure Location 2 3
            Location expectedActorLocationAfterMoveTreasure = new Location(2, 2);
            Location actualActorLocationAfterMoveTreasure = level.Actor.Location;
            Assert.AreEqual(expectedInitialActorLocation, actualActorLocation);
            Assert.AreEqual(expectedActorLocationAfterMoveTreasure, actualActorLocationAfterMoveTreasure);

        }
        [TestMethod]
        public void TestImpossibleMoveTreasure()
        {
            //Actor location before the move to the up direction
            Location actualActorLocation = level.Actor.Location;

            //Actor attemps to move the treasure
            MoveTo(RIGHT,3); //Location 1 2, 1 3, 1 4
           /* MoveTo(RIGHT); //Location 1 3
            MoveTo(RIGHT); //Location 1 4*/
            MoveTo(DOWN);  //Location 2 4
            /*he can't move because there is a treasure right in front of the one that the actor wants to push.*/
            MoveTo(RIGHT);

            Location expectedActorLocationAfterMoveTreasure = new Location(2, 4);
            Location actualActorLocationAfterMoveTreasure = level.Actor.Location;
            Assert.AreEqual(expectedInitialActorLocation, actualActorLocation);
            Assert.AreEqual(expectedActorLocationAfterMoveTreasure, actualActorLocationAfterMoveTreasure);

        }
        [TestMethod]
        public void TestActorLocationAfterUndoMove()
        {
            //Actor location before the move to the up direction
            Location actualActorLocation = level.Actor.Location;

            MoveTo(RIGHT,2); //Location 1 2, 1 3
           // MoveTo(RIGHT); //Location 1 3
            MoveTo(DOWN); //Location 2 3
            commandManager.Undo(); //Location 1 3
            commandManager.Undo(); //Location 1 3 because the actor can only undo his last move, and not all these previous moves
            Location expectedActorLocationAfterMoveTreasure = new Location(1, 3);
            Location actualActorLocationAfterMoveTreasure = level.Actor.Location;
            Assert.AreEqual(expectedInitialActorLocation, actualActorLocation);
            Assert.AreEqual(expectedActorLocationAfterMoveTreasure, actualActorLocationAfterMoveTreasure);
        }
        [TestMethod]
        public void TestMoveCountAfterPossibleMove()
        {
            int expectedInitialMoveCount = 0;
            int actualMoveCount = level.Actor.MoveCount;
            MoveTo(RIGHT,3); //1 2 3
           // MoveTo(RIGHT); //2
            //MoveTo(RIGHT); //3
            MoveTo(DOWN,4); //4 5 6 7
           // MoveTo(DOWN); //5
            //MoveTo(DOWN); //6
            //MoveTo(DOWN); //7
            int expectedMoveCountAfterAllMoves = 7;
            int actualMoveCountAfterAllMoves = level.Actor.MoveCount;
            Assert.AreEqual(expectedInitialMoveCount, actualMoveCount);
            Assert.AreEqual(expectedMoveCountAfterAllMoves, actualMoveCountAfterAllMoves);
        }
        
        [TestMethod]
        public void TestMoveCountAfterPossibleAndImpossibleMove()
        {
            int expectedInitialMoveCount = 0;
            int actualMoveCount = level.Actor.MoveCount;
            MoveTo(RIGHT,3); //1 2 3
           // MoveTo(RIGHT); //2
            //MoveTo(RIGHT); //3
            MoveTo(DOWN,4); //4 5 6 7
            //MoveTo(DOWN); //5
            //MoveTo(DOWN); //6
            //MoveTo(DOWN); //7
            MoveTo(DOWN,4); //7 can't move because there is wall
            //MoveTo(DOWN); //7 can't move because there is wall
            //MoveTo(DOWN); //7 can't move because there is wall
            //MoveTo(DOWN); //7 can't move because there is wall
            MoveTo(LEFT,2); //8 9
            //MoveTo(LEFT); //9
            MoveTo(UP); //9 can't move because there is treasure in front which there is a wall
            int expectedMoveCountAfterAllMoves = 9;
            int actualMoveCountAfterAllMoves = level.Actor.MoveCount;
            Assert.AreEqual(expectedInitialMoveCount, actualMoveCount);
            Assert.AreEqual(expectedMoveCountAfterAllMoves, actualMoveCountAfterAllMoves);
        }
        [TestMethod]
        public void TestMoveCountAfterTheUndoMove()
        {
            int expectedInitialMoveCount = 0;
            int actualMoveCount = level.Actor.MoveCount;
            MoveTo(RIGHT,3); //1 2 3
            //MoveTo(RIGHT); //2
            //MoveTo(RIGHT); //3
            MoveTo(DOWN,4); //4 5 6 7
            /*MoveTo(DOWN); //5
            MoveTo(DOWN); //6
            MoveTo(DOWN); //7*/
            commandManager.Undo(); //6
            MoveTo(DOWN); //7
            int expectedMoveCountAfterAllMoves = 7;
            int actualMoveCountAfterAllMoves = level.Actor.MoveCount;
            Assert.AreEqual(expectedInitialMoveCount, actualMoveCount);
            Assert.AreEqual(expectedMoveCountAfterAllMoves, actualMoveCountAfterAllMoves);
        }

        [TestMethod]
        public void TestMoveCountAfterMultipleUndoMove()
        {
            int expectedInitialMoveCount = 0;
            int actualMoveCount = level.Actor.MoveCount;
            MoveTo(RIGHT,3); //1 2 3
           /* MoveTo(RIGHT); //2
            MoveTo(RIGHT); //3*/
            MoveTo(DOWN,4); //4 5 6 7
            /*MoveTo(DOWN); //5
            MoveTo(DOWN); //6
            MoveTo(DOWN); //7*/
            commandManager.Undo(); //6
            commandManager.Undo(); //6 the actor can only undo his last move, and not all these previous moves
            commandManager.Undo(); //6 the actor can only undo his last move, and not all these previous moves
            MoveTo(LEFT);//7
            commandManager.Undo(); //6 the actor can only undo his last move, and not all these previous moves
            commandManager.Undo(); //6 the actor can only undo his last move, and not all these previous moves
            MoveTo(DOWN); //7
            int expectedMoveCountAfterAllMoves = 7;
            int actualMoveCountAfterAllMoves = level.Actor.MoveCount;
            Assert.AreEqual(expectedInitialMoveCount, actualMoveCount);
            Assert.AreEqual(expectedMoveCountAfterAllMoves, actualMoveCountAfterAllMoves);
        }
        [TestMethod]
        public void TestMoveTheTreasureToFirstGoal()
        {
            MoveTo(RIGHT,4);
            MoveTo(DOWN);
            Location actorLocationAfterPlacedTreasureOnGoal = new Location(2, 5);
            Assert.AreEqual(actorLocationAfterPlacedTreasureOnGoal, level.Actor.Location);
            Assert.IsFalse(isLevelCompleted);
        }

        [TestMethod]
        public void TestMoveTheTreasureToSecondGoal()
        {
            MoveTo(RIGHT,4);
            MoveTo(DOWN);

            MoveTo(RIGHT);
           
            Location actorLocationAfterPlacedTreasureOnGoal = new Location(2, 6);
            Assert.AreEqual(actorLocationAfterPlacedTreasureOnGoal, level.Actor.Location);
            Assert.IsFalse(isLevelCompleted);
        }

        [TestMethod]
        public void TestMoveTheTreasureToThirdGoal()
        {
            MoveTo(RIGHT, 4);
            MoveTo(DOWN);

            MoveTo(RIGHT);

            MoveTo(DOWN, 2);
            MoveTo(LEFT, 4);
            Location actorLocationAfterPlacedTreasureOnGoal = new Location(4, 2);
            Assert.AreEqual(actorLocationAfterPlacedTreasureOnGoal, level.Actor.Location);
            Assert.IsFalse(isLevelCompleted);

        }

        [TestMethod]
        public void TestMoveTheTreasureToLastGoal()
        {
            MoveTo(RIGHT, 4);
            MoveTo(DOWN);

            MoveTo(RIGHT);

            MoveTo(DOWN, 2);
            MoveTo(LEFT, 4);

            MoveTo(RIGHT);
            MoveTo(UP, 3);
            MoveTo(LEFT, 2);
            MoveTo(DOWN);
            MoveTo(RIGHT, 2);
            MoveTo(UP);
            MoveTo(RIGHT);
            MoveTo(DOWN, 3);

            Location actorLocationAfterPlacedTreasureOnGoal = new Location(4, 4);
            Assert.AreEqual(actorLocationAfterPlacedTreasureOnGoal, level.Actor.Location);
        }
        [TestMethod]
        public void TestLevelCompletedAfterAllActorMove()
        {
            MoveTo(RIGHT, 4);
            MoveTo(DOWN);

            MoveTo(RIGHT);

            MoveTo(DOWN, 2);
            MoveTo(LEFT, 4);

            MoveTo(RIGHT);
            MoveTo(UP, 3);
            MoveTo(LEFT, 2);
            MoveTo(DOWN);
            MoveTo(RIGHT, 2);
            MoveTo(UP);
            MoveTo(RIGHT);
            MoveTo(DOWN, 3);

            
            Location actorLocationAfterPlacedTreasureOnGoal = new Location(4, 4);
            Assert.AreEqual(actorLocationAfterPlacedTreasureOnGoal, level.Actor.Location);
            Assert.IsTrue(isLevelCompleted);
        }

        private void Level_LevelCompleted(object sender, EventArgs e)
        {
            isLevelCompleted = true;
        }
    }
}
