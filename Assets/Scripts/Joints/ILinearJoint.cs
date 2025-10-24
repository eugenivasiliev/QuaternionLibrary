using Math;

public interface ILinearJoint
{
    public string PositiveMotionKeyId { get; }
    public string NegativeMotionKeyId { get; }

    protected double minMovement { get; }
    protected double maxMovement { get; }

    protected double delta { get; }

    public ClampedDouble t { get; set; }
    protected Vector3 direction { get; }

    public void Setup()
    {
        t = new ClampedDouble(0, minMovement, maxMovement);
        UnityEngine.InputSystem.InputSystem.actions.FindAction(PositiveMotionKeyId, true).performed += PositiveMotionAction;
        UnityEngine.InputSystem.InputSystem.actions.FindAction(NegativeMotionKeyId, true).performed += NegativeMotionAction;
    }

    public Matrix4x4 GetLocalTransformation() => Matrix4x4.CreateTranslation(t * direction);
    public Vector3 GetTranslation() => t * direction;

    private void PositiveMotionAction(UnityEngine.InputSystem.InputAction.CallbackContext ctx) =>
        t += delta;
    private void NegativeMotionAction(UnityEngine.InputSystem.InputAction.CallbackContext ctx) => 
        t -= delta;
}
