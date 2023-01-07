using Model.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace ViewWPF.MenuGraphics
{
    /// <summary>
    /// Representes the Menu item's view
    /// </summary>
    public class ViewMenuItemWPF : View.Menu.ViewMenuItem, IMenu
    {
        /// <summary>
        /// delegate for the methode Enter
        /// </summary>
        /// <param name="parId">item's ID</param>
        public delegate void dEnter(int parId);
        /// <summary>
        /// Occurs when the menu item is selected and was clicked
        /// </summary>
        public event dEnter Enter = null;
        /// <summary>
        /// Representes the parent's control
        /// </summary>
        private FrameworkElement _parentControl = null;
        /// <summary>
        /// Button as menu's item control
        /// </summary>
        private readonly Button _button = null;
        /// <summary>
        /// To brush the menu item's button
        /// </summary>
        private readonly Brush _brush = null;
        /// <summary>
        /// Initialize the menu item's view
        /// </summary>
        /// <param name="parItem">The menu's item</param>
        public ViewMenuItemWPF(Model.Menu.MenuItem parItem) : base(parItem)
        {
            _button = new Button
            {
                Content = parItem.Name
            };
            _button.Click += (s, e) => { Enter?.Invoke(this.Item.ID); };
            Height = (int)_button.Height;
            Width = (int)_button.Width;
            parItem.Selected += ParItem_Selected;
        }
        /// <summary>
        /// Occurs when the menu's item was selected
        /// </summary>
        private void ParItem_Selected()
        {
            _button.Focus();
            Draw();
        }
        /// <summary>
        /// Draw a menu's item
        /// </summary>
        public override void Draw()
        {
            _button.Margin = new Thickness(X, Y, 0, 0);
            if (this.Item.State == States.Focused || this.Item.State == States.Selected)
                _button.Background = Brushes.Magenta;
            else
                _button.Background = _brush;
        }
        /// <summary>
        /// Set the menu item's parent control
        /// </summary>
        /// <param name="parControl">The menu item's parent control</param>
        public void SetParentControl(FrameworkElement parControl)
        {
           
            if (_parentControl == null)
            {
                _parentControl = parControl;
                ((IAddChild)_parentControl).AddChild(_button);
            }
        }
    }
}
