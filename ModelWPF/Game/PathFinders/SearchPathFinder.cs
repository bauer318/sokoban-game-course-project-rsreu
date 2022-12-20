using ModelWPF.Game.Cells;
using ModelWPF.Game.Exception;
using ModelWPF.Game.Levels;
using ModelWPF.Game.Locations;
using ModelWPF.Game.Moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWPF.Game.PathFinders
{
	/// <summary>
	/// Searches a <see cref="Level"/> for a route
	/// between two <see cref="Location"/>s. So that
	/// an <see cref="Actor"/> may relocate by itself.
	/// </summary>
	internal class SearchPathFinder
	{
		readonly CellLocation destination;
		readonly Cell startCell;
		readonly Level level;
		Move[] route;

		/// <summary>
		/// Gets the route, or set of steps that map out
		/// the relocation. May be null.
		/// </summary>
		/// <value>The route that an <see cref="Actor"/>
		/// should take to move to destination. May be null.</value>
		public Move[] Route
		{
			get
			{
				return route;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SearchPathFinder"/> class.
		/// </summary>
		/// <param name="start">The start cell. Presumably where
		/// the <see cref="Actor"/> is located.</param>
		/// <param name="destination">Where we would like to get.</param>
		public SearchPathFinder(Cell start, CellLocation destination)
		{
			this.destination = destination;
			startCell = start;
			level = start.Level;
		}

		/// <summary>
		/// Tries to find a route to the destination.
		/// </summary>
		/// <returns></returns>
		public bool TryFindPath()
		{
			bool result = TryFindPath(startCell.Location);
			return result;
		}

		/// <summary>
		/// Main search algorithm. Attempts to locate
		/// a route to the destination location.
		/// </summary>
		/// <param name="start">The start location.</param>
		/// <returns></returns>
		bool TryFindPath(CellLocation start)
		{
			Queue<CellLocation> queue = new Queue<CellLocation>();
			queue.Enqueue(start);
			Dictionary<CellLocation, CellLocation> previousSteps = new Dictionary<CellLocation, CellLocation>();
			CellLocation location;

			while (queue.Count > 0)
			{
				location = queue.Dequeue();

				if (location.Equals(destination))
				{
					CellLocation parentLocation;
					CellLocation childLocation = location;
					List<Move> moves = new List<Move>();
					while (previousSteps.TryGetValue(childLocation, out parentLocation))
					{
						/* Create the move and add to route.*/
						Direction dir = parentLocation.GetDirection(childLocation);
						moves.Add(new Move(dir));
						childLocation = parentLocation;
					}
					moves.Reverse(); /* The moves are back to front. */
					route = moves.ToArray();
					return true;
				}
				else
				{
					for (int i = 0; i < 4; i++)
					{
						Direction direction = GetDirection(i);
						CellLocation neighbour = location.GetAdjacentLocation(direction);
						if (level[neighbour].CanEnter && !previousSteps.ContainsKey(neighbour))
						{
							previousSteps.Add(neighbour, location);
							queue.Enqueue(neighbour);
						}
					}
				}
			}
			return false;
		}

		static Direction GetDirection(int value)
		{
			switch (value)
			{
				case 0:
					return Direction.Up;
				case 1:
					return Direction.Right;
				case 2:
					return Direction.Down;
				case 3:
					return Direction.Left;
				default:
					throw new SokobanException("Invalid value: " + value);
			}
		}
	}
}
