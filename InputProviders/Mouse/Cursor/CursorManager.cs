using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WindowsHooks;
using WindowsLowLevelStructs;

namespace BasicInputs.Mouse.Cursor;

internal class CursorManager
{
    public bool Visible => GetCursorInfo().Flags == 1;

    public void SetCursorVisibility(bool visible)
    {
        ShowCursor(visible);
    }


    public CursorInfo GetCursorInfo()
    {
        return CursorInfo.Get();
    }
    public void SetCursorImage(CursorImage image)
    {
        SetCursor(image.Value);
    }



    [DllImport("user32.dll")]
    static extern nint SetCursor(nint cursor);
    [DllImport("user32.dll")]
    static extern int ShowCursor(bool Visible);
}