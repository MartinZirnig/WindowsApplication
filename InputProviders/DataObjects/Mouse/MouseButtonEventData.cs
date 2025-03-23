using WindowsLowLevelStructs;

namespace BasicInputs.DataObjects.Mouse;

[Serializable]
public readonly struct MouseButtonEventData(MouseEventType action, Point position, int wheelRotation)
{
    public const int TypeIdentifikator = 100;

    public readonly MouseEventType Action = action;
    public readonly Point Position = position;
    public readonly int WheelRotation = wheelRotation;

}