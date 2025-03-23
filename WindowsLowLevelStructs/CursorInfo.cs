using System.Runtime.InteropServices;

namespace WindowsLowLevelStructs;

[StructLayout(LayoutKind.Sequential)]
public struct CursorInfo()
{
    public int Size = Marshal.SizeOf<CursorInfo>();
    public int Flags;
    public nint Handle;
    public Point Position;

    public static CursorInfo Get()
    {
        var ci = new CursorInfo();
        GetCursorInfo(ref ci);
        return ci;
    }
    [DllImport("user32.dll")]
    static extern bool GetCursorInfo(ref CursorInfo pci);
}