using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WindowsLowLevelStructs;

[StructLayout(LayoutKind.Sequential)]
public struct WinApiMessage
{
    public nint Destination;
    public uint Message;
    public nint WParam;
    public nint LParam;
    public uint Time;
    public Point Position;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly Point GetPointFromMouseEvent()
    {
        return Marshal.PtrToStructure<Point>(LParam);
    }
}

