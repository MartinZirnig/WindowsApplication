using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsLowLevelStructs;

[StructLayout(LayoutKind.Sequential)]
public struct RawKeyboardData
{
    public ushort KeyCode;
    public ushort HardwareKeyCode;
    public uint Flags;
    public uint Time;
    public nint ExtraInfo;
}