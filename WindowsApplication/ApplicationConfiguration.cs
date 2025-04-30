using Microsoft.Win32.SafeHandles;

namespace WindowsApplication.Configuration;

public class ApplicationConfiguration
{
    public bool InitializeApplicationInput {  get; set; }
    public bool CatchMouse { get; set; }
    public bool CatchKeyboard { get; set; }

    public bool CloseStandardConsole { get; set; }
}