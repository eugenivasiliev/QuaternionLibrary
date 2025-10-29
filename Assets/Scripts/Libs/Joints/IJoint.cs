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
    }

    public T GetLocalTransformation();

    public void PositiveMotionAction() => t += Delta;
    public void NegativeMotionAction() => t -= Delta;

    public void JointUpdate() { }
}
