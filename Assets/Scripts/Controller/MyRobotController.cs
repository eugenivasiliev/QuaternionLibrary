using System.Collections.Generic;
using Math;

public class MyRobotController : UnityEngine.MonoBehaviour
{
    [UnityEngine.SerializeField] private List<UnityEngine.GameObject> joints;
    [UnityEngine.SerializeField] private int activeJoint = 0;

    private IJoint<Matrix4x4> transJoint;
    private IJoint<Quaternion> rotJoint;

    private void Start()
    {
        UnityEngine.InputSystem.InputSystem.actions.FindAction("Joint Change").performed += ctx =>
        {
            activeJoint++;
            activeJoint %= joints.Count;
            ChangeJoint();
        };
        ChangeJoint();
    }

    private void Update()
    {
        if (transJoint != null && UnityEngine.Input.GetKey(transJoint.PositiveMotionKeyId)) transJoint.PositiveMotionAction();
        if(transJoint != null && UnityEngine.Input.GetKey(transJoint.NegativeMotionKeyId)) transJoint.NegativeMotionAction();

        if(rotJoint != null && UnityEngine.Input.GetKey(rotJoint.PositiveMotionKeyId)) rotJoint.PositiveMotionAction();
        if(rotJoint != null && UnityEngine.Input.GetKey(rotJoint.NegativeMotionKeyId)) rotJoint.NegativeMotionAction();
    }

    private void ChangeJoint()
    {
        transJoint = null; rotJoint = null;

        if (joints[activeJoint].TryGetComponent(out transJoint)) return;
        if (joints[activeJoint].TryGetComponent(out rotJoint)) return;

        throw new System.Exception("Invalid joint");
    }
}