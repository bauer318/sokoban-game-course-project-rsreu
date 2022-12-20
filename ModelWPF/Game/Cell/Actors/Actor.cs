using ModelWPF.Game.Levels;
using ModelWPF.Game.Locations;
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
	public partial class Actor:CellContents
    {
		readonly Stack<MoveBase> moves = new Stack<MoveBase>();
		int moveCount;
		/* lock object for the DoMove methods. */
		readonly object moveLock = new object();

		/// <summary>
		/// Gets the move count.
		/// </summary>
		/// <value>The number of moves (or steps)
		/// that the actor has completed.</value>
		public int MoveCount
		{
			get
			{
				return moveCount;
			}
			private set
			{
				moveCount = value;
				if (moveCount < 0)
				{   /* Just in case. */
					moveCount = 0;
				}
				OnPropertyChanged("MoveCount");
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Actor"/> class.
		/// </summary>
		/// <param name="location">The location.</param>
		/// <param name="level">The level.</param>
		public Actor(CellLocation location, Level level)
			: base("Actor", location, level)
		{
		}

		/// <summary>
		/// Undoes the last move.
		/// The move may be a single move, or it may be a series
		/// of moves that were taken as part of a <see cref="Jump"/>.
		/// </summary>
		/// <returns></returns>
		public bool UndoMove()
		{
			if (moves.Count < 1)
			{
				return false;
			}
			MoveBase moveBase = moves.Pop();
			Move move = moveBase as Move;
			if (move != null)
			{
				return DoMove(move);
			}
			return false;
		}
	}
}
