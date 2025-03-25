using System.Text;

namespace WindowOutput;

internal abstract class GeneralPrinter
    (AttachedWindowData window)
{
    private StringBuilder _buffer = new StringBuilder();
    protected AttachedWindowData window = window;

    public void Append(string Content) => _buffer.Append(Content);

    protected abstract void Flushing(string value);
    public void Flush()
    {
        var content = _buffer.ToString();
        _buffer = new StringBuilder();

        Flushing(content);
    }
}
