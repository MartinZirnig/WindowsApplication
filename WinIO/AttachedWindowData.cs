using System.Runtime.InteropServices;

namespace WinIO;
public readonly struct AttachedWindowData
    (nint handle, WindowType windowType)
: IDisposable
{
    public readonly nint Handle = handle;
    public readonly WindowType WindowType = windowType;

#pragma warning disable CA1416
    public void Dispose() => Marshal.ReleaseComObject(this);
#pragma warning restore
}
