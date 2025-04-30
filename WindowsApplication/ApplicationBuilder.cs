namespace WindowsApplication;

public class ApplicationBuilder
{
    public TApp Build<TApp>(params object?[]? buildParameters)
        where TApp : Application
    {
        return Application.Build<TApp>(buildParameters);
    }
}

