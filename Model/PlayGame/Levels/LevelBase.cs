using Model.PlayGame.Cell;
using Model.PlayGame.NewGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.Levels
{
    public class LevelBase
    {
		/// <summary>
		/// Gets the level number.
		/// </summary>
		/// <value>The level number.</value>
		public int LevelNumber
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the game that this level is located.
		/// </summary>
		/// <value>The game that this level is located.</value>
		public NewGameBase Game
		{
			get;
			set;
		}

		public LevelBase(NewGameBase newGameBase, int levelNumber)
        {
			Game = newGameBase;
			LevelNumber = levelNumber;
        }

	}
}
