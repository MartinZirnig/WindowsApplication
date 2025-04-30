using BasicInputs.DataObjects.Mouse;
using System.Numerics;
using WindowsHooks;
using WindowsLowLevelStructs;

namespace BasicInputs.InputProviders;

public class IncludedUserInputProvider : IUserInputProvider
{
    public event Action<MouseButtonEventData>? MouseButtonActions;
    public event Action<MouseMoveEventData>? MouseMoveActions;

    private bool _disposed;
    private Point _lastPosition;
    private WindowsMessageManager? _msgManager;

    public void Open()
    {
        _msgManager = WindowsMessageManager.Instance;
        _msgManager.OnMessage += OnMessage;

        _lastPosition = MouseManager.CursorPosition;
    }

    private void MouseMoved(MouseMoveEventData data)
    {
        MouseMoveActions?.Invoke(data);
    }
    private void MouseButtonStateChanged(MouseButtonEventData data)
    {
        MouseButtonActions?.Invoke(data);
    }

    private void OnMessage(WinApiMessage msg)
    {
        if (msg.Message == (int)MouseEventType.MouseMove)
        {
            var data = new MouseMoveEventData
            (
                msg.Position,
                _lastPosition,
                new Vector2(
                    msg.Position.X - _lastPosition.X, msg.Position.Y - _lastPosition.Y)
            );
            _lastPosition = msg.Position;
            MouseMoved(data);
        }
        if (msg.Message >= 0x0200 && msg.Message <= 0x020E)
        {
            var data = new MouseButtonEventData(
                (MouseEventType)msg.Message, msg.GetPointFromMouseEvent(), (short)msg.WParam);


        }

    }




    public void Close()
    {
        WindowsMessageManager.Close();

    }

    public void Dispose()
    {
        if (_disposed) return;

        Close();

        MouseButtonActions = null;
        MouseMoveActions = null;

        _disposed = true;
    }
}