using System.Runtime.InteropServices;

namespace WindowsLowLevelStructs;

[StructLayout(LayoutKind.Sequential)]
public struct RawMouseData
{
    public Point Position;
    public uint MouseData, Flags, Time;
    public nint ExtraInfo;
}

