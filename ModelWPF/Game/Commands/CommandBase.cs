﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWPF.Game.Commands
{
	/// <summary>
	/// A command represents an application
	/// action, that can be executed, undone, and redone.
	/// </summary>
	public abstract class CommandBase
	{
		/// <summary>
		/// Executes this command.
		/// </summary>
		public abstract void Execute();
		/// <summary>
		/// Undoes that which was performed with <see cref="E:Execute"/>.
		/// </summary>
		public abstract void Undo();
		/// <summary>
		/// Redoes this command after it has been undone. <see cref="E:Undo"/>.
		/// </summary>
		public abstract void Redo();
	}
}
