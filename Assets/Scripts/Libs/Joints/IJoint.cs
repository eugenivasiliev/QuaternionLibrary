using Math;

public interface IJoint<T>
{
    public string PositiveMotionKeyId { get; }
    public string NegativeMotionKeyId { get; }

    public double MinRange { get; }
    public double MaxRange { get; }

    public double Delta { get; }

    public ClampedDouble t { get; set; }

    public void Setup()
    {
        t = new ClampedDouble(0, MinRange, MaxRange);
        UnityEngine.InputSystem.InputSystem.actions.FindAction(PositiveMotionKeyId, true).performed += PositiveMotionAction;
        UnityEngine.InputSystem.InputSystem.actions.FindAction(NegativeMotionKeyId, true).performed += NegativeMotionAction;
    }

    public T GetLocalTransformation();

    protected void PositiveMotionAction(UnityEngine.InputSystem.InputAction.CallbackContext ctx) =>
        t += Delta;
    protected void NegativeMotionAction(UnityEngine.InputSystem.InputAction.CallbackContext ctx) =>
        t -= Delta;
}
