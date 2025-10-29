using Geometry;
using Math;

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

    [UnityEngine.SerializeField] public Transform myTransform;

    private void Start()
    {
        (this as IJoint<Quaternion>).Setup();
        UnityEngine.InputSystem.InputSystem.actions.Enable();
        startRotation = myTransform.rotation;
    }

    public void JointUpdate()
    {
        myTransform.rotation = (this as IJoint<Quaternion>).GetLocalTransformation() * startRotation;

        if (UnityEngine.Input.GetKey(PositiveMotionKeyId)) (this as IJoint<Quaternion>).PositiveMotionAction();
        if (UnityEngine.Input.GetKey(NegativeMotionKeyId)) (this as IJoint<Quaternion>).NegativeMotionAction();
    }
}
