using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.Exceptions
{
	/// <summary>
	/// For all application's exceptions
	/// </summary>
	public class SokobanException : ApplicationException
	{
		/// <summary>
		/// Default's contructor
		/// </summary>
		public SokobanException()
		{
		}
		/// <summary>
		/// Constructor with message's exception
		/// </summary>
		/// <param name="parMessage">message's exception</param>
		public SokobanException(string parMessage)
			: base(parMessage)
		{
		}
	}
}
