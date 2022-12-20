using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWPF.Game.NewGame
{
	/// <summary>
	/// All states that a game instance
	/// may be in.
	/// </summary>
	public enum GameState
    {
		/// <summary>
		/// Loading of a level.
		/// </summary>
		Loading,
		/// <summary>
		/// Levels loaded and ready for input.
		/// </summary>
		Running,
		/// <summary>
		/// An <see cref="Actor"/> has successfully
		/// placed all <see cref="Treasure"/>s
		/// on <see cref="GoalCell"/>s.
		/// </summary>
		LevelCompleted,
		/// <summary>
		/// The game is not active.
		/// </summary>
		Paused,
		/// <summary>
		/// The game has ended, with the user
		/// being unsuccessful.
		/// </summary>
		GameOver,
		/// <summary>
		/// The game has ended, with the user
		/// being successfully. All levels
		/// have been completed.
		/// </summary>
		GameCompleted
	}
}
