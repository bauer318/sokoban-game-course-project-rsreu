﻿using Model.PlayGame.NewGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.PlayGame
{
    public abstract class ViewNewGameBase
    {
        public bool FirstStartLevel = true;
        public abstract void PrintExceptionMessage(string parMessage);
    }
}
