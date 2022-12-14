using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Menu
{
    public class MenuMain:Menu
    {
        public MenuMain() : base(Properties.Resources.MainMenuName)
        {
            AddItem(new MenuItem((int)MenuItemCodes.Help, Properties.Resources.HelpMenuName));
            AddItem(new MenuItem((int)MenuItemCodes.Map, Properties.Resources.MapMenuName));
            AddItem(new MenuItem((int)MenuItemCodes.New, Properties.Resources.NewGameMenuName) { State = States.Focused });
            AddItem(new MenuItem((int)MenuItemCodes.Record, Properties.Resources.RecordMenuName));
            AddItem(new MenuItem((int)MenuItemCodes.Exit, Properties.Resources.ExiteMenuName));

            this.FocusItemById((int)MenuItemCodes.New);
        }
    }
}
