using Math;

/// <summary>
/// Joint implementing <b>translation</b> with <see cref="Matrix4x4"/>
/// </summary>
/// <remarks>Derives from <see cref="UnityEngine.MonoBehaviour"/> 
/// to allow to add it as component script and use 
/// <see cref="Start"/> and <see cref="Update"/>
/// </remarks>
public class LinearJoint : UnityEngine.MonoBehaviour, IJoint<Matrix4x4>
{
    [UnityEngine.SerializeField] private string positiveMotionKeyId;
    public string PositiveMotionKeyId => positiveMotionKeyId;

    [UnityEngine.SerializeField] private string negativeMotionKeyId;
    public string NegativeMotionKeyId => negativeMotionKeyId;

    ClampedDouble IJoint<Matrix4x4>.t { get; set; }

    [UnityEngine.SerializeField] private double minRange;
    double IJoint<Matrix4x4>.MinRange => minRange;

    [UnityEngine.SerializeField] private double maxRange;
    double IJoint<Matrix4x4>.MaxRange => maxRange;

    [UnityEngine.SerializeField] private double delta;
    double IJoint<Matrix4x4>.Delta => delta;

    [UnityEngine.SerializeField] private Vector3 direction = Vector3.up;
    [UnityEngine.SerializeField] private Vector3 startPos;

    Matrix4x4 IJoint<Matrix4x4>.GetLocalTransformation() => Matrix4x4.CreateTranslation((this as IJoint<Matrix4x4>).t * direction);

    private void Start()
    {
        (this as IJoint<Matrix4x4>).Setup();
        UnityEngine.InputSystem.InputSystem.actions.Enable();
        startPos = this.GetComponent<Geometry.Transform>().position;
    }

    public void Update()
    {
        this.GetComponent<Geometry.Transform>().position = (this as IJoint<Matrix4x4>).GetLocalTransformation() * startPos;
    }
}
