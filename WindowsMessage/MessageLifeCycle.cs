using System.Runtime.InteropServices;
using WindowsLowLevelStructs;

namespace WindowsMessage;

internal class MessageLifeCycle : IDisposable
{
    private readonly nint _structurePointer;
    public WinApiMessage Message { get; private set; }

    private MessageLifeCycle(nint structurePointer)
    { 
        _structurePointer = structurePointer;
        RefreshStrucutre();
    }

    public static MessageLifeCycle Get()
    {
        GetMessage(out var result, nint.Zero, 0, 0);
        return new MessageLifeCycle(result);
    }
    public void Translate()
    {
        TranslateMessage(_structurePointer);
        RefreshStrucutre();
    }
    public void Dispose()
    {
        DispatchMessage(_structurePointer);
    }

    private void RefreshStrucutre()
    {
        var newStructure = Marshal.PtrToStructure<WinApiMessage>(_structurePointer);
        Message = newStructure;
    }



    [DllImport("user32.dll")]
    public static extern int GetMessage(
        out nint msgPtr,
        nint pointer,
        uint filterMin,
        uint filterMax
        );


    [DllImport("user32.dll")]
    public static extern bool TranslateMessage(nint msgPtr);


    [DllImport("user32.dll")]
    public static extern nint DispatchMessage(nint msgPtr);

}
