using ModelWPF.Game.Exception;
using ModelWPF.Game.Locations;
using ModelWPF.Game.Moves;
using ModelWPF.Game.PathFinders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModelWPF.Game.Cells.Actors
{
    public partial class Actor
    {
		/// <summary>
		/// Tries to move using the specified jump.
		/// </summary>
		/// <param name="jump">The jump that indicates where to go.</param>
		/// <returns><code>true</code> if the move completed
		/// successfully, <code>false</code> otherwise.</returns>
		internal bool DoMove(Jump jump)
		{
			bool result = false;

			if (jump.Undo)
			{
				lock (moveLock)
				{
					for (int i = jump.Route.Length - 1; i >= 0; i--)
					{
						CellLocation moveLocation = Location.GetAdjacentLocation(jump.Route[i].Direction.GetOppositeDirection());
						Cell toCell = Level[moveLocation];
						if (!toCell.TrySetContents(this))
						{
							throw new SokobanException("Unable to follow route.");
						}
					}
					MoveCount -= jump.Route.Length;
					result = true;
				}
			}
			else
			{
				WaitCallback callback = delegate
				{
					#region Anonymous Jump method.
					lock (moveLock)
					{
						SearchPathFinder searchPathFinder = new SearchPathFinder(Cell, jump.Destination);
						if (searchPathFinder.TryFindPath())
						{
							for (int i = 0; i < searchPathFinder.Route.Length; i++)
							{
								Move move = searchPathFinder.Route[i];

								/* Sleep for the stepDelay period. */
								Thread.Sleep(stepDelay);
								CellLocation moveLocation = Location.GetAdjacentLocation(move.Direction);
								Cell toCell = Level[moveLocation];
								if (!toCell.TrySetContents(this))
								{
									throw new SokobanException("Unable to follow route.");
								}
								MoveCount++;
							}
							/* Set the undo item. */
							Jump newMove = new Jump(searchPathFinder.Route) { Undo = true };
							moves.Push(newMove);
							result = true;
						}
					}
					#endregion
				};
				ThreadPool.QueueUserWorkItem(callback);
			}
			return result;
		}
	}
}
