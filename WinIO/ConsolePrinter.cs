using Handles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowOutput
{
    internal class ConsolePrinter : GeneralPrinter
    {
        private ConsoleHandle _handle;

        public ConsolePrinter(AttachedWindowData win)
            : base(win) 
        {
            _handle = ConsoleHandle.Open(win.Handle.GetProcessId());
        }

        protected override void Flushing(string value)
        {
            _handle.Write(value);
        }
    }
}
