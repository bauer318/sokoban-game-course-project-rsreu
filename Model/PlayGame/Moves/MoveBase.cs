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
	/// Moves describe an Actor relocation.
	/// </summary>
	public class MoveBase
	{
		/// <summary>
		/// indicates whether this <see cref="MoveBase"/> is an undo
		/// </summary>
		private bool _undo;
		/// <summary>
		/// The direction to relocate
		/// </summary>
		private Direction _direction;
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="MoveBase"/> is an undo.
		/// That is, it is a reversion of a previously executed move.
		/// </summary>
		/// <value><c>true</c> if an undo; otherwise, <c>false</c>.</value>
		public bool Undo
		{
			get
			{
				return _undo;
			}
			set
			{
				_undo = value;
			}
		}
		/// <summary>
		/// Gets the direction in which to relocate.
		/// </summary>
		/// <value>The direction to relocate.</value>
		public Direction Direction
		{
			get
			{
				return _direction;
			}
			private set
			{
				_direction = value;
			}
		}
		/// <summary>
		/// MoveBase's contructor
		/// </summary>
		/// <param name="parDirection">The direction to relocate</param>
		public MoveBase(Direction parDirection)
		{
			_direction = parDirection;
		}
	}
}
