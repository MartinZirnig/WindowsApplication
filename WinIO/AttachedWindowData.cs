using Handles;
using System.Runtime.InteropServices;

namespace WindowOutput;
public class AttachedWindowData
    (WindowHandle handle, WindowType windowType)
{
    public readonly WindowHandle Handle = handle;
    public readonly WindowType WindowType = windowType;
}
