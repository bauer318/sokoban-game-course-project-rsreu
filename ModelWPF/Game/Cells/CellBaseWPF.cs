using Model.PlayGame.Cell;
using Model.PlayGame.Locations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModelWPF.Game.Cells
{
    public class CellBaseWPF:CellBase, INotifyPropertyChanged
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
		private event PropertyChangedEventHandler _propertyChanged;

		/// <summary>
		/// Occurs when a property value changes.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged
		{
			add
			{
				_propertyChanged += value;
			}
			remove
			{
				_propertyChanged -= value;
			}
		}

		/// <summary>
		/// Raises the <see cref="E:PropertyChanged"/> event.
		/// </summary>
		/// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> 
		/// instance containing the event data.</param>
		void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			if (_propertyChanged != null)
			{
				_propertyChanged(this, e);
			}
		}

		/// <summary>
		/// Raises the <see cref="E:PropertyChanged"/> event.
		/// </summary>
		/// <param name="property">The name of the property that changed.</param>
		protected void OnPropertyChanged(string property)
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
		public CellBaseWPF(string name, Location location):base(name, location)
        {

        }
    }
}
