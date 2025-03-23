using BasicInputs.DataObjects.Mouse;

namespace BasicInputs.InputProviders;

internal interface IUserInputProvider : IStandardLifecycle
{
    public event Action<MouseButtonEventData>? MouseButtonActions;
    public event Action<MouseMoveEventData>? MouseMoveActions;
}