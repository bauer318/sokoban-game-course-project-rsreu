using Model.PlayGame.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.Locations
{
	/// <summary>
	/// Extends Direction's enum with static method
	/// </summary>
	public static class DirectionMethods
	{
		/// <summary>
		/// Gets the opposite direction for the direction.
		/// </summary>
		/// <param name="parDirection">The direction.</param>
		/// <returns></returns>
		public static Direction GetOppositeDirection(this Direction parDirection)
		{
			switch (parDirection)
			{
				case Direction.Up:
					return Direction.Down;
				case Direction.Down:
					return Direction.Up;
				case Direction.Left:
					return Direction.Right;
				case Direction.Right:
					return Direction.Left;
				default:
					throw new SokobanException("Invalid direction: " + parDirection.ToString());
			}
		}
	}
}
