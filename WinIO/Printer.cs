using Windows;
using System.Text;

namespace WindowOutput;

internal abstract class Printer
    (AttachedWindowData window)
    : IDisposable
{
    private bool _disposed;
    private StringBuilder _buffer = new StringBuilder();
    protected AttachedWindowData Window = window;

    public void Append(char Content) => _buffer.Append(Content);

    protected abstract void Flushing(string value);
    public void Flush()
    {
        var content = _buffer.ToString();
        _buffer = new StringBuilder();

        Flushing(content);
    }

    public virtual void CLose()
    {
        
    }

    public bool TestWindow(AttachedWindowData window)
    {
        return Window == window;
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            CLose();

            _buffer = null!;
            Window = null!;

            _disposed = true;
        }
    }
}
