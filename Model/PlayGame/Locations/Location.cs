using Model.PlayGame.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.Locations
{
	/// <summary>
	/// Cell's location on the game's map
	/// </summary>
	public class Location
	{
		/// <summary>
		/// The row number.
		/// </summary>
		private int _rowNumber;
		/// <summary>
		/// The column number
		/// </summary>
		private int _columnNumber;
		/// <summary>
		/// Gets the row number.
		/// </summary>
		/// <value>The row number.</value>
		public int RowNumber
		{
			get
			{
				return _rowNumber;
			}
			private set
			{
				_rowNumber = value;
			}
		}

		/// <summary>
		/// Gets the column number.
		/// </summary>
		/// <value>The column number.</value>
		public int ColumnNumber
		{
			get
			{
				return _columnNumber;
			}
			private set
			{
				_columnNumber = value;
			}
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Location"/> class.
		/// </summary>
		/// <param name="parRowNumber">The row number.</param>
		/// <param name="parColumnNumber">The column number.</param>
		public Location(int parRowNumber, int parColumnNumber)
		{
			_rowNumber = parRowNumber;
			_columnNumber = parColumnNumber;
		}
		/// <summary>
		/// Gets the location of an adjacent location 
		/// that is in the specified direction.
		/// </summary>
		/// <param name="parDirection">The direction of the adjacent location.</param>
		/// <returns></returns>
		public Location GetAdjacentLocation(Direction parDirection)
		{
			switch (parDirection)
			{
				case Direction.Up:
					return new Location(_rowNumber - 1, _columnNumber);
				case Direction.Down:
					return new Location(_rowNumber + 1, _columnNumber);
				case Direction.Left:
					return new Location(_rowNumber, _columnNumber - 1);
				case Direction.Right:
					return new Location(_rowNumber, _columnNumber + 1);
				default:
					throw new SokobanException("Unkown direction. " + parDirection.ToString());
			}
		}

		/// <summary>
		/// Determines whether the specified location is adjacent to this instance.
		/// That is, whether it is located one point to the left, right, above, or below.
		/// </summary>
		/// <param name="parLocation">The location.</param>
		/// <returns>
		/// 	<c>true</c> if the specified location is adjacent; otherwise, <c>false</c>.
		/// </returns>
		public bool IsAdjacentLocation(Location parLocation)
		{
			return !parLocation.Equals(this)
				   && ((_columnNumber == parLocation.ColumnNumber
						&& _rowNumber <= parLocation.RowNumber + 1
						&& _rowNumber >= parLocation.RowNumber - 1)
					   ||
					   (_rowNumber == parLocation.RowNumber
						&& _columnNumber <= parLocation.ColumnNumber + 1
						&& _columnNumber >= parLocation.ColumnNumber - 1)
					  );
		}

		/// <summary>
		/// Gets the direction of an adjancent location 
		/// relative to the current instance.
		/// </summary>
		/// <param name="parLocation">The location of an adjacent location.</param>
		/// <returns></returns>
		/// <exception cref="SokobanException">If the location is
		/// not adjacent to the current instance.</exception>
		public Direction GetDirection(Location parLocation)
		{
			if (!IsAdjacentLocation(parLocation))
			{
				throw new SokobanException("location is not adjacent.");
			}

			if (parLocation.ColumnNumber > _columnNumber)
			{
				return Direction.Right;
			}
			else if (parLocation.ColumnNumber < _columnNumber)
			{
				return Direction.Left;
			}
			else if (parLocation.RowNumber > _rowNumber)
			{
				return Direction.Down;
			}

			return Direction.Up;
		}

		/// <summary>
		/// Determines whether the specified <see cref="T:System.Object"/> 
		/// is equal to the current <see cref="T:Location"/>.
		/// </summary>
		/// <param name="parObject">The <see cref="T:System.Object"/> 
		/// to compare with the current <see cref="T:Location"/>.</param>
		/// <returns>
		/// true if the specified <see cref="T:System.Object"/> 
		/// is equal to the current <see cref="T:Location"/>; otherwise, false.
		/// </returns>
		public override bool Equals(object parObject)
		{
			if (parObject == null)
			{
				return false;
			}
			Location location = parObject as Location;
			if (location == null)
			{
				return false;
			}
			return location.RowNumber == _rowNumber && location.ColumnNumber == _columnNumber;
		}

		/// <summary>
		/// Serves as a hash function for a particular type.
		/// </summary>
		/// <returns>
		/// A hash code for the current <see cref="T:Location"/>.
		/// The XOR of the <see cref="RowNumber"/> and <see cref="ColumnNumber"/>.
		/// </returns>
		public override int GetHashCode()
		{
			return _rowNumber ^ _columnNumber;
		}
	}
}
