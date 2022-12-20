using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.Commands
{
    /// <summary>
    /// Provides for execution, undoing, and redoing
    /// of <see cref="CommandBase"/> instances.
    /// </summary>
    public class CommandManager
    {
		private Stack<CommandBase> _commandStack = new Stack<CommandBase>();
		private Stack<CommandBase> _redoStack = new Stack<CommandBase>();
		private bool _canUndo;

		/// <summary>
		/// Initializes a new instance of the <see cref="CommandManager"/> class.
		/// </summary>
		public CommandManager()
		{
			_canUndo = true;
		}

		/// <summary>
		/// Executes the specified command.
		/// </summary>
		/// <param name="command">The command to execute.</param>
		public void Execute(CommandBase command)
		{
			_redoStack.Clear();
			command.Execute();
			_commandStack.Push(command);
			_canUndo = true;
		}

		/// <summary>
		/// Undoes the execution of a previous <see cref="CommandBase"/>.
		/// </summary>
		public void Undo()
		{
			if (_commandStack.Count < 1 || !_canUndo)
			{
				return;
			}
			_canUndo = false;
			CommandBase command = _commandStack.Pop();
			command.Undo();
			_redoStack.Push(command);
		}

		/// <summary>
		/// Reperforms the execution of a <see cref="CommandBase"/>
		/// instance that has been undone, then places it back
		/// into the command stack.
		/// </summary>
		public void Redo()
		{
			if (_redoStack.Count < 1)
			{
				return;
			}
			CommandBase command = _redoStack.Pop();
			command.Execute();
			_commandStack.Push(command);
		}

		/// <summary>
		/// Clears the undo and redo stacks.
		/// </summary>
		public void Clear()
		{
			_commandStack.Clear();
			_redoStack.Clear();
		}
	}
}
