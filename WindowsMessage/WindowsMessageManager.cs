using WindowsLowLevelStructs;

namespace WindowsMessage;

public class WindowsMessageManager
{
    public readonly CancellationTokenSource CancelationTokeSource;

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
        CancelationTokeSource = new CancellationTokenSource();
    }

    public void Run()
    {
        Task.Run(MessageLoop);
    }

    public void MessageLoop()
    {
        while (!CancelationTokeSource.IsCancellationRequested)
        {
            try
            {
                using (var msg = MessageLifeCycle.Get())
                {
                    OnRawMessage?.Invoke(msg.Message);

                    msg.Translate();
                    OnMessage?.Invoke(msg.Message);
                }
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex);
            }
        }   
    }
}
