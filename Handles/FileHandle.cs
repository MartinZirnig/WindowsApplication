using System.Runtime.InteropServices;

namespace Handles;

public class FileHandle : Handle
{
    public FileHandle(nint value) : base(value)
    {
    }

    protected override void Closing()
    {
        CloseHandle(Value);
    }

    public static FileHandle Open(
        string path,
        Access access = Access.All,
        ShareMode shareMode = ShareMode.None,
        nint security = 0,
        CreationDisposition creationDisposition = CreationDisposition.Open,
        FlagsAndAttributes flagsAndAttributes = FlagsAndAttributes.None,
        nint template = 0
        ) => new FileHandle(CreateFile(
            path,
            (uint)access,
            (uint)shareMode,
            security,
            (uint)creationDisposition,
            (uint)flagsAndAttributes,
            template
            ));



    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern nint CreateFile(
        string fileName,
        uint access,
        uint shareMode,
        nint security,
        uint creationDisposition,
        uint flagsAndAttributes,
        nint template
        );
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool CloseHandle(nint handle);



    [Flags]
    public enum Access : uint
    {
        Read = 0x80000000,
        Write = 0x40000000,
        Execute = 0x20000000,
        All = 0x10000000
    }
    [Flags]
    public enum ShareMode : uint
    {
        None = 0,
        Read = 1,
        Write = 2,
        Delete = 4
    }
    public enum CreationDisposition : uint
    {
        Create = 1,
        CreateAlways = 2,
        Open = 3,
        OpenAlways = 4,
        Truncate = 5
    }
    [Flags]
    public enum FlagsAndAttributes : uint
    {
        None = 0,
        Readonly = 0x1,
        Hidden = 0x2,
        System = 0x4,
        Directory = 0x10,
        Archive = 0x20,
        Device = 0x40,
        Normal = 0x80,
        Temporally = 0x100,
        SparseFile = 0x200,
        ReparsePoint = 0x400,
        Compressed = 0x800,
        Offline = 0x1000,
        NotContendIndexed = 0x2000,
        Encrypted = 0x4000
    }

}
