using ModelWPF.Game.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWPF.Game.Moves
{
	/// <summary>
	/// Indicates the set of steps, or route,
	/// that an <see cref="Actor"/> will take
	/// to relocate to a destination on a <see cref="Level"/>.
	/// This is used in conjuction with <see cref="SearchPathFinder"/>
	/// to locate a valid route between the <see cref="Actor"/>
	/// instance and the <see cref="Jump.Destination"/>.
	/// </summary>
	class Jump : MoveBase
	{
		/// <summary>
		/// Gets or sets the location of the destination
		/// for the jump.
		/// </summary>
		/// <value>The destination.</value>
		public CellLocation Destination
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the route from an initial location
		/// to a predefined <see cref="Destination"/>.
		/// </summary>
		/// <value>The route to the predefined <see cref="Destination"/>.
		/// May be null.</value>
		public Move[] Route
		{
			get;
			private set;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Jump"/> class.
		/// </summary>
		/// <param name="destination">The destination of the jump. 
		/// <seealso cref="Destination"/></param>
		public Jump(CellLocation destination)
		{
			this.Destination = destination;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Jump"/> class.
		/// Use to perform an undo.
		/// </summary>
		/// <param name="route">The route that was previously calculated.</param>
		public Jump(Move[] route)
		{
			Route = route;
		}
	}
}
