using Model.PlayGame.Locations;
using ModelWPF.Game.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWPF.Game.Cells
{
	/// <summary>
	/// Represents a goal on the level grid
	/// where <see cref="TreasureWPF"/>s must be pushed
	/// in order to complete the <see cref="LevelWPF"/>.
	/// </summary>
	public class GoalCellWPF : CellWPF
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
				return CellContents is TreasureWPF;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GoalCellWPF"/> class.
		/// </summary>
		/// <param name="parLocation">The location of the goal
		/// on the level grid.</param>
		/// <param name="parLevel">The level grid where this cell
		/// is located.</param>
		public GoalCellWPF(Location parLocation, LevelWPF parLevel)
			: base(CELL_NAME, parLocation, parLevel)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GoalCellWPF"/> class.
		/// </summary>
		/// <param name="parLocation">The location of the goal
		/// on the level grid.</param>
		/// <param name="parLevel">The level grid where this cell
		/// is located.</param>
		/// <param name="parContents">The contents of this goal cell.</param>
		public GoalCellWPF(Location parLocation, LevelWPF parLevel, CellContentsWPF parContents)
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
		public override bool TrySetContents(CellContentsWPF parContents)
		{
			if (base.TrySetContents(parContents))
			{
				if (parContents is TreasureWPF)
				{
					OnCompletedGoalChanged(EventArgs.Empty);
				}
				return true;
			}
			return false;
		}

		/// <summary>
		/// Removes the <see cref="CellContentsWPF"/> contents from this goal.
		/// </summary>
		public override void RemoveContents()
		{
			/* Check for the removal of a treasure from goal square. */
			if (CellContents != null && CellContents is TreasureWPF)
			{
				OnCompletedGoalChanged(EventArgs.Empty);
			}
			base.RemoveContents();
		}

		#region CompletedGoalChanged event
		private event EventHandler _completedGoalChanged;

		/// <summary>
		/// Occurs when a <see cref="TreasureWPF"/> instance
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
