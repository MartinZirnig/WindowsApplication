namespace ConsoleFormater;

public class ConsoleFormat
{
    public static ConsoleFormat SetForeground(RgbColor color) =>
        new(AdvancedFormatsProvider.SetForegroundColor(color));
    public static ConsoleFormat SetBackground(RgbColor color) =>
        new(AdvancedFormatsProvider.SetBackgroundColor(color));
    public static ConsoleFormat SetBooth(RgbColor color) =>
        new(AdvancedFormatsProvider.SetForegraundAndBackground(color));

    public static ConsoleFormat SetCursorPosition(int x, int y) =>
        new(AdvancedFormatsProvider.SetCursorPosition(x, y));

    public static ConsoleFormat StartFlushing => new(ConstantsManager.Flushing);
    public static ConsoleFormat StopFlushing => new(ConstantsManager.StopFlushing);
    public static ConsoleFormat StartBold => new(ConstantsManager.Bold);
    public static ConsoleFormat StopBold => new(ConstantsManager.StopBold);
    public static ConsoleFormat StartItalic => new(ConstantsManager.Italic);
    public static ConsoleFormat StopItalic => new(ConstantsManager.StopItalic);
    public static ConsoleFormat StartUnderline => new(ConstantsManager.Underline);
    public static ConsoleFormat StopUnderline => new(ConstantsManager.StopUnderline);


    private readonly string _code;

    private ConsoleFormat(string code) => _code = code;
    public override string ToString() => _code;

    public static ConsoleFormat operator +(ConsoleFormat left, ConsoleFormat right) =>
        new ConsoleFormat(left._code + right._code);
}
