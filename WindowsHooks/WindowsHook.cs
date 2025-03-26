using Handles;

namespace WindowsHooks;

public class WindowsHook : IDisposable
{

    public Action<HookEventArguments>? HookProcedure;

    public bool Active { get; private set; }
    public bool Valid => Handle.IsValid;
    public WindowsHookType Type { get; internal set; }


    internal Handle Handle { get; set; }
    private bool _disposed;

    internal WindowsHook() 
    {
        Handle = Handle.Default;
    }

    internal void Activate()
    {
        Active = true;
        _disposed = false;
    }

    internal nint CatchEvent(int nCode, nint wParam, nint lParam)
    {
        if (nCode >= 0)
        {
            HookProcedure?.Invoke(new(nCode, wParam, lParam));
        }

        return WindowsHookManager.FinishHookEventHandling(Handle, nCode, wParam, lParam);
    }


    public void Close()
    {
        WindowsHookManager.CloseHook(Handle);
        Active = false;
    }
    public void Dispose()
    {
        if (_disposed) return;

        Close();
        _disposed = true;
    }
}

