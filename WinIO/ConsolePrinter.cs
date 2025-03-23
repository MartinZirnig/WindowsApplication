using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowOutput
{
    internal class ConsolePrinter : GeneralPrinter
    {
        public ConsolePrinter(AttachedWindowData win) 
            : base(win) { }

        public override void Print()
        {
            throw new NotImplementedException();
        }

        
    }
}
