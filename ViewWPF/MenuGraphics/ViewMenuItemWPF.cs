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
    public class ViewMenuItemWPF : View.Menu.ViewMenuItem, IMenu
    {
        public delegate void dEnter(int parId);
        public event dEnter Enter = null;
        private FrameworkElement _parentControl = null;
        Button _button = null;
        Brush _brush = null;
        public ViewMenuItemWPF(Model.Menu.MenuItem parItem) : base(parItem)
        {
            _button = new Button();
            _button.Content = parItem.Name;
            _button.Click += (s, e) => { Enter?.Invoke(this.Item.ID); };
            Height = (int)_button.Height;
            Width = (int)_button.Width;
            parItem.Selected += ParItem_Selected;
        }

        private void ParItem_Selected()
        {
            _button.Focus();
            Draw();
        }
        public override void Draw()
        {
            _button.Margin = new Thickness(X, Y, 0, 0);
            if (this.Item.State == States.Focused || this.Item.State == States.Selected)
                _button.Background = Brushes.Magenta;
            else
                _button.Background = _brush;
        }

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
