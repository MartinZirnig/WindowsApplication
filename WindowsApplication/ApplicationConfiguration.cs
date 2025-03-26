namespace WindowsApplication.Configuration;

public class ApplicationConfiguration
{
    internal bool InitializeApplicationInput {  get; set; } 
    internal bool CatchMouse { get; set; }
    internal bool CatchKeyboard { get; set; }
    
    internal bool CloseStandardConsole { get; set; }
}