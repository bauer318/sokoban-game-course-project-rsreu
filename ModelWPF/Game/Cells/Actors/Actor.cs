using Model.PlayGame.Locations;
using Model.PlayGame.Moves;
using ModelWPF.Game.Levels;
using ModelWPF.Game.Moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWPF.Game.Cells.Actors
{
	/// <summary>
	/// Represents the token manipulated by the user.
	/// </summary>
	public partial class Actor : CellContentsWPF
	{
		/// <summary>
		/// Stack of all move for this Actor in the current level
		/// </summary>
		private readonly Stack<MoveBase> _movesStack = new Stack<MoveBase>();
		/// <summary>
		/// Move count
		/// </summary>
		private int _moveCount;
		/* lock object for the DoMove methods. */
		private readonly object moveLock = new object();

		/// <summary>
		/// Gets the move count.
		/// </summary>
		/// <value>The number of moves (or steps)
		/// that the actor has completed.</value>
		public int MoveCount
		{
			get
			{
				return _moveCount;
			}
			private set
			{
				_moveCount = value;
				if (_moveCount < 0)
				{   /* Just in case. */
					_moveCount = 0;
				}
				OnPropertyChanged("MoveCount");
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Actor"/> class.
		/// </summary>
		/// <param name="parLocation">The location.</param>
		/// <param name="parLevel">The level.</param>
		public Actor(Location parLocation, LevelWPF parLevel)
			: base("Actor", parLocation, parLevel)
		{
		}

		/// <summary>
		/// Undoes the last move.
		/// </summary>
		/// <returns></returns>
		public bool UndoMove()
		{
			if (_movesStack.Count < 1)
			{
				return false;
			}
			MoveBase moveBase = _movesStack.Pop();
			MoveWPF move = moveBase as MoveWPF;
			if (move != null)
			{
				return DoMove(move);
			}
			return false;
		}
	}
}
