using WindowOutput;
using Windows;
using WindowsHooks;

namespace WindowsApplication;

public abstract class Application
{
    private List<Window> _managedWindows;
    private WindowsMessageManager _msgManager;

    protected internal Application()
    {
        _managedWindows = new List<Window>();

    }

    protected internal abstract void Initialize();

    public TOutput CreteOutput<TOutput>()
        where TOutput : Output, new() =>
        new TOutput();

    public void CreateWindow<TWindow>()
        where TWindow : Window, new()
    {
        var window = new TWindow();
        _managedWindows.Add(window);
    }


    public void Run()
    {

    }



    internal static TApp Build<TApp>(params object[] buildParameters)
        where TApp : Application, new(ApplicationTag)
    {
        return (TApp)Activator
            .CreateInstance(typeof(TApp), buildParameters)!;
    }
}