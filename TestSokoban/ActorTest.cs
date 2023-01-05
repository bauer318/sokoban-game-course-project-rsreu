using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.PlayGame.Levels;
using Model.PlayGame.NewGame;
using System.IO;

namespace TestSokoban
{
    [TestClass]
    public class ActorTest
    {
        Level level;
        Game game;
        [TestInitialize]
        public void Init()
        {
            string LevelDirectory = @"..\..\..\..\Levels\";
            game = new Game();
            level = new Level(game, 0);
            string fileName = string.Format(@"{0}LevelTest.skbn", LevelDirectory);
            using (StreamReader reader = File.OpenText(fileName))
            {
                level.Load(reader);
            }
            game.StartLevel();
        }
        [TestMethod]
        public void TestLevelRowCount()
        {
            Assert.AreEqual(7, level.RowCount);
            Assert.AreEqual(5, level.ColumnCount);
        }
    }
}
