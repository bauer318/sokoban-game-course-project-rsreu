using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ViewWPF.PlayGame
{
    public class ButtonCellLocation : Button
    {
        private int _x;
        private int _y;

        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }
        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }
        public ButtonCellLocation(int parX, int parY)
        {
            _x = parX;
            _y = parY;
        }
    }
}
