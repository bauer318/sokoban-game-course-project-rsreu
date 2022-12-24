using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ViewWPF.PlayGame
{
    public class ButtonCellLocation:Button
    {
        private int _x;
        private int _y;
        private string _id;
       
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
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public ButtonCellLocation(int parX, int parY)
        {
            _x = parX;
            _y = parY;
        }
        public ButtonCellLocation(int parX, int parY, string parId):this(parX,parY)
        {
            _id = parId;
            base.Name = "button"+parId;
        }
    }
}
