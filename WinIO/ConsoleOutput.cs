using Windows;

namespace WindowOutput;

internal class ConsoleOutput : Output
{
    private List<ConsolePrinter> _printers;

    public ConsoleOutput()
    {
        _printers = new();
    }

    protected override void AttachingWindow(AttachedWindowData data)
    {
        _printers.Add(new ConsolePrinter(data));
    }
    protected override void DetachedWindow(AttachedWindowData data)
    {
        var printer = _printers
            .FirstOrDefault(p => p.TestWindow(data));
        
        if (printer is not null)
            _printers.Remove(printer); 
    }
}

