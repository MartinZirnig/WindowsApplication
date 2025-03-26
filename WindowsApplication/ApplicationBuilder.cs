namespace WindowsApplication;

internal class ApplicationBuilder
{




    public TApp Build<TApp>(params object?[]? buildParameters)
        where TApp : GeneralApplication
    {
        var result = (TApp)Activator.CreateInstance(typeof(TApp), buildParameters)!;
        return result;
    }
}

