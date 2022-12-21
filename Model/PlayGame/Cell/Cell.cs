﻿using Model.PlayGame.Cell.Actors;
using Model.PlayGame.Levels;
using Model.PlayGame.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.Cell
{
    /// <summary>
	/// Base class for all cells in a <see cref="Level"/>.
	/// </summary>
    public abstract class Cell: LevelContentBase
    {
		private string _name;
		/// <summary>
		/// Gets or sets the name of this cell.
		/// The name can be used to identify the type
		/// of the cell without using GetType().
		/// </summary>
		/// <value>The name of the cell. 
		/// The conceptual type name of the cell, 
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

		private Location _location;
		/// <summary>
		/// Gets or sets the location on the <see cref="Level"/>.
		/// </summary>
		/// <value>The location of the cell on the <see cref="Level"/>.</value>
		public Location Location
		{
            get
            {
				return _location;
            }
		}
		private Level _level;
		/// <summary>
		/// Gets or sets the Level where this cell is located.
		/// </summary>
		/// <value>The Level where this cell is located.</value>
		public Level Level
		{
            get
            {
				return _level;
            }
			
		}

		/// <summary>
		/// Gets or sets the cell contents of this cell.
		/// </summary>
		/// <value>The cell contents, such as a <em>Treasure</em>,
		/// or an <em>Actors</em>.</value>
		public CellContents CellContents
		{
			get;
			private set;
		}

		/// <summary>
		/// Removes the contents of the cell.
		/// Sets the <see cref="CellContents"/> to null.
		/// </summary>
		public abstract void RemoveContents();

		/// <summary>
		/// Gets a value indicating whether cell contents can be put here.
		/// </summary>
		/// <value><c>true</c> if this instance will accept 
		/// an instance of <see cref="CellContents"/>; 
		/// otherwise, <c>false</c>.</value>
		public virtual bool CanEnter
		{
			get
			{
				return CellContents == null;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Cell"/> class.
		/// </summary>
		/// <param name="name">The name of the cell. <seealso cref="Name"/>.</param>
		/// <param name="location">The location of the cell. <seealso cref="Location"/></param>
		/// <param name="level">The Level where the cell is located. <seealso cref="Level"/></param>
		public Cell(string name, Location location, Level level)
		{
			_name = name;
			_location = location;
			_level = level;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Cell"/> class.
		/// </summary>
		/// <param name="name">The name of the cell. <seealso cref="Name"/>.</param>
		/// <param name="location">The location of the cell. <seealso cref="Location"/></param>
		/// <param name="level">The Level where the cell is located. <seealso cref="Level"/></param>
		/// <param name="contents">The contents of this cell. <seealso cref="CellContents"/>/param>
		public Cell(string name, Location location, Level level, CellContents contents)
			: this(name, location, level)
		{
			/* Add to this cell. */
			CellContents = contents;
			/* Make sure the content knows where it is. */
			contents.Cell = this;
		}

		/// <summary>
		/// Tries to the set the cell contents.
		/// </summary>
		/// <param name="contents">The contents to place in the cell.</param>
		/// <returns><code>true</code> if the specified contents
		/// was able to be placed in this cell; <code>false</code> otherwise.</returns>
		public abstract bool TrySetContents(CellContents contents);
		
		/// <summary>
		/// Tries to push the current <see cref="CellContents"/>
		/// to the cell neighbour in the specified direction.
		/// </summary>
		/// <param name="direction">The direction of an adjacent
		/// cell in which to place this cell's <see cref="CellContents"/>.</param>
		/// <returns><code>true</code> if the contents was able 
		/// to be placed in the adjacent cell; <code>false</code> otherwise.</returns>
		public bool TryPushContents(Direction direction)
		{
			if (!CanPush(direction))
			{
				return false;
			}
			Cell neighbour = Level[Location.GetAdjacentLocation(direction)];
			neighbour.TrySetContents(CellContents);
			return true;
		}

		/// <summary>
		/// Determines whether this instance can push the current
		/// <see cref="CellContents"/> in the specified direction.
		/// </summary>
		/// <param name="direction">The direction in which the cell contents
		/// should be tested for movability. That is, the direction
		/// of an adjacent cell that the cell contents might be placed.</param>
		/// <returns>
		/// 	<c>true</c> if this instance can push the cell contents to an adjacent
		/// cell in the specified direction; otherwise, <c>false</c>.
		/// </returns>
		public bool CanPush(Direction direction)
		{
			if (CellContents == null)
			{
				return false;
			}
			Cell neighbour = Level[Location.GetAdjacentLocation(direction)];
			return neighbour != null && neighbour.CanEnter;
		}

	}
}
