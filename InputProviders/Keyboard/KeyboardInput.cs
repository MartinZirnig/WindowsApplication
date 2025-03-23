using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BasicInputs.Keyboard
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct KeyboardInput
    {
        public int type;
        public KeyboardInputUnion data;
    }
}
