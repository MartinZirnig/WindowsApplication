using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFormater;

public struct RgbColor
{
    public byte R, G, B;

    public RgbColor
        (byte r = 0, byte g = 0, byte b = 0)
    {
        R = r;
        G = g;
        B = b;
    }
    public RgbColor(Color color) 
        : this(color.R, color.G, color.B) { }
}

