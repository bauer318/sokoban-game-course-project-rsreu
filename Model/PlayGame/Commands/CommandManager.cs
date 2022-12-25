using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.Commands
{
	/// <summary>
	/// Provides for execution and undoing
	/// of <see cref="CommandBase"/> instances.
	/// </summary>
	public class CommandManager
	{
		/// <summary>
		/// Command's stack
		/// </summary>
		private Stack<CommandBase> _commandStack = new Stack<CommandBase>();
		/// <summary>
		/// Redo command's stack
		/// </summary>
		private Stack<CommandBase> _redoStack = new Stack<CommandBase>();
		/// <summary>
		/// indicates if can undo
		/// </summary>
		public static bool CanUndo;

		/// <summary>
		/// Initializes a new instance of the <see cref="CommandManager"/> class.
		/// </summary>
		public CommandManager()
		{
			CanUndo = true;
		}
		/// <summary>
		/// Executes the specified command.
		/// </summary>
		/// <param name="parCommand">The command to execute.</param>
		public void Execute(CommandBase parCommand)
		{
			_redoStack.Clear();
			parCommand.Execute();
			_commandStack.Push(parCommand);
			//_canUndo = true;
		}

		/// <summary>
		/// Undoes the execution of a previous <see cref="CommandBase"/>.
		/// </summary>
		public void Undo()
		{
			if (_commandStack.Count < 1 || !CanUndo)
			{
				return;
			}
			CanUndo = false;
			CommandBase command = _commandStack.Pop();
			command.Undo();
			_redoStack.Push(command);
		}
		/// <summary>
		/// Clears the command stacks.
		/// </summary>
		public void Clear()
		{
			_commandStack.Clear();
			_redoStack.Clear();
		}
	}
}
