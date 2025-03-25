using System.Runtime.InteropServices;

namespace Handles;
public class WindowHandle : Handle
{
    public WindowHandle(nint value) : base(value)
    {

    }

    public uint GetProcessId()
    {
        GetWindowThreadProcessId(Value, out var result);

        return result;
    }
    public uint GetProcessThread()
    {
        return GetWindowThreadProcessId(Value, out _);
    }


    [DllImport("user32.dll", SetLastError = true)]
    private static extern uint GetWindowThreadProcessId(nint handle, out uint processId);
}

