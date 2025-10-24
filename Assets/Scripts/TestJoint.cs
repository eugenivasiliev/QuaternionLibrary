using Math;
using UnityEngine.InputSystem;

public class TestJoint : UnityEngine.MonoBehaviour, ILinearJoint
{
    public string PositiveMotionKeyId => "Joint1/Up";

    public string NegativeMotionKeyId => "Joint1/Down";

    double ILinearJoint.minMovement => 0d;

    double ILinearJoint.maxMovement => 1d;

    double ILinearJoint.delta => 0.1d;

    [field: UnityEngine.SerializeField] ClampedDouble ILinearJoint.t { get; set; }

    Vector3 ILinearJoint.direction => Vector3.up;

    Vector3 startPos;

    private void Start()
    {
        (this as ILinearJoint).Setup();
        InputSystem.actions.Enable();
        startPos = Vector3.zero;
    }

    private void Update()
    {
        this.transform.position = startPos + (this as ILinearJoint).GetTranslation();
    }
}
