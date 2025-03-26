using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace WindowsLowLevelStructs;
public class NativeExecutionException : Exception
{
    private const string DefaultMessage = "Exception with code {0} occurred in native code execution";
    public NativeExecutionException(string message)
        : base(message) { }

    public static int LastExecutionError =>
        Marshal.GetLastWin32Error();
    
    [DoesNotReturn] 
    public static void Throw()
    {
        var msg = string.Format(DefaultMessage, LastExecutionError);
        throw new NativeExecutionException(msg);
    }
    [DoesNotReturn]
    public static T Throw<T>()
    {
        var msg = string.Format(DefaultMessage, LastExecutionError);
        throw new NativeExecutionException(msg);
    }
}

