using Model.PlayGame.Levels;
using Model.PlayGame.Locations;
using Model.PlayGame.Moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.Commands
{
    /// <summary>
	/// Performs a move with the <see cref="Level"/>'s Actor
	/// instance. A move is a single step.
	/// </summary>
    public class MoveCommand:CommandBase
    {
		/// <summary>
		/// The Game's Level
		/// </summary>
		private Level _level;
		/// <summary>
		/// The direction that the move will take place
		/// </summary>
		private Direction _direction;

		/// <summary>
		/// Gets or sets the direction for the Move.
		/// </summary>
		/// <value>The direction that the move will take place.</value>
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
		/// Initializes a new instance of the <see cref="MoveCommand"/> class.
		/// </summary>
		/// <param name="parLevel">The level where the move will take place.</param>
		/// <param name="parDirection">The direction of the move.</param>
		public MoveCommand(Level parLevel, Direction parDirection)
		{
			if (parLevel == null)
			{
				throw new ArgumentNullException("level");
			}
			_direction = parDirection;
			this._level = parLevel;
		}

		/// <summary>
		/// Executes this command.
		/// Move the Actor one step
		/// in the predefined Direction.
		/// </summary>
		public override void Execute()
		{
			Move move = new(Direction);
			_level.Actor.DoMove(move);
		}

		/// <summary>
		/// Undoes that which was performed with Execute.
		/// Steps back to the original location.
		/// </summary>
		public override void Undo()
		{
			_level.Actor.UndoMove();
		}
	}
}
