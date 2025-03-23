using System.Runtime.InteropServices;

namespace WindowsLowLevelStructs;

[StructLayout(LayoutKind.Sequential)]
public struct Coord(short x, short y)
{
    public short
        X = x,
        y = y;

    public Coord() : this(0, 0) { }
}