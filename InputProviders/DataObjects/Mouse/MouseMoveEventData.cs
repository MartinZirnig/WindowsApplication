using System.Numerics;
using WindowsLowLevelStructs;

namespace BasicInputs.DataObjects.Mouse;

[Serializable]
public readonly struct MouseMoveEventData(Point position, Point lastPosition, Vector2 movement)
{
    public const int TypeIdentifikator = 200;

    public readonly Point Position = position;
    public readonly Point LastPosition = lastPosition;

    public readonly Vector2 Movement = movement;
}