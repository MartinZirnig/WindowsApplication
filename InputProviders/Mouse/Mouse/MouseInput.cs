using BasicInputs.DataObjects.Mouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsLowLevelStructs;

namespace BasicInputs.Mouse.Mouse;

internal struct MouseInput
{
    public int type;
    public RawMouseData data;
}