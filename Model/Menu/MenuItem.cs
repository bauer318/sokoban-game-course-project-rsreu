using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Menu
{
    public class MenuItem
    {
        public delegate void dSelected();
        public event dSelected Selected = null;
        private States _state = States.Normal;
        public string Name { get; private set; }
        public States State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                if (_state == States.Selected)
                    Selected?.Invoke();
            }
        }
        public int ID { get; private set; }
        public MenuItem(int parId, string parName)
        {
            ID = parId;
            State = States.Normal;
            Name = parName;
        }
    }
}
