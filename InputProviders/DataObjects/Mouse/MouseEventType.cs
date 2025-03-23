namespace BasicInputs.DataObjects.Mouse;

[Serializable]
public enum MouseEventType
{
    MouseMove = 0x0200,
    LeftButtonDown = 0x0201,
    LeftButtonUp = 0x0202,
    LeftButtonClick = 0x0203,
    RightButtonDown = 0x0204,
    RightButtonUp = 0x0205,
    RightButtonClick = 0x0206,
    MiddleButtonDown = 0x0207,
    MiddleButtonUp = 0x0208,
    MiddleButtonClick = 0x0209,
    WheelRotation = 0x020A,
    ExtraButtonDown = 0x020B,
    ExtraButtonUp = 0x020C,
    ExtraButtonClick = 0x020D,
    HorizontalWheelMove = 0x020E
}