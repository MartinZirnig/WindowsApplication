using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WindowsLowLevelStructs;

namespace BasicInputs.Keyboard
{
    [StructLayout(LayoutKind.Explicit)]
    internal struct KeyboardInputUnion
    {
        [FieldOffset(0)]
        public RawKeyboardData Data;
    }
}
