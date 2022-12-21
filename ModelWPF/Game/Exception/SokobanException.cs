﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWPF.Game.Exception
{
    public class SokobanException: ApplicationException
    {
		public SokobanException()
		{
		}

		public SokobanException(string message)
			: base(message)
		{
		}
	}
}