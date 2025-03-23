using System.Runtime.InteropServices;

namespace WindowsLowLevelStructs;

[StructLayout(LayoutKind.Sequential)]
public struct Rectangle
    (int left, int top, int right, int bottom)
{
    public int 
        Left = left, 
        Top = top, 
        Right = right, 
        Bottom = bottom;
    public Rectangle() : this(0, 0, 0, 0) { }
}

