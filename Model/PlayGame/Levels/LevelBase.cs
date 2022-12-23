using Model.PlayGame.Cell;
using Model.PlayGame.NewGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.Levels
{
	/// <summary>
	/// Represents a single stage within a game.
	/// A level instance is able to load itself
	/// from a map resource.
	/// </summary>
	public class LevelBase
    {
		/// <summary>
		/// The level number
		/// </summary>
		private int _levelNumber;
		/// <summary>
		/// The game that this level is located
		/// </summary>
		private NewGameBase _newGameBase;
		/// <summary>
		/// Gets the level number.
		/// </summary>
		/// <value>The level number.</value>
		public int LevelNumber
		{
            get
            {
				return _levelNumber;
            }
            set
            {
				_levelNumber = value;
            }
		}

		/// <summary>
		/// Gets or sets the game that this level is located.
		/// </summary>
		/// <value>The game that this level is located.</value>
		public NewGameBase Game
		{
            get
            {
				return _newGameBase;
            }
            set
            {
				_newGameBase = value;
            }
		}
		/// <summary>
		/// LevelBase's contructor
		/// </summary>
		/// <param name="newGameBase">The game that this level is located</param>
		/// <param name="levelNumber">The level number</param>
		public LevelBase(NewGameBase parNewGameBase, int parLevelNumber)
        {
			Game = parNewGameBase;
			LevelNumber = parLevelNumber;
        }

	}
}
