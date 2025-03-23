using System.Runtime.InteropServices;

namespace WindowsLowLevelStructs;

[StructLayout(LayoutKind.Sequential)]
public struct Point
    (int x, int y)
{
    public int 
        X = x, 
        Y = y;

    public Point() : this(0, 0) { }
}

