﻿using Model.PlayGame.Levels;
using Model.PlayGame.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PlayGame.Cells
{
	public class Treasure : CellContents
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Treasure"/> class.
		/// </summary>
		/// <param name="parLocation">The location where the treasure is.</param>
		/// <param name="parLevel">The level that the treasure is located.</param>
		public Treasure(Location parLocation, Level parLevel)
			: base("Treasure", parLocation, parLevel)
		{
		}
	}
}
