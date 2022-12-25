using Model.PlayGame.Locations;
using ModelConsole.Game.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelConsole.Game.Cells
{
    /// <summary>
    /// Base class for all cells in a Level.
    /// </summary>
    public abstract class CellConsole:CellBaseConsole
    {
        /// <summary>
        /// The level where this cell is located
        /// </summary>
        private LevelConsole _level;
        /// <summary>
        /// The cell contents
        /// </summary>
        private CellContentsConsole _cellContents;
        /// <summary>
        /// Gets or sets the level where this cell is located.
        /// </summary>
        /// <value>The level where this cell is located.</value>
        public LevelConsole Level
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
        /// <value>The cell contents, such as a <em>TreasureConsole</em>,
        /// or an <em>Actors</em>.</value>
        public CellContentsConsole CellContents
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
            //OnPropertyChanged("CellContents");
        }

        /// <summary>
        /// Gets a value indicating whether cell contents can be put here.
        /// </summary>
        /// <value><c>true</c> if this instance will accept 
        /// an instance of CellContentsConsole
        /// otherwise, <c>false</c>.</value>
        public virtual bool CanEnter
        {
            get
            {
                return _cellContents == null;
            }
        }

        /// <summary>
        /// Initializes a new instance of the CellConsole class.
        /// </summary>
        /// <param name="name">The name of the cell.</param>
        /// <param name="location">The location of the cell. <seealso cref="Location"/></param>
        /// <param name="level">The level where the cell is located. <seealso cref="LevelConsole"/></param>
        public CellConsole(string name, Location location, LevelConsole level) : base(name, location)
        {
            Level = level;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CellConsole"/> class.
        /// </summary>
        /// <param name="parName">The name of the cell.</param>
        /// <param name="parLocation">The location of the cell. <seealso cref="Location"/></param>
        /// <param name="parLevel">The level where the cell is located. <seealso cref="LevelConsole"/></param>
        /// <param name="parContents">The contents of this cell. <seealso cref="CellContentsConsole"/>/param>
        public CellConsole(string parName, Location parLocation, LevelConsole parLevel, CellContentsConsole parContents)
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
        public virtual bool TrySetContents(CellContentsConsole parContents)
        {
            if (CanEnter)
            {
                parContents.Cell.RemoveContents();
                ChangeCellContents(parContents);
                //OnPropertyChanged("CellContents");
                return true;
            }
            return false;
        }
        private void ChangeCellContents(CellContentsConsole parContents)
        {
            /* Add to this cell. */
            _cellContents = parContents;
            /* Make sure the content knows where it is. */
            parContents.Cell = this;
        }

        /// <summary>
        /// Tries to push the current <see cref="CellContentsConsole"/>
        /// to the cell neighbour in the specified direction.
        /// </summary>
        /// <param name="parDirection">The direction of an adjacent
        /// cell in which to place this cell's <see cref="CellContentsConsole"/>.</param>
        /// <returns><code>true</code> if the contents was able 
        /// to be placed in the adjacent cell; <code>false</code> otherwise.</returns>
        public bool TryPushContents(Direction parDirection)
        {
            if (!CanPush(parDirection))
            {
                return false;
            }
            CellConsole neighbour = _level[Location.GetAdjacentLocation(parDirection)];
            neighbour.TrySetContents(_cellContents);
            return true;
        }

        /// <summary>
        /// Determines whether this instance can push the current
        /// <see cref="CellContentsConsole"/> in the specified direction.
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
            CellConsole neighbour = _level[Location.GetAdjacentLocation(parDirection)];
            return neighbour != null && neighbour.CanEnter;
        }

    }
}
