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
    public partial class Actor
    {
		/// <summary>
		/// Tries to move in the direction of the specified move.
		/// </summary>
		/// <param name="move">The move indicating where to go.</param>
		/// <returns><code>true</code> if the move completed
		/// successfully, <code>false</code> otherwise.</returns>
		public bool DoMove(Move move)
		{
			lock (_moveLock)
			{
				return DoMoveAux(move);
			}
		}

		public bool DoMoveAux(Move move)
		{
			bool result = false;
			Location moveLocation = Location.GetAdjacentLocation(move.Direction);
			if (Level.InBounds(moveLocation))
			{
				Cell toCell = Level[moveLocation];
				Cell fromCell = Level[Location];
				CellContents toCellContents = toCell.CellContents;

				if (toCell.CanEnter)
				{   /* Empty cell. */
					if (!move.Undo)
					{   /* Regular move - nominal case. */
						result = toCell.TrySetContents(this);
						if (result)
						{
							Move newMove = new Move(move.Direction.GetOppositeDirection()) { Undo = true };
							_moves.Push(newMove);
							MoveCount++;
						}
					}
					else if (move.PushedContents != null)
					{   /* Is an undo and there was contents. */
						toCell.TrySetContents(this);
						result = fromCell.TrySetContents(move.PushedContents);
						if (result)
						{
							MoveCount--;
						}
					}
					else
					{   /* Is an undo and there wasn't contents. */
						result = toCell.TrySetContents(this);
						if (result)
						{
							MoveCount--;
						}
					}
				}
				else if (toCell.TryPushContents(move.Direction))
				{   /* Wasn't able to enter, but could push contents. */
					if (!move.Undo)
					{
						Move newMove = new Move(move.Direction.GetOppositeDirection()) { Undo = true, PushedContents = toCellContents };
						_moves.Push(newMove);
					}

					result = toCell.TrySetContents(this);
					if (result)
					{
						MoveCount++;
					}
				}
			}

			return result;
		}
	}
}
