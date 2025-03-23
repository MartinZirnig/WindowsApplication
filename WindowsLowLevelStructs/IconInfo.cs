using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsLowLevelStructs;

[StructLayout(LayoutKind.Sequential)]
public struct IconInfo
{
    public bool IsIcon;
    public int xHotspot;
    public int yHotspot;
    public nint Mask;
    public nint Color;
}