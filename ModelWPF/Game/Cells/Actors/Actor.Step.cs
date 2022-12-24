using Model.PlayGame.Commands;
using Model.PlayGame.Locations;
using Model.PlayGame.Moves;
using ModelWPF.Game.Moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWPF.Game.Cells.Actors
{
	public partial class Actor
	{
		/// <summary>
		/// Tries to move in the direction of the specified move.
		/// </summary>
		/// <param name="parMove">The move indicating where to go.</param>
		/// <returns><code>true</code> if the move completed
		/// successfully, <code>false</code> otherwise.</returns>
		internal bool DoMove(MoveWPF parMove)
		{
			lock (_moveLock)
			{
				return DoMoveAux(parMove);
			}
		}
		internal bool DoMoveAux(MoveWPF parMove)
		{
			bool result = false;
			Location moveLocation = Location.GetAdjacentLocation(parMove.Direction);
			if (Level.InBounds(moveLocation))
			{
				CellWPF toCell = Level[moveLocation];
				CellWPF fromCell = Level[Location];
				CellContentsWPF toCellContents = toCell.CellContents;

				if (toCell.CanEnter)
				{   /* Empty cell. */
					if (!parMove.Undo)
					{   /* Regular move - nominal case. */
						result = toCell.TrySetContents(this);
						if (result)
						{
							MoveWPF newMove = new MoveWPF(parMove.Direction.GetOppositeDirection()) { Undo = true };
							_movesStack.Push(newMove);
							CommandManager.CanUndo = true;
							MoveCount++;
						}
					}
					else if (parMove.PushedContents != null)
					{   /* Is an undo and there was contents. */
						toCell.TrySetContents(this);
						result = fromCell.TrySetContents(parMove.PushedContents);
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
				else if (toCell.TryPushContents(parMove.Direction))
				{   /* Wasn't able to enter, but could push contents. */
					if (!parMove.Undo)
					{
						MoveWPF newMove = new MoveWPF(parMove.Direction.GetOppositeDirection()) { Undo = true, PushedContents = toCellContents };
						_movesStack.Push(newMove);
					}

					result = toCell.TrySetContents(this);
					if (result)
					{
						CommandManager.CanUndo = true;
						MoveCount++;
					}
				}
			}

			return result;
		}
	}
}
