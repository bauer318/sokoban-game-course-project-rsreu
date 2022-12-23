﻿//using Model.PlayGame.Locations;
using ModelWPF.Game.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWPF.Game.Cells
{
    public class SpaceCellWPF : CellWPF
    {
        /// <summary>
        /// Represents a cell containing nothing. 
        /// This is not a cell that is used to place <see cref="CellContents"/>.
        /// </summary>
        public SpaceCellWPF(Location location, LevelWPF level)
            : base("Space", location, level)
        {
        }
    }
}
