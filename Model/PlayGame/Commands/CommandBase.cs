using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.Commands
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
		/// Undoes that which was performed with
		/// </summary>
		public abstract void Undo();
	}
}
