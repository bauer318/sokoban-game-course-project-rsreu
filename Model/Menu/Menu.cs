using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Menu
{
    public class Menu : SubMenuItem
    {
        public delegate void dNeedRedraw();

        public event dNeedRedraw NeedRedraw = null;

        private int _focusedItemIndex = -1;
        public int FocusedItemIndex
        {
            get { return _focusedItemIndex; }
            protected set { _focusedItemIndex = value; }
        }
        public Menu(string parName) : base(0, parName)
        {

        }

        public void FocusNext()
        {
            int savFocusedIndex = _focusedItemIndex;
            if (_focusedItemIndex == Items.Length - 1)
                _focusedItemIndex = 0;
            else
                _focusedItemIndex++;

            Items[_focusedItemIndex].State = States.Focused;
            Items[savFocusedIndex].State = States.Normal;

            NeedRedraw?.Invoke();
        }
        public void FocusPrevious()
        {
            int savFocusedIndex = _focusedItemIndex;
            if (_focusedItemIndex == 0)
                _focusedItemIndex = Items.Length - 1;
            else
                _focusedItemIndex--;

            Items[_focusedItemIndex].State = States.Focused;
            Items[savFocusedIndex].State = States.Normal;

            NeedRedraw?.Invoke();
        }
        public void FocusItemById(int parId)
        {
            int savFocusedIndex = _focusedItemIndex;
            MenuItem menuItem = this[parId];
            _focusedItemIndex = new List<MenuItem>(Items).IndexOf(menuItem);

            if (savFocusedIndex != -1)
                Items[savFocusedIndex].State = States.Normal;
            Items[_focusedItemIndex].State = States.Focused;
            NeedRedraw?.Invoke();
        }
        public void SelectFocusedItem()
        {
            Items[_focusedItemIndex].State = States.Selected;
        }

    }
}
