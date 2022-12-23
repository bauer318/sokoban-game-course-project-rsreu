using Model.PlayGame.Locations;
using Model.PlayGame.Moves;
using ModelWPF.Game.Levels;
using ModelWPF.Game.Moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWPF.Game.Commands
{
	/// <summary>
	/// Performs a move with the <see cref="Level"/>'s <see cref="Actor"/>
	/// instance. A move is a single step.
	/// </summary>
	public class MoveCommand : CommandBase
	{
		Level level;

		/// <summary>
		/// Gets or sets the direction for the <see cref="Move"/>.
		/// </summary>
		/// <value>The direction that the move will take place.</value>
		public Direction Direction
		{
			get;
			private set;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MoveCommand"/> class.
		/// </summary>
		/// <param name="level">The level where the move will take place.</param>
		/// <param name="direction">The direction of the move.</param>
		public MoveCommand(Level level, Direction direction)
		{
			if (level == null)
			{
				throw new ArgumentNullException("level");
			}
			Direction = direction;
			this.level = level;
		}

		/// <summary>
		/// Executes this command.
		/// Move the <see cref="Actor"/> one step
		/// in the predefined <see cref="Direction"/>.
		/// </summary>
		public override void Execute()
		{
			MoveWPF move = new MoveWPF(Direction);
			level.Actor.DoMove(move);
		}

		/// <summary>
		/// Undoes that which was performed with <see cref="Execute"/>.
		/// Steps back to the original location.
		/// </summary>
		public override void Undo()
		{
			level.Actor.UndoMove();
		}

		/// <summary>
		/// Redoes this command after it has been undone. <see cref="Undo"/>.
		/// </summary>
		public override void Redo()
		{
			Execute();
		}
	}
}
