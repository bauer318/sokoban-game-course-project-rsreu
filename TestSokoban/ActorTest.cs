using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.PlayGame.Commands;
using Model.PlayGame.Levels;
using Model.PlayGame.Locations;
using Model.PlayGame.NewGame;
using System;
using System.IO;

namespace TestSokoban
{
    /// <summary>
    /// Preovides the tests for Actor
    /// </summary>
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
        /// #   .   # 5
        /// ######### 6
        /// # - Wall
        /// @ - Actor
        /// $ - Treasure
        /// . - Goal
        /// </summary>
        private Level _level;
        /// <summary>
        /// The base command
        /// </summary>
        private CommandBase _command;
        /// <summary>
        /// The command manager
        /// </summary>
        private CommandManager _commandManager;
        /// <summary>
        /// Right's Direction
        /// </summary>
        private const Direction RIGHT = Direction.Right;
        /// <summary>
        /// Left's Direction
        /// </summary>
        private const Direction LEFT = Direction.Left;
        /// <summary>
        /// Up's Direction
        /// </summary>
        private const Direction UP = Direction.Up;
        /// <summary>
        /// Down's Direction
        /// </summary>
        private const Direction DOWN = Direction.Down;
        /// <summary>
        /// The initial expected actor's location 1 1 cfr the level's map
        /// </summary>
        private Location _expectedInitialActorLocation;
        /// <summary>
        /// Indicates whether this Actor's level is completed
        /// </summary>
        private bool _isLevelCompleted = false;
        /// <summary>
        /// Move the actor to the direction
        /// </summary>
        /// <param name="parDirection">The direction to move the actor</param>
        private void MoveTo(Direction parDirection)
        {
            _command = new MoveCommand(_level, parDirection);
            _commandManager.Execute(_command);
        }
        /// <summary>
        /// Move the  actor to the direction n consecutive time
        /// </summary>
        /// <param name="parDirection">The direction to move the actor</param>
        /// <param name="parNTime">n consecutive times</param>
        private void MoveTo(Direction parDirection, int parNTime)
        {

            for (var i = 0; i < parNTime; i++)
            {
                MoveTo(parDirection);
            }
        }
        /// <summary>
        /// Initializes test's paraters before each test
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            _isLevelCompleted = false;
            _commandManager = new CommandManager();
            string LevelDirectory = @"..\..\..\..\TestLevel\";
            Game game = new Game();
            _level = new Level(game, 0);
            _level.LevelCompleted += Level_LevelCompleted;
            string fileName = string.Format(@"{0}LevelTest.skbn", LevelDirectory);
            using (StreamReader reader = File.OpenText(fileName))
            {
                _level.Load(reader);
            }
            game.StartLevel();
            _expectedInitialActorLocation = new Location(1, 1);
        }
        /// <summary>
        /// Test a possible's actor move to the right
        /// </summary>
        [TestMethod]
        public void TestPossibleMoveRight()
        {
            //Actor location before the move to the right direction
            Location actualActorLocation = _level.Actor.Location;

            //Actor location after the move to the right direction
            MoveTo(RIGHT);
            Location expectedActorLocationAfterRightMove = new(1, 2);
            Location actualActorLocationAfterRightMove = _level.Actor.Location;
            Assert.AreEqual(_expectedInitialActorLocation, actualActorLocation);
            Assert.AreEqual(expectedActorLocationAfterRightMove, actualActorLocationAfterRightMove);

        }
        /// <summary>
        /// Test a possible's actor move to the left
        /// </summary>
        [TestMethod]
        public void TestPossibleMoveToTheLeft()
        {
            //Actor location before the move to the left direction
            Location actualActorLocation = _level.Actor.Location;

            //Actor location after the move to the left direction
            MoveTo(RIGHT, 2); // Locations 1 2, 1 3 
            MoveTo(LEFT);
            Location expectedActorLocationAfterLeftMove = new(1, 2);
            Location actualActorLocationAfterLeftMove = _level.Actor.Location;
            Assert.AreEqual(_expectedInitialActorLocation, actualActorLocation);
            Assert.AreEqual(expectedActorLocationAfterLeftMove, actualActorLocationAfterLeftMove);
        }
        /// <summary>
        /// Test a possible's actor move to the down
        /// </summary>
        [TestMethod]
        public void TestPossibleMoveToTheDown()
        {
            //Actor location before the move to the down direction
            Location actualActorLocation = _level.Actor.Location;

            //Actor location after the move to the down direction
            MoveTo(DOWN);
            Location expectedActorLocationAfterDownMove = new(2, 1);
            Location actualActorLocationAfterDownMove = _level.Actor.Location;
            Assert.AreEqual(_expectedInitialActorLocation, actualActorLocation);
            Assert.AreEqual(expectedActorLocationAfterDownMove, actualActorLocationAfterDownMove);
        }
        /// <summary>
        /// Test a possible's actor move to the Up
        /// </summary>
        [TestMethod]
        public void TestPossibleMoveToTheUp()
        {
            //Actor location before the move to the up direction
            Location actualActorLocation = _level.Actor.Location;

            //Actor location after the move to the up direction
            MoveTo(DOWN); //Location 2,1
            MoveTo(UP);
            Location expectedActorLocationAfterUpMove = new(1, 1);
            Location actualActorLocationAfterUpMove = _level.Actor.Location;
            Assert.AreEqual(_expectedInitialActorLocation, actualActorLocation);
            Assert.AreEqual(expectedActorLocationAfterUpMove, actualActorLocationAfterUpMove);
        }
        /// <summary>
        /// Test an impossible's actor move to the right
        /// When there is wall
        /// </summary>
        [TestMethod]
        public void TestImpossibleMoveToTheRight()
        {
            //Actor location before the move to the right direction
            Location actualActorLocation = _level.Actor.Location;

            //Actor location after the move to the right direction
            MoveTo(RIGHT, 6); //Location 1 2, 1 , 1 4, 1 5, 1 6, 1 7
            MoveTo(RIGHT); //he can't move because there is a wall , so the Location does not change 
            Location expectedActorLocationAfterRightMove = new Location(1, 7);
            Location actualActorLocationAfterRightMove = _level.Actor.Location;

            Assert.AreEqual(_expectedInitialActorLocation, actualActorLocation);
            Assert.AreEqual(expectedActorLocationAfterRightMove, actualActorLocationAfterRightMove);
        }
        /// <summary>
        /// Test an impossible's actor move to the left
        /// When there is a wall
        /// </summary>
        [TestMethod]
        public void TestImpossibleMoveToTheLeft()
        {
            //Actor location before the move to the left direction
            Location actualActorLocation = _level.Actor.Location;

            //Actor location after the move to the left direction
            MoveTo(LEFT); // he can't move because there is a wall, so the location does not change
            Location expectedActorLocationAfterLeftMove = new Location(1, 1);
            Location actualActorLocationAfterLeftMove = _level.Actor.Location;

            Assert.AreEqual(_expectedInitialActorLocation, actualActorLocation);
            Assert.AreEqual(expectedActorLocationAfterLeftMove, actualActorLocationAfterLeftMove);
        }
        /// <summary>
        /// Test an impossible's actor move to the down
        /// When there is a wall
        /// </summary>

        [TestMethod]
        public void TestImpossibleMoveToTheDown()
        {
            //Actor location before the move to the down direction
            Location actualActorLocation = _level.Actor.Location;

            //Actor location after the move to the down direction
            MoveTo(DOWN); //Location 2 1
            MoveTo(DOWN); //he can't move because there is a wall, so the location does not change
            Location expectedActorLocationAfterDownMove = new Location(2, 1);
            Location actualActorLocationAfterDownMove = _level.Actor.Location;
            Assert.AreEqual(_expectedInitialActorLocation, actualActorLocation);
            Assert.AreEqual(expectedActorLocationAfterDownMove, actualActorLocationAfterDownMove);
        }
        /// <summary>
        /// Test an impossible's actor move to the Up
        /// When there is a wall
        /// </summary>
        [TestMethod]
        public void TestImpossibleMoveToTheUp()
        {
            //Actor location before the move to the up direction
            Location actualActorLocation = _level.Actor.Location;

            //Actor location after the move to the up direction
            MoveTo(UP); //Location 1 1 does not change because there is a wall 
            Location expectedActorLocationAfterUpMove = new Location(1, 1);
            Location actualActorLocationAfterUpMove = _level.Actor.Location;
            Assert.AreEqual(_expectedInitialActorLocation, actualActorLocation);
            Assert.AreEqual(expectedActorLocationAfterUpMove, actualActorLocationAfterUpMove);
        }
        /// <summary>
        /// Test a possible displacement of the treasure by the actor
        /// </summary>
        [TestMethod]
        public void TestPossibleMoveTreasure()
        {
            //Actor location before the move to the up direction
            Location actualActorLocation = _level.Actor.Location;

            //Actor moves the treasure
            MoveTo(DOWN); //Location 2 1
            MoveTo(RIGHT); //Actor's location 2 2 Treasure Location 2 3
            Location expectedActorLocationAfterMoveTreasure = new Location(2, 2);
            Location actualActorLocationAfterMoveTreasure = _level.Actor.Location;
            Assert.AreEqual(_expectedInitialActorLocation, actualActorLocation);
            Assert.AreEqual(expectedActorLocationAfterMoveTreasure, actualActorLocationAfterMoveTreasure);

        }
        /// <summary>
        /// Test an impossible displacement of the treasure by the actor
        /// When there is another treasure right in front of the one that the actor wants to move
        /// </summary>
        [TestMethod]
        public void TestImpossibleMoveTreasure()
        {
            //Actor location before the move to the up direction
            Location actualActorLocation = _level.Actor.Location;

            //Actor attemps to move the treasure
            MoveTo(RIGHT, 3); //Location 1 2, 1 3, 1 4
            MoveTo(DOWN);  //Location 2 4
            /*he can't move because there is a treasure right in front of the one that the actor wants to move.*/
            MoveTo(RIGHT);

            Location expectedActorLocationAfterMoveTreasure = new Location(2, 4);
            Location actualActorLocationAfterMoveTreasure = _level.Actor.Location;
            Assert.AreEqual(_expectedInitialActorLocation, actualActorLocation);
            Assert.AreEqual(expectedActorLocationAfterMoveTreasure, actualActorLocationAfterMoveTreasure);

        }
        /// <summary>
        /// Test the actor's location after undo the last move
        /// </summary>
        [TestMethod]
        public void TestActorLocationAfterUndoMove()
        {
            //Actor location before the move to the up direction
            Location actualActorLocation = _level.Actor.Location;

            MoveTo(RIGHT, 2); //Location 1 2, 1 3
            MoveTo(DOWN); //Location 2 3
            _commandManager.Undo(); //Location 1 3
            _commandManager.Undo(); //Location 1 3 because the actor can only undo his last move, and not all these previous moves
            Location expectedActorLocationAfterMoveTreasure = new Location(1, 3);
            Location actualActorLocationAfterMoveTreasure = _level.Actor.Location;
            Assert.AreEqual(_expectedInitialActorLocation, actualActorLocation);
            Assert.AreEqual(expectedActorLocationAfterMoveTreasure, actualActorLocationAfterMoveTreasure);
        }
        /// <summary>
        /// Test actor's move count after possibles moves
        /// </summary>
        [TestMethod]
        public void TestMoveCountAfterPossibleMove()
        {
            int expectedInitialMoveCount = 0;
            int actualMoveCount = _level.Actor.MoveCount;
            MoveTo(RIGHT, 3); //1 2 3
            MoveTo(DOWN, 4); //4 5 6 7
            int expectedMoveCountAfterAllMoves = 7;
            int actualMoveCountAfterAllMoves = _level.Actor.MoveCount;
            Assert.AreEqual(expectedInitialMoveCount, actualMoveCount);
            Assert.AreEqual(expectedMoveCountAfterAllMoves, actualMoveCountAfterAllMoves);
        }
        /// <summary>
        /// Test the actor's move count after possibles and impossibles moves
        /// </summary>
        [TestMethod]
        public void TestMoveCountAfterPossibleAndImpossibleMove()
        {
            int expectedInitialMoveCount = 0;
            int actualMoveCount = _level.Actor.MoveCount;
            MoveTo(RIGHT, 3); //1 2 3
            MoveTo(DOWN, 4); //4 5 6 7
            MoveTo(DOWN, 4); //7 can't move because there is wall
            MoveTo(LEFT, 2); //8 9
            MoveTo(UP); //9 can't move because there is treasure in front which there is a wall
            int expectedMoveCountAfterAllMoves = 9;
            int actualMoveCountAfterAllMoves = _level.Actor.MoveCount;
            Assert.AreEqual(expectedInitialMoveCount, actualMoveCount);
            Assert.AreEqual(expectedMoveCountAfterAllMoves, actualMoveCountAfterAllMoves);
        }
        /// <summary>
        /// Test the actor's move count after ONE undo move
        /// </summary>
        [TestMethod]
        public void TestMoveCountAfterTheUndoMove()
        {
            int expectedInitialMoveCount = 0;
            int actualMoveCount = _level.Actor.MoveCount;
            MoveTo(RIGHT, 3); //1 2 3
            MoveTo(DOWN, 4); //4 5 6 7
            _commandManager.Undo(); //6
            MoveTo(DOWN); //7
            int expectedMoveCountAfterAllMoves = 7;
            int actualMoveCountAfterAllMoves = _level.Actor.MoveCount;
            Assert.AreEqual(expectedInitialMoveCount, actualMoveCount);
            Assert.AreEqual(expectedMoveCountAfterAllMoves, actualMoveCountAfterAllMoves);
        }
        /// <summary>
        /// Test the actor's move count after MULTIPLE CONSECUTIVE undo move
        /// </summary>
        [TestMethod]
        public void TestMoveCountAfterMultipleUndoMove()
        {
            int expectedInitialMoveCount = 0;
            int actualMoveCount = _level.Actor.MoveCount;
            MoveTo(RIGHT, 3); //1 2 3
            MoveTo(DOWN, 4); //4 5 6 7
            _commandManager.Undo(); //6
            _commandManager.Undo(); //6 the actor can only undo his last move, and not all these previous moves
            _commandManager.Undo(); //6 the actor can only undo his last move, and not all these previous moves
            MoveTo(LEFT);//7
            _commandManager.Undo(); //6 the actor can only undo his last move, and not all these previous moves
            _commandManager.Undo(); //6 the actor can only undo his last move, and not all these previous moves
            MoveTo(DOWN); //7
            int expectedMoveCountAfterAllMoves = 7;
            int actualMoveCountAfterAllMoves = _level.Actor.MoveCount;
            Assert.AreEqual(expectedInitialMoveCount, actualMoveCount);
            Assert.AreEqual(expectedMoveCountAfterAllMoves, actualMoveCountAfterAllMoves);
        }
        /// <summary>
        /// Test the treasure's move to the first goal by the actor, but the level is not completed
        /// because there are still three goals left
        /// </summary>
        [TestMethod]
        public void TestMoveTheTreasureToFirstGoal()
        {
            MoveTo(RIGHT, 4);
            MoveTo(DOWN);
            Location actorLocationAfterPlacedTreasureOnGoal = new Location(2, 5);
            Assert.AreEqual(actorLocationAfterPlacedTreasureOnGoal, _level.Actor.Location);
            Assert.IsFalse(_isLevelCompleted);
        }
        /// <summary>
        /// Test the treasure's move to the second goal by the actor, but the level is not completed
        /// because there are still two goals left
        /// </summary>
        [TestMethod]
        public void TestMoveTheTreasureToSecondGoal()
        {
            MoveTo(RIGHT, 4);
            MoveTo(DOWN);

            MoveTo(RIGHT);

            Location actorLocationAfterPlacedTreasureOnGoal = new Location(2, 6);
            Assert.AreEqual(actorLocationAfterPlacedTreasureOnGoal, _level.Actor.Location);
            Assert.IsFalse(_isLevelCompleted);
        }
        /// <summary>
        /// Test the treasure's move to the third goal by the actor, but the level is not completed
        /// because there are still one goal left
        /// </summary>
        [TestMethod]
        public void TestMoveTheTreasureToThirdGoal()
        {
            MoveTo(RIGHT, 4);
            MoveTo(DOWN);

            MoveTo(RIGHT);

            MoveTo(DOWN, 2);
            MoveTo(LEFT, 4);
            Location actorLocationAfterPlacedTreasureOnGoal = new Location(4, 2);
            Assert.AreEqual(actorLocationAfterPlacedTreasureOnGoal, _level.Actor.Location);
            Assert.IsFalse(_isLevelCompleted);

        }
        /// <summary>
        /// Test the treasure's move to the last goal by the actor, the level is  completed but not tested
        /// </summary>
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
            Assert.AreEqual(actorLocationAfterPlacedTreasureOnGoal, _level.Actor.Location);
        }
        /// <summary>
        /// Test the treasure's move to the last goal by the actor, the level is completed and  tested
        /// </summary>
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
            Assert.AreEqual(actorLocationAfterPlacedTreasureOnGoal, _level.Actor.Location);
            Assert.IsTrue(_isLevelCompleted);
        }
        /// <summary>
        /// Occurs when this level is successfully completed
        /// </summary>
        /// <param name="sender">The object's sender</param>
        /// <param name="e">The event sended</param>
        private void Level_LevelCompleted(object sender, EventArgs e)
        {
            _isLevelCompleted = true;
        }
    }
}
