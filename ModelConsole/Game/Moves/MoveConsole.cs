using Model.PlayGame.Locations;
using Model.PlayGame.Moves;
using ModelConsole.Game.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelConsole.Game.Moves
{
    /// <summary>
	/// Describes a single step that an Actor will take
	/// to relocate to a destination on a Level.
	/// </summary>
    public class MoveConsole:MoveBase
    {
		/// <summary>
		/// The contents that were pushed 
		/// </summary>
		private CellContentsConsole _pushedContents;
		/// <summary>
		/// Gets or sets the contents that were moved
		/// as part of the relocation. This is used for undo's.
		/// </summary>
		/// <value>The contents that were pushed 
		/// as part of the relocation.</value>
		public CellContentsConsole PushedContents
		{
			get
			{
				return _pushedContents;
			}
			set
			{
				_pushedContents = value;
			}
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="MoveConsole"/> class.
		/// </summary>
		/// <param name="parDirection">The direction in an <see cref="Actor"/> 
		/// should relocate. <seealso cref="Direction"/></param>
		public MoveConsole(Direction parDirection) : base(parDirection)
		{

		}
	}
}
