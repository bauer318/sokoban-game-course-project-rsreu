using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Help;
using ViewConsole.Menu;

namespace ViewConsole.Help
{
    /// <summary>
    /// The Help's view
    /// </summary>
    public class ViewHelpConsole : ViewHelpBase
    {
        /// <summary>
        /// The view menu
        /// </summary>
        private ViewMenuConsole _viewMenuConsole;
        /// <summary>
        /// Get or Set the view menu
        /// </summary>
        public ViewMenuConsole ViewMenuConsole
        {
            get
            {
                return _viewMenuConsole;
            }
            set
            {
                _viewMenuConsole = value;
            }
        }
        /// <summary>
        /// Print a message
        /// </summary>
        /// <param name="parMessage">The message to print</param>
        public override void PrintMessage(string parMessage)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(parMessage);
        }
        /// <summary>
        /// Print the help's text
        /// </summary>
        /// <param name="parTextHelpArray">The help's text</param>
        public void PrintHelpText(string[] parArrayHelpText)
        {
            Console.Clear();
            foreach(string elString in parArrayHelpText)
            {
                foreach(char elChar in elString)
                {
                    DrawUtils.SaveColors();
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (elChar.Equals('0'))
                    {
                        
                        DrawUtils.DrawWall();
                        
                    }
                    else if (elChar.Equals('#'))
                    {
                        DrawUtils.DrawTreasureOnFloor();
                    }
                    else if (elChar.Equals('.'))
                    {
                        DrawUtils.DrawEmptyGoal();
                    }
                    else if (elChar.Equals('@'))
                    {
                        DrawUtils.DrawActorOnFloor();
                    }
                    else
                    {
                        Console.Write(elChar);
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    DrawUtils.PutColorsBack();
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Back to main menu
        /// </summary>
        public void BackToMainMenu()
        {
            _viewMenuConsole.Draw();
        }
    }
}
