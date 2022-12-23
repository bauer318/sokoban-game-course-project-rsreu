using Model.PlayGame.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.Moves
{
	/// <summary>
	/// Base implementation for _moves.
	/// Moves describe an <see cref="Actor"/> relocation.
	/// </summary>
	public class MoveBase
	{
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="MoveBase"/> is an undo.
		/// That is, it is a reversion of a previously executed move.
		/// </summary>
		/// <value><c>true</c> if an undo; otherwise, <c>false</c>.</value>
		public bool Undo
		{
			get;
			set;
		}
		/// <summary>
		/// Gets the direction in which to relocate.
		/// </summary>
		/// <value>The direction to relocate.</value>
		public Direction Direction
		{
			get;
			private set;
		}

		public MoveBase(Direction direction)
        {
			Direction = direction;
        }
	}
}
