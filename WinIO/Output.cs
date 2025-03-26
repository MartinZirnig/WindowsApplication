using Windows;

namespace WindowOutput;

public abstract class Output
{
    protected abstract void AttachingWindow(AttachedWindowData data);
    protected abstract void DetachedWindow(AttachedWindowData data);

    public void AttachWindow(Window window)
    {
        AttachingWindow(window.GetWindowData());
    }
    public void DetachWindow(Window window)
    {
        DetachedWindow(window.GetWindowData());
    }
}