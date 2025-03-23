using System.Runtime.InteropServices;
using WindowsLowLevelStructs;
using BasicInputs.DataObjects.Mouse;

namespace BasicInputs.Mouse.Mouse;

internal class MouseStateManager
{
    public void SetPosition(Point point)
    {
        SetCursorPos(point.X, point.Y);
    }
    public Point GetCursorPosition()
    {
        if (GetCursorPos(out Point point))
            return point;
        return default;
    }

    public void LimitCursor(Rectangle rectangle)
    {
        ClipCursor(ref rectangle);
    }
    public Rectangle GetCursorLimitation()
    {
        if (GetClipCursor(out Rectangle limits))
            return limits;
        return default;
    }
    public void FreeCursor()
    {
        ClipCursor(nint.Zero);
    }

    public Point RelateScreenPointToWindow(nint windowHandle, Point point)
    {
        if (ScreenToClient(windowHandle, ref point))
            return point;
        return default;
    }
    public Point RelateWindowPointToScreen(nint windowHandle, Point point)
    {
        if (ClientToScreen(windowHandle, ref point))
            return point;
        return default;
    }

    public void Execute(SimulatedMouseEvent mouseEvent)
    {
        SendInput((uint)mouseEvent.Input.Length, mouseEvent.Input, Marshal.SizeOf(typeof(MouseInput)));
    }
    public void Click()
    {
        var operation = SimulatedMouseEvent.Create(MouseEventType.LeftButtonDown, MouseEventType.LeftButtonUp);
        Execute(operation);
    }
    public void RightClick()
    {
        var operation = SimulatedMouseEvent.Create(MouseEventType.RightButtonDown, MouseEventType.RightButtonUp);
        Execute(operation);
    }
    public void Move(int x, int y)
    {
        var operationStruct = new RawMouseData()
        {
            Position = new Point(x, y),
            Flags = (uint)MouseEventType.MouseMove,
            MouseData = 0,
            Time = 0,
            ExtraInfo = nint.Zero
        };
        var operation = SimulatedMouseEvent.Create(operationStruct);
        Execute(operation);

    }
    public bool IsButtonDown(MouseButtons key)
    {
        return (GetAsyncKeyState((int)key) & 0x8000) != 0;
    }




    [DllImport("user32.dll")]
    public static extern short GetAsyncKeyState(int keyCode);

    [DllImport("user32.dll")]
    static extern bool GetCursorPos(out Point result);


    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int x, int y);


    [DllImport("user32.dll")]
    static extern bool ClipCursor(ref Rectangle rectangle);
    [DllImport("user32.dll")]
    static extern bool ClipCursor(nint rectangle);

    [DllImport("user32.dll")]
    static extern bool GetClipCursor(out Rectangle limits);

    [DllImport("user32.dll")]
    static extern bool ScreenToClient(nint handle, ref Point position);

    [DllImport("user32.dll")]
    static extern bool ClientToScreen(nint handle, ref Point position);

    
    [DllImport("user32.dll", SetLastError = true)]
    static extern uint SendInput(uint eventsCount, MouseInput[] events, int sizeOfEvent);
}
