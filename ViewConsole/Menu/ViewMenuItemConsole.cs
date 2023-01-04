using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewConsole.Menu
{
    public class ViewMenuItemConsole:View.Menu.ViewMenuItem
    {
        public const int HEIGHT = 1;

        protected static Dictionary<Model.Menu.States, ConsoleColor> ColorByState { get; private set; }
        static ViewMenuItemConsole()
        {
            ColorByState = new Dictionary<Model.Menu.States, ConsoleColor>();
            ColorByState[Model.Menu.States.Focused] = ConsoleColor.Yellow;
            ColorByState[Model.Menu.States.Normal] = ConsoleColor.DarkCyan;
            ColorByState[Model.Menu.States.Selected] = ConsoleColor.Yellow;
            
        }
        public ViewMenuItemConsole(Model.Menu.MenuItem parItem) : base(parItem)
        {
            Height = HEIGHT;
            Width = parItem.Name.Length;
        }
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
