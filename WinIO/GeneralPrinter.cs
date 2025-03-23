using System.Text;

namespace WindowOutput;

internal abstract class GeneralPrinter
    (AttachedWindowData win)
{
    private StringBuilder _buffer = new StringBuilder();
    protected AttachedWindowData window = win;

    protected void ClearBuffer() => _buffer.Clear();
    protected string GetBufferContent() => _buffer.ToString();
    public void Append(string Content) => _buffer.Append(Content);

    public abstract void Print();
}
