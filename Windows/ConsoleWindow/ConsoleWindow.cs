using Handles;

namespace Windows.ConsoleWindow;

public class ConsoleWindow : Window
{
    private ConsoleHandleManagers _handles;
    public ConsoleWindow(WindowHandle windowHandle)
    {
        _handles = new ConsoleHandleManagers(windowHandle);
    }


    public override void Show()
    {
        throw new NotImplementedException();
    }

    public override void Hide()
    {
        throw new NotImplementedException();
    }

    public override void Close()
    {
        throw new NotImplementedException();
    }

    public override void SetWindowTitle(string title)
    {
        throw new NotImplementedException();
    }

    public override void SetWindowIcon(string iconPath)
    {
        throw new NotImplementedException();
    }

    public override void Open()
    {
        throw new NotImplementedException();
    }
}