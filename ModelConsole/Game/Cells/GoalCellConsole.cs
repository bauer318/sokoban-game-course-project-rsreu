using Model.PlayGame.Locations;
using ModelConsole.Game.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelConsole.Game.Cells
{
    /// <summary>
	/// Represents a goal on the level grid
	/// where <see cref="TreasureConsole"/>s must be pushed
	/// in order to complete the <see cref="LevelConsole"/>.
	/// </summary>
    public class GoalCellConsole:CellConsole
    {
		/// <summary>
		/// Cell's name
		/// </summary>
		private const string CELL_NAME = "Goal";

		/// <summary>
		/// Gets a value indicating whether this instance has a treasure in it.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance has a treasure; otherwise, <c>false</c>.
		/// </value>
		public bool HasTreasure
		{
			get
			{
				return CellContents is TreasureConsole;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GoalCellConsole"/> class.
		/// </summary>
		/// <param name="parLocation">The location of the goal
		/// on the level grid.</param>
		/// <param name="parLevel">The level grid where this cell
		/// is located.</param>
		public GoalCellConsole(Location parLocation, LevelConsole parLevel)
			: base(CELL_NAME, parLocation, parLevel)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GoalCellConsole"/> class.
		/// </summary>
		/// <param name="parLocation">The location of the goal
		/// on the level grid.</param>
		/// <param name="parLevel">The level grid where this cell
		/// is located.</param>
		/// <param name="parContents">The contents of this goal cell.</param>
		public GoalCellConsole(Location parLocation, LevelConsole parLevel, CellContentsConsole parContents)
			: base(CELL_NAME, parLocation, parLevel, parContents)
		{
		}

		/// <summary>
		/// Tries the set the contents of this goal.
		/// </summary>
		/// <param name="parContents">The contents to set.</param>
		/// <returns><code>true</code> if the contents 
		/// was successfully placed on the goal, <code>false</code> otherwise.
		/// </returns>
		public override bool TrySetContents(CellContentsConsole parContents)
		{
			if (base.TrySetContents(parContents))
			{
				if (parContents is TreasureConsole)
				{
					OnCompletedGoalChanged(EventArgs.Empty);
				}
				return true;
			}
			return false;
		}

		/// <summary>
		/// Removes the <see cref="CellContentsConsole"/> contents from this goal.
		/// </summary>
		public override void RemoveContents()
		{
			/* Check for the removal of a treasure from goal square. */
			if (CellContents != null && CellContents is TreasureConsole)
			{
				OnCompletedGoalChanged(EventArgs.Empty);
			}
			base.RemoveContents();
		}

		#region CompletedGoalChanged event
		private event EventHandler _completedGoalChanged;

		/// <summary>
		/// Occurs when a <see cref="TreasureConsole"/> instance
		/// is either removed from or placed in this goal.
		/// </summary>
		public event EventHandler CompletedGoalChanged
		{
			add
			{
				_completedGoalChanged += value;
			}
			remove
			{
				_completedGoalChanged -= value;
			}
		}

		/// <summary>
		/// Raises the CompletedGoalChanged event.
		/// </summary>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected void OnCompletedGoalChanged(EventArgs e)
		{
			if (_completedGoalChanged != null)
			{
				_completedGoalChanged(this, e);
			}
		}
		#endregion
	}
}
