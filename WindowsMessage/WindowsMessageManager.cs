using System.Diagnostics;
using WindowsHooks;
using WindowsLowLevelStructs;

namespace WindowsMessage;

public class WindowsMessageManager : IDisposable
{
    private readonly CancellationTokenSource _cancelationTokeSource;
    private List<WindowsHook> _hooks;

    public static WindowsMessageManager Instance
    {
        get
        {
            if (_instance is null)
                _instance = new WindowsMessageManager();
            return _instance;
        }
    }
    private static WindowsMessageManager? _instance;




    public Action<WinApiMessage>? OnMessage { get; set; }
    public Action<WinApiMessage>? OnRawMessage { get; set; }
    public Action<Exception>? OnError { get; set; } 
    
    private WindowsMessageManager()
    {
        _cancelationTokeSource = new CancellationTokenSource();
        _hooks = new List<WindowsHook>();
    }
    ~WindowsMessageManager()
    {
        Dispose();
    }

    public void Run()
    {
        Task.Run(MessageLoop);
    }

    public void MessageLoop()
    {
        while (!_cancelationTokeSource.IsCancellationRequested)
        {
            try
            {
                using (var msg = new MessageLifeCycle())
                {
                    msg.Get();
                    OnRawMessage?.Invoke(msg.Message ??
                        NativeExecutionException.Throw<WinApiMessage>());

                    msg.Translate();
                    OnMessage?.Invoke(msg.Message ??
                        NativeExecutionException.Throw<WinApiMessage>());
                }
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex);
            }
        }
    }

    public void RegisterHook(WindowsHook hook) =>
        _hooks.Add(hook);
    public void AbandonHook(WindowsHook hook) =>
        _hooks.Remove(hook);

    public void Close()
    {
        _cancelationTokeSource.Cancel();
        _hooks = null!;
    }

    public void Dispose()
    {
        Close();
        GC.SuppressFinalize(this);
    }
}
