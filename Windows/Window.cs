using Handles;

namespace Windows;

public abstract class Window
{
    private bool _isDisposed;   
    public WindowHandle Handle { get; private set; }
    private WindowVisibilityManager _visibilityManager;
    
    public virtual void Show() => _visibilityManager.Show();
    public virtual void Hide() => _visibilityManager.Hide();

    public abstract void Close();
    public abstract void Open();

    public abstract AttachedWindowData GetWindowData();    

    
    public abstract void SetWindowTitle(string title); 
    public abstract void SetWindowIcon(string iconPath);

    
    public void Dispose()
    {
        if (_isDisposed) return;
        
        Close();

        Handle.Close();
        Disposing();
        _isDisposed = true;
        
        GC.SuppressFinalize(this);
    }

    protected virtual void Disposing()
    {
        
    }
}