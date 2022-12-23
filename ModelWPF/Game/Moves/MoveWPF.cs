using Model.PlayGame.Locations;
using Model.PlayGame.Moves;
using ModelWPF.Game.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWPF.Game.Moves
{
    public class MoveWPF:MoveBase
    {
		/// <summary>
		/// Gets or sets the contents that were moved
		/// as part of the relocation. This is used for undo's.
		/// </summary>
		/// <value>The contents that were pushed 
		/// as part of the relocation.</value>
		public CellContentsWPF PushedContents
		{
			get;
			set;
		}
		public MoveWPF(Direction direction) : base(direction) 
		{
			
		}
	}
}
