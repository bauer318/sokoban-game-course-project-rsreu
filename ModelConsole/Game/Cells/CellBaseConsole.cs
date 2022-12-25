using Model.PlayGame.Cell;
using Model.PlayGame.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelConsole.Game.Cells
{
    /// <summary>
	/// This is provided as a base implementation for all others CellsWPF
	/// </summary>
    public class CellBaseConsole:CellBase
    {
		/// <summary>
		/// CellBaseWPF's Constructor
		/// </summary>
		/// <param parName="name">Cell's Name</param>
		/// <param parName="location">Cell's location</param>
		public CellBaseConsole(string parName, Location parLocation) : base(parName, parLocation)
		{

		}
	}
}
