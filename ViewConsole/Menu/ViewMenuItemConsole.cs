using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewConsole.Menu
{
    /// <summary>
    /// Representes the Menu item's view
    /// </summary>
    public class ViewMenuItemConsole:View.Menu.ViewMenuItem
    {
        /// <summary>
        /// The menu's item height
        /// </summary>
        public const int HEIGHT = 1;
        /// <summary>
        /// Get or Set the Console color by the menu state's dictionary
        /// </summary>
        public static Dictionary<Model.Menu.States, ConsoleColor> ColorByState { get; private set; }
        /// <summary>
        /// Default's contructor
        /// </summary>
        static ViewMenuItemConsole()
        {
            ColorByState = new Dictionary<Model.Menu.States, ConsoleColor>();
            ColorByState[Model.Menu.States.Focused] = ConsoleColor.Yellow;
            ColorByState[Model.Menu.States.Normal] = ConsoleColor.DarkRed;
            ColorByState[Model.Menu.States.Selected] = ConsoleColor.Yellow;
            
        }
        /// <summary>
        /// Initialize the menu item's view
        /// </summary>
        /// /// <param name="parItem">The menu's item</param>
        public ViewMenuItemConsole(Model.Menu.MenuItem parItem) : base(parItem)
        {
            Height = HEIGHT;
            Width = parItem.Name.Length;
        }
        /// <summary>
        /// Draw a menu's item
        /// </summary>
        public override void Draw()
        {
            Console.CursorLeft = X;
            Console.CursorTop = Y;
            ConsoleColor savColor = Console.ForegroundColor;
            Console.ForegroundColor = ColorByState[Item.State];
            Console.Write(Item.Name);
            Console.ForegroundColor = savColor;
        }
    }
}
