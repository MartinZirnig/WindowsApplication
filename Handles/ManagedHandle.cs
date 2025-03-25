using System.Runtime.InteropServices;

namespace Handles;
public class ManagedHandle : Handle, IDisposable
{
    private bool _disposed;

    public ManagedHandle(nint value)
        : base(value) =>
        _disposed = false;
    ~ManagedHandle() => Dispose();

    protected override void Closing()
    {
        CloseHandle(Value);
    }
    public void Dispose()
    {
        if (!_disposed)
        {
            Close();
            _disposed = true;
            GC.SuppressFinalize(this);
        }
    }

    [DllImport("kernel32.dll")]
    public static extern bool CloseHandle(nint handle);
}

