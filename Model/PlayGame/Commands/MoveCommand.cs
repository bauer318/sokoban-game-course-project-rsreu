﻿using Model.PlayGame.Levels;
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
	/// Performs a move with the <see cref="Levels.Level"/>'s <see cref="Actor"/>
	/// instance. A move is a single step.
	/// </summary>
    public class MoveCommand:CommandBase
    {
		public Level Level
        {
			get;
			set;
        }

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
		/// <param name="level">The Level where the move will take place.</param>
		/// <param name="direction">The direction of the move.</param>
		public MoveCommand(Level level, Direction direction)
		{
			if (level == null)
			{
				throw new ArgumentNullException("Level");
			}
			Direction = direction;
			this.Level = level;
		}

		/// <summary>
		/// Executes this command.
		/// Move the <see cref="Actor"/> one step
		/// in the predefined <see cref="Direction"/>.
		/// </summary>
		public override void Execute()
		{
			Move move = new Move(Direction);
			Level.Actor.DoMove(move);
		}

		/// <summary>
		/// Undoes that which was performed with <see cref="Execute"/>.
		/// Steps back to the original location.
		/// </summary>
		public override void Undo()
		{
			Level.Actor.UndoMove();
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
