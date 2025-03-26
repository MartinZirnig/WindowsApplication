using Handles;

namespace Windows;
public class AttachedWindowData
    (WindowHandle handle, WindowType windowType)
{
    public readonly WindowHandle Handle = handle;
    public readonly WindowType WindowType = windowType;
}
