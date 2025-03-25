using System.Runtime.InteropServices;
using Access = Handles.FileHandle.Access;
using ShareMode = Handles.FileHandle.ShareMode;
using CreationDisposition = Handles.FileHandle.CreationDisposition;
using FlagsAndAttributes = Handles.FileHandle.FlagsAndAttributes;
using System.Text;

namespace Handles;
public class ConsoleHandle : ManagedHandle
{
    private const string ConsoleInCode = @"\\.\CONIN$";
    private const string ConsoleOutCode = @"\\.\CONOUT$";
    private const string ConsoleErrorCode = @"\\.\CONERR$";

    private const uint ProcessQueryRequest = 0x0400;

    private const byte NullTerminator = 0;
    private const byte LineFeed = 10;
    private const byte CarriageReturn = 13;

    private readonly FileHandle _consoleIn;
    private readonly FileHandle _consoleOut;
    private readonly FileHandle _consoleError;

    public nint In => _consoleIn.Value;
    public nint Out => _consoleOut.Value;
    public nint Error => _consoleError.Value;

    public ConsoleHandle(
        nint value,
        FileHandle consoleIn,
        FileHandle consoleOut,
        FileHandle consoleError
        ) : base(value)
    {
        _consoleIn = consoleIn;
        _consoleOut = consoleOut;
        _consoleError = consoleError;
    }


    public static ConsoleHandle Open(uint processId)
    {
        var process = OpenProcess(
            ProcessQueryRequest,
            false,
            processId
            );
        return Open(processId, process);
    }

    public static ConsoleHandle Open(
        uint processId, nint processHandle)
    {
        AttachConsole(processId);

        var consoleIn = OpenIn();
        var consoleOut = OpenOut();
        var consoleError = OpenError();

        FreeConsole();

        return new ConsoleHandle(
            processHandle,
            consoleIn,
            consoleOut,
            consoleError
            );
    }

    private static FileHandle OpenIn() =>
        FileHandle.Open(
            ConsoleInCode,
            Access.Read,
            ShareMode.None,
            nint.Zero,
            CreationDisposition.Open,
            FlagsAndAttributes.None,
            nint.Zero
            );

    private static FileHandle OpenOut() =>
        FileHandle.Open(
            ConsoleOutCode,
            Access.Write,
            ShareMode.None,
            nint.Zero,
            CreationDisposition.Open,
            FlagsAndAttributes.None,
            nint.Zero
            );

    private static FileHandle OpenError() =>
        FileHandle.Open(
            ConsoleErrorCode,
            Access.Write,
            ShareMode.None,
            nint.Zero,
            CreationDisposition.Open,
            FlagsAndAttributes.None,
            nint.Zero
        );


    public void Write(string content) =>
        WriteConsoleW(
            _consoleOut.Value,
            content,
            (uint)content.Length,
            out _,
            nint.Zero
            );

    public void WriteError(string content) =>
        WriteFile(
            _consoleError.Value,
            content,
            (uint)content.Length,
            out _,
            nint.Zero
            );


    public string ReadLine()
    {
        var bytes = ReadWhileNotReached(LineFeed);

        if (bytes[^1] == CarriageReturn)
            bytes.RemoveAt(bytes.Count - 1);

        return Encoding.UTF8.GetString(bytes.ToArray());
    }
    public string ReadAll()
    {
        var bytes = ReadWhileNotReached(NullTerminator);

        return Encoding.UTF8.GetString(bytes.ToArray());
    }

    private List<byte> ReadWhileNotReached(byte block)
    {
        var bytes = new List<byte>();
        var buffer = new byte[1];
        do
        {
            ReadFile(
                _consoleIn.Value,
                buffer,
                (uint)buffer.Length,
                out _,
                nint.Zero
                );

            bytes.Add(buffer[0]);
        }
        while (block != buffer[0]);

        return bytes;
    }


    protected override void Closing()
    {
        _consoleIn.Close();
        _consoleOut.Close();
        _consoleError.Close();

        base.Closing();
    }




    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    private static extern bool WriteFile(
        nint file,
        string buffer,
        uint charsCount,
        out uint charsWritten,
        nint overlap);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    private static extern bool ReadFile(
        nint file,
        byte[] buffer,
        uint bytesCount,
        out uint bytesRead,
        nint overlap);
    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    private static extern bool WriteConsoleW(
    nint consoleOutHandle,
    string buffer,
    uint charCount,
    out uint printedCharsCount,
    nint reserved
    );

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool AttachConsole(uint dwProcessId);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool FreeConsole();
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern nint OpenProcess(
        uint access,
        bool inherit,
        uint processId
        );
}
