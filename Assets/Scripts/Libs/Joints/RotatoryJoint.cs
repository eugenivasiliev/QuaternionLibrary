using Geometry;
using Math;
using System.Diagnostics;

/// <summary>
/// Joint implementing <b>rotation</b> with <see cref="Quaternion"/>
/// </summary>
/// <remarks>Derives from <see cref="UnityEngine.MonoBehaviour"/> 
/// to allow to add it as component script and use 
/// <see cref="Start"/> and <see cref="Update"/>
/// </remarks>
public class RotatoryJoint : UnityEngine.MonoBehaviour, IJoint<Quaternion>
{
    [UnityEngine.SerializeField] private string positiveMotionKeyId;
    public string PositiveMotionKeyId => positiveMotionKeyId;

    [UnityEngine.SerializeField] private string negativeMotionKeyId;
    public string NegativeMotionKeyId => negativeMotionKeyId;

    ClampedDouble IJoint<Quaternion>.t { get; set; }

    [UnityEngine.SerializeField] private double minRange;
    double IJoint<Quaternion>.MinRange => minRange;

    [UnityEngine.SerializeField] private double maxRange;
    double IJoint<Quaternion>.MaxRange => maxRange;

    [UnityEngine.SerializeField] private double delta;
    double IJoint<Quaternion>.Delta => delta;

    [UnityEngine.SerializeField] private Vector3 direction = Vector3.up;
    [UnityEngine.SerializeField] private Quaternion startRotation;

    Quaternion IJoint<Quaternion>.GetLocalTransformation() => new Quaternion(direction, (this as IJoint<Quaternion>).t, true);

    [UnityEngine.SerializeField] public Transform Transform;

    private void Start()
    {
        (this as IJoint<Quaternion>).Setup();
        UnityEngine.InputSystem.InputSystem.actions.Enable();
        startRotation = Transform.rotation;
    }

    public void Update()
    {
        Transform.rotation = (this as IJoint<Quaternion>).GetLocalTransformation() * startRotation;
    }
}
