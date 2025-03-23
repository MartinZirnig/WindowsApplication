using WindowsHooks;

namespace BasicInputs;

public class UserInputManager : IDisposable
{

    public bool MouseHookIncluded => _mouseHook is not null;
    public bool KeyboardHookIncluded => _keyboardHook is not null;

    private bool _disposed;
    private WindowsHook? _mouseHook;
    private WindowsHook? _keyboardHook;
    private WindowsMessageManager _manager;



    public UserInputManager
        (bool includeMouseHook, bool includeKeyboardHook)
    {
        _manager = WindowsMessageManager.Instance;

        if (includeMouseHook)
        {
            _mouseHook = WindowsHookManager.OpenHook(WindowsHookType.Mouse);
            _mouseHook.HookProcedure = MouseHookProcedure;
        }
        if (includeKeyboardHook)
        {
            _keyboardHook = WindowsHookManager.OpenHook(WindowsHookType.Keyboard);
            _keyboardHook.HookProcedure = KeyboardHookProcedure;
        }
    }
    ~UserInputManager() => Dispose();











    private void MouseHookProcedure(HookEventArguments args)
    {

    }
    private void KeyboardHookProcedure(HookEventArguments args)
    {
    }


    public void Dispose()
    {
        if (_disposed) return;

        _mouseHook?.Dispose();
        _mouseHook = null;
        _keyboardHook?.Dispose();
        _keyboardHook = null;
        _manager.Dispose();
        _manager = null!;
        _disposed = true;

        GC.SuppressFinalize(this);
    }
}