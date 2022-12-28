using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Menu
{
    /// <summary>
    /// Represent an application's menu
    /// </summary>
    public class Menu : SubMenuItem
    {
        /// <summary>
        /// delegate for the NeedRedraw method
        /// </summary>
        public delegate void dNeedRedraw();
        /// <summary>
        /// Occurs when need to redraw a menu
        /// </summary>
        public event dNeedRedraw NeedRedraw = null;
        /// <summary>
        /// The menu item index focused
        /// </summary>
        private int _focusedItemIndex = -1;
        /// <summary>
        /// Get or Set the menu item index focused
        /// </summary>
        public int FocusedItemIndex
        {
            get { return _focusedItemIndex; }
            protected set { _focusedItemIndex = value; }
        }
        /// <summary>
        /// Initialize a Menu
        /// </summary>
        /// <param name="parName">Menu's name</param>
        public Menu(string parName) : base(0, parName)
        {

        }
        /// <summary>
        /// Focus the next menu
        /// </summary>
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
        /// <summary>
        /// Focus the preview menu
        /// </summary>
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
        /// <summary>
        /// Focus the menu by id
        /// </summary>
        /// <param name="parId">The menu's id</param>
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
        /// <summary>
        /// Selectes the menu item focused
        /// </summary>
        public void SelectFocusedItem()
        {
            Items[_focusedItemIndex].State = States.Selected;
        }

    }
}
