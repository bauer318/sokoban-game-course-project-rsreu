using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.NewGame
{
	/// <summary>
	/// All states that a game instance
	/// </summary>
	public enum GameState
	{
		/// <summary>
		/// Loading of a Level.
		/// </summary>
		Loading,
		/// <summary>
		/// Levels loaded and ready for input.
		/// </summary>
		Running,
		/// <summary>
		/// An Actor has successfully
		/// placed all Treasure
		/// on Goal's Cells.
		/// </summary>
		LevelCompleted,
		/// <summary>
		/// The game has ended, with the user
		/// being unsuccessful.
		/// </summary>
		GameOver
	}
}
