namespace Windows;

public abstract class Window
{
    private bool _isDisposed;   
    protected nint? Handle { get; private set; }
     
    
    public abstract void Show();
    public abstract void Hide();
    public abstract void Close();
    public abstract nint GetHandle();
    protected abstract void DisposeHandle();

    public abstract void AssignInputManager();
    public abstract void GetOutputManager();
    public abstract void CallOffInputManager();
    public abstract void CallOffOutputManager();
    
    public abstract void SetWindowTitle(string title); 
    public abstract void SetWindowIcon(string iconPth);
    
    public void Dispose()
    {
        if (_isDisposed) return;
        
        Close();
        DisposeHandle();
        Handle = null;
        Disposing();
        _isDisposed = true;
        
        GC.SuppressFinalize(this);
    }

    protected virtual void Disposing()
    {
        
    }
}