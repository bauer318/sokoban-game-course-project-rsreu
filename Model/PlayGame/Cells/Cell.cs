using Model.PlayGame.Levels;
using Model.PlayGame.Locations;

namespace Model.PlayGame.Cells
{
    /// <summary>
    /// Base implementation class for all Cells
    /// </summary>
    public class Cell : CellBase
    {
        /// <summary>
        /// The level where this cell is located
        /// </summary>
        private Level _level;
        /// <summary>
        /// The cell contents
        /// </summary>
        private CellContents _cellContents;
        /// <summary>
        /// Gets or sets the level where this cell is located.
        /// </summary>
        /// <value>The level where this cell is located.</value>
        public Level Level
        {
            get
            {
                return _level;
            }
            private set
            {
                _level = value;
            }
        }

        /// <summary>
        /// Gets or sets the cell contents of this cell.
        /// </summary>
        /// <value>The cell contents, such as a <em>Treasure</em>,
        /// or an <em>Actors</em>.</value>
        public CellContents CellContents
        {
            get
            {
                return _cellContents;

            }
            private set
            {
                _cellContents = value;

            }
        }

        /// <summary>
        /// Removes the contents of the cell.
        /// Sets the CellContents to null.
        /// </summary>
        public virtual void RemoveContents()
        {
            _cellContents = null;
            OnPropertyChanged("CellContents");
        }

        /// <summary>
        /// Gets a value indicating whether cell contents can be put here.
        /// </summary>
        /// <value><c>true</c> if this instance will accept 
        /// an instance of CellContents
        /// otherwise, <c>false</c>.</value>
        public virtual bool CanEnter
        {
            get
            {
                return _cellContents == null;
            }
        }

        /// <summary>
        /// Initializes a new instance of the Cell class.
        /// </summary>
        /// <param name="parName">The name of the cell.</param>
        /// <param name="parLocation">The location of the cell. <seealso cref="Location"/></param>
        /// <param name="parLevel">The level where the cell is located. <seealso cref="Level"/></param>
        public Cell(string parName, Location parLocation, Level parLevel) : base(parName, parLocation)
        {
            _level = parLevel;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        /// <param name="parName">The name of the cell.</param>
        /// <param name="parLocation">The location of the cell. <seealso cref="Location"/></param>
        /// <param name="parLevel">The level where the cell is located. <seealso cref="Level"/></param>
        /// <param name="parContents">The contents of this cell. <seealso cref="CellContents"/>/param>
        public Cell(string parName, Location parLocation, Level parLevel, CellContents parContents)
            : this(parName, parLocation, parLevel)
        {
            ChangeCellContents(parContents);
        }

        /// <summary>
        /// Tries to the set the cell contents.
        /// </summary>
        /// <param name="parContents">The contents to place in the cell.</param>
        /// <returns><code>true</code> if the specified contents
        /// was able to be placed in this cell; <code>false</code> otherwise.</returns>
        public virtual bool TrySetContents(CellContents parContents)
        {
            if (CanEnter)
            {
                parContents.Cell.RemoveContents();
                ChangeCellContents(parContents);
                OnPropertyChanged("CellContents");
                return true;
            }
            return false;
        }
        /// <summary>
        /// Changes the cell's contents
        /// </summary>
        /// <param name="parContents">Cell's contents</param>
        private void ChangeCellContents(CellContents parContents)
        {
            /* Add to this cell. */
            _cellContents = parContents;
            /* Make sure the content knows where it is. */
            parContents.Cell = this;
        }

        /// <summary>
        /// Tries to push the current <see cref="CellContents"/>
        /// to the cell neighbour in the specified direction.
        /// </summary>
        /// <param name="parDirection">The direction of an adjacent
        /// cell in which to place this cell's <see cref="CellContents"/>.</param>
        /// <returns><code>true</code> if the contents was able 
        /// to be placed in the adjacent cell; <code>false</code> otherwise.</returns>
        public bool TryPushContents(Direction parDirection)
        {
            if (!CanPush(parDirection))
            {
                return false;
            }
            Cell neighbour = _level[Location.GetAdjacentLocation(parDirection)];
            neighbour.TrySetContents(_cellContents);
            return true;
        }

        /// <summary>
        /// Determines whether this instance can push the current
        /// <see cref="CellContents"/> in the specified direction.
        /// </summary>
        /// <param name="parDirection">The direction in which the cell contents
        /// should be tested for movability. That is, the direction
        /// of an adjacent cell that the cell contents might be placed.</param>
        /// <returns>
        /// 	<c>true</c> if this instance can push the cell contents to an adjacent
        /// cell in the specified direction; otherwise, <c>false</c>.
        /// </returns>
        public bool CanPush(Direction parDirection)
        {
            if (_cellContents == null)
            {
                return false;
            }
            Cell neighbour = _level[Location.GetAdjacentLocation(parDirection)];
            return neighbour != null && neighbour.CanEnter;
        }
    }
}
