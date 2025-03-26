using System.Runtime.InteropServices;
using WindowsLowLevelStructs;

namespace WindowsMessage;

internal class MessageLifeCycle : IDisposable
{
    public bool Valid { get; private set; }

    private readonly nint _structurePointer;
    public WinApiMessage? Message { get; private set; }

    public MessageLifeCycle()
    {
        var msgSize = Marshal.SizeOf(typeof(WinApiMessage));
        _structurePointer = Marshal.AllocHGlobal(msgSize);

        Valid = false;
        Message = null;
    }
    ~MessageLifeCycle() => Dispose();

    public void Get()
    {
        GetMessage(_structurePointer, nint.Zero, 0, 0);
        Valid = true;
        RefreshStructure();
    }

    public void Translate()
    {
        TranslateMessage(_structurePointer);
        RefreshStructure();
    }
    public void Dispose()
    {
        DispatchMessage(_structurePointer);
        Marshal.FreeHGlobal(_structurePointer);
        Valid = false;

        GC.SuppressFinalize(this); 
    }

    private void RefreshStructure()
    {
        var newStructure = Marshal.PtrToStructure<WinApiMessage>(_structurePointer);
        Message = newStructure;
    }



    [DllImport("user32.dll")]
    public static extern int GetMessage(
        nint msgPtr,
        nint pointer,
        uint filterMin,
        uint filterMax
        );


    [DllImport("user32.dll")]
    public static extern bool TranslateMessage(nint msgPtr);


    [DllImport("user32.dll")]
    public static extern nint DispatchMessage(nint msgPtr);
}
