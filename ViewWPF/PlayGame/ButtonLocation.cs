using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ViewWPF.PlayGame
{
    /// <summary>
    /// Representes a button with location
    /// </summary>
    public class ButtonLocation:Button
    {
        /// <summary>
        /// The x coordinate
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// The y coordinate
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// Initializes the ButtonLocation
        /// </summary>
        /// <param name="parX">The x coordinate</param>
        /// <param name="parY">The y coordiante</param>
        public ButtonLocation(int parX, int parY) : base()
        {
            X = parX;
            Y = parY;
        }
        /// <summary>
        /// Get the ButtonLocation by location
        /// </summary>
        /// <param name="parX">The x coordinate</param>
        /// <param name="parY">The y coordiante</param>
        /// <param name="parListButton">The list of all game's level cell button</param>
        /// <returns></returns>
        public static ButtonLocation GetButtonLocationByCoord(int parX, int parY, List<ButtonLocation> parListButton)
        {
            return parListButton.Find(elButton => elButton.X == parX && elButton.Y == parY);
        }
    }
}
