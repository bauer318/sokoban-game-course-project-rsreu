using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model.PlayGame.Levels
{
	/// <summary>
	/// Base implementaion for all content within
	/// </summary>
	public abstract class LevelContentBase
    {
		private SynchronizationContext _context = SynchronizationContext.Current;
		/// <summary>
		/// Gets or sets the _context used to post 
		/// to the main UI thread.
		/// </summary>
		/// <value>The _context used to post to the main
		/// UI thread.</value>
		public SynchronizationContext Context
		{
			get
			{
				if (_context == null)
				{
					_context = SynchronizationContext.Current;
				}
				return _context;
			}
			set
			{
				_context = value;
			}
		}
	}
}
