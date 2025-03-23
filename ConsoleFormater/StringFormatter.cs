using System.Text;

namespace ConsoleFormater;

public class StringFormatter
{
    private StringBuilder _content = new();

    public void Append(string value) => _content.Append(value);
    public void Append(char value) => _content.Append(value);
    public void Append(FormattableString value) => _content.Append(value);
    public void Append(ConsoleFormat value) => _content.Append(value.ToString());

    public override string ToString() => _content.ToString();
}

