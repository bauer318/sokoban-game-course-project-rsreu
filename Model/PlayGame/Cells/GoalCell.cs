using Model.PlayGame.Levels;
using Model.PlayGame.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.Cells
{
	/// <summary>
	/// Represents a goal on the level grid
	/// where <see cref="Treasure"/>s must be pushed
	/// in order to complete the <see cref="Level"/>.
	/// </summary>
	public class GoalCell : Cell
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
				return CellContents is Treasure;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GoalCell"/> class.
		/// </summary>
		/// <param name="parLocation">The location of the goal
		/// on the level grid.</param>
		/// <param name="parLevel">The level grid where this cell
		/// is located.</param>
		public GoalCell(Location parLocation, Level parLevel)
			: base(CELL_NAME, parLocation, parLevel)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GoalCell"/> class.
		/// </summary>
		/// <param name="parLocation">The location of the goal
		/// on the level grid.</param>
		/// <param name="parLevel">The level grid where this cell
		/// is located.</param>
		/// <param name="parContents">The contents of this goal cell.</param>
		public GoalCell(Location parLocation, Level parLevel, CellContents parContents)
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
		public override bool TrySetContents(CellContents parContents)
		{
			if (base.TrySetContents(parContents))
			{
				if (parContents is Treasure)
				{
					OnCompletedGoalChanged(EventArgs.Empty);
				}
				return true;
			}
			return false;
		}

		/// <summary>
		/// Removes the <see cref="CellContents"/> contents from this goal.
		/// </summary>
		public override void RemoveContents()
		{
			/* Check for the removal of a treasure from goal square. */
			if (CellContents != null && CellContents is Treasure)
			{
				OnCompletedGoalChanged(EventArgs.Empty);
			}
			base.RemoveContents();
		}

		#region CompletedGoalChanged event
		private event EventHandler _completedGoalChanged;

		/// <summary>
		/// Occurs when a <see cref="Treasure"/> instance
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
