using Model.PlayGame.Locations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model.PlayGame.Cells
{
	/// <summary>
	/// Base class for all cells in a Level.
	/// </summary>
	public class CellBase: INotifyPropertyChanged
	{
		/// <summary>
		/// The context for the main UI thread
		/// </summary>
		private SynchronizationContext _context = SynchronizationContext.Current;

		/// <summary>
		/// The parName can be used to identify the type
		/// of the cell without using GetType().
		/// </summary>
		private string _name;
		/// <summary>
		/// the location on the Level.
		/// </summary>
		private Location _location;
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
		public event PropertyChangedEventHandler PropertyChanged;
		/// <summary>
		/// Raises the PropertyChanged event.
		/// </summary>
		/// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> 
		/// instance containing the event data.</param>
		public void OnPropertyChanged(PropertyChangedEventArgs e)
		{
            PropertyChanged?.Invoke(this, e);
        }

		/// <summary>
		/// Raises the PropertyChanged event.
		/// </summary>
		/// <param name="property">The name of the property that changed.</param>
		public void OnPropertyChanged(string property)
		{
			/* We use the SynchronizationContext _context
			 to ensure that we don't cause an InvalidOperationException
			 if the property change triggers something occuring
			 in the main UI thread. */
			if (_context == null)
			{
				OnPropertyChanged(new PropertyChangedEventArgs(property));
			}
			else
			{
				_context.Send(delegate
				{
					OnPropertyChanged(new PropertyChangedEventArgs(property));
				}, null);
			}
		}
		/// <summary>
		/// Gets or sets the parName of this cell.
		/// The parName can be used to identify the type
		/// of the cell without using GetType().
		/// </summary>
		/// <value>The parName of the cell. 
		/// The conceptual type parName of the cell, 
		/// such as <em>Wall</em> or <em>Floor</em></value>
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		/// <summary>
		/// Gets or sets the location on the Level>.
		/// </summary>
		/// <value>The location of the cell on the Level</value>
		public Location Location
		{
			get
			{
				return _location;
			}
			set
			{
				_location = value;
			}
		}
		/// <summary>
		/// CellBase's Constructor
		/// </summary>
		/// <param parName="name">Cells's Name</param>
		/// <param parName="location">Cells's location</param>
		public CellBase(string parName, Location parLocation)
		{
			_name = parName;
			_location = parLocation;
		}
	}
}
