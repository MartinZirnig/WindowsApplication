using Handles;
using Windows;

namespace WindowOutput;
internal class ConsolePrinter : Printer
{
    private ConsoleHandle _handle;

    public ConsolePrinter(AttachedWindowData win)
        : base(win)
    {
        _handle = ConsoleHandle.Open(win.Handle.GetProcessId());
    }

    protected override void Flushing(string value)
    {
        _handle.Write(value);
    }

    public override void CLose()
    {
        _handle.Close();
        _handle = null;
    }
}