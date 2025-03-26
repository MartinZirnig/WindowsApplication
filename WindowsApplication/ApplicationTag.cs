namespace WindowsApplication;

public class ApplicationTag
{
    private readonly Dictionary<string, object> _tags;

    public ApplicationTag()
    {
        _tags = new Dictionary<string, object>();
    }

    internal void AddTag(string key, object value)
    {
        _tags.Add(key, value);
    }

    public object this[string key]
    {
        get => _tags[key];
    }
}