using StdExtensions;

namespace ConsoleFormater;

internal static class AdvancedFormatsProvider
{
    public static string SetForegroundColor(RgbColor color)
    {
        var code = ConstantsManager.SetForegroundColor;
        using (var editor = new StringEditor(code))
        {
            EditConsoleCode(editor, color);
        }
        return code;
    }
    public static string SetBackgroundColor(RgbColor color)
    {
        var code = ConstantsManager.SetBackgroundColor;
        using (var editor = new StringEditor(code))
        {
            EditConsoleCode(editor, color);
        }
        return code;
    }
    public static string SetForegraundAndBackground(RgbColor color)
    {
        var code = SetForegroundColor(color);
        code += SetBackgroundColor(color);
        return code;
    }   

    private static void EditConsoleCode(StringEditor value, RgbColor color)
    {
        UpdateValueInCode(value, color.R.ToString(), ConstantsManager.ChangeColorPositionR, ConstantsManager.ColorBufferSize);
        UpdateValueInCode(value, color.G.ToString(), ConstantsManager.ChangeColorPositionG, ConstantsManager.ColorBufferSize);
        UpdateValueInCode(value, color.B.ToString(), ConstantsManager.ChangeColorPositionB, ConstantsManager.ColorBufferSize);
    }


    public static string SetCursorPosition(int x, int y)
    {
        x = x % ConstantsManager.MaxSetCursor;
        y = y % ConstantsManager.MaxSetCursor;

        var code = ConstantsManager.SetCursorPositionCode;

        using (var editor = new StringEditor(code))
        {
            UpdateValueInCode(editor, x.ToString(), ConstantsManager.SetCursorPositionX, ConstantsManager.SetCursorBufferSize);
            UpdateValueInCode(editor, y.ToString(), ConstantsManager.SetCursorPositionX, ConstantsManager.SetCursorBufferSize);
        }

        return code;
    }

    private static void UpdateValueInCode
    (StringEditor value, string content, int offset, int size)
    {
        value[offset, size] = content;
    }
}
