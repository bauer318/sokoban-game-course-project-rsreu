﻿using Model.PlayGame.Levels;
using Model.PlayGame.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.Cell
{
	/// <summary>
	/// Represents a goal on the Level grid
	/// where <see cref="Treasure"/>s must be pushed
	/// in order to complete the <see cref="Level"/>.
	/// </summary>
	public class GoalCell : Cell
	{
		const string cellName = "Goal";
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
		/// <param name="location">The location of the goal
		/// on the Level grid.</param>
		/// <param name="level">The Level grid where this cell
		/// is located.</param>
		public GoalCell(Location location, Level level)
			: base(cellName, location, level)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GoalCell"/> class.
		/// </summary>
		/// <param name="location">The location of the goal
		/// on the Level grid.</param>
		/// <param name="level">The Level grid where this cell
		/// is located.</param>
		/// <param name="contents">The contents of this goal cell.</param>
		public GoalCell(Location location, Level level, CellContents contents)
			: base(cellName, location, level, contents)
		{
		}

		private event EventHandler completedGoalChanged;

		/// <summary>
		/// Occurs when a <see cref="Treasure"/> instance
		/// is either removed from or placed in this goal.
		/// </summary>
		public event EventHandler CompletedGoalChanged
		{
			add
			{
				completedGoalChanged += value;
			}
			remove
			{
				completedGoalChanged -= value;
			}
		}
		/// <summary>
		/// Raises the <see cref="E:CompletedGoalChanged"/> event.
		/// </summary>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected void OnCompletedGoalChanged(EventArgs e)
		{
			if (completedGoalChanged != null)
			{
				completedGoalChanged(this, e);
			}
		}
		public override bool TrySetContents(CellContents contents)
		{
			throw new NotImplementedException();
		}

        public override void RemoveContents()
        {
            throw new NotImplementedException();
        }
    }
}