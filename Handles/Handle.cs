namespace Handles;
public class Handle(nint value)
{
    public nint Value { get; private set; }
        = value;
    public bool IsValid => Value != nint.Zero;

    protected virtual void Closing() { }

    public void Close()
    {
        Closing();
        Value = nint.Zero;
    }


}
