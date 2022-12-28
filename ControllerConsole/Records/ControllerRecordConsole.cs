using Controller.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Record;
using ViewConsole.Record;

namespace ControllerConsole.Records
{
    public class ControllerRecordConsole:ControllerRecordBase
    {
        private ViewRecordConsole _viewRecordConsole;
        public ControllerRecordConsole(ViewRecordBase parViewRecordBase) : base(parViewRecordBase)
        {
            _viewRecordConsole = parViewRecordBase as ViewRecordConsole;
            Console.WriteLine("Here for Record");
        }
    }
}
