using Model.PlayGame.Levels;
using Model.PlayGame.Locations;
using Model.PlayGame.Moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.Cell.Actors
{
    public partial class Actor: CellContents
    {
		private readonly Stack<MoveBase> _moves = new Stack<MoveBase>();
		private int _moveCount;
		/* lock object for the DoMove methods. */
		private readonly object _moveLock = new object();

		/// <summary>
		/// Gets the move count.
		/// </summary>
		/// <value>The number of _moves (or steps)
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
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Actor"/> class.
		/// </summary>
		/// <param name="location">The location.</param>
		/// <param name="level">The level.</param>
		public Actor(Location location, Level level)
			: base("Actor", location, level)
		{
		}

		/// <summary>
		/// Undoes the last move.
		/// The move may be a single move, or it may be a series
		/// of _moves that were taken as part of a <see cref="Jump"/>.
		/// </summary>
		/// <returns></returns>
		public bool UndoMove()
		{
			if (_moves.Count < 1)
			{
				return false;
			}
			MoveBase moveBase = _moves.Pop();
			Move move = moveBase as Move;
			if (move != null)
			{
				return DoMove(move);
			}
			
			return false;
		}
	}
}
