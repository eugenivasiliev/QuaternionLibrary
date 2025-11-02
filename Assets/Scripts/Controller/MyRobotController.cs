using System.Collections.Generic;
using System.Collections;
using Math;
using Geometry;

public class MyRobotController : UnityEngine.MonoBehaviour
{
    [UnityEngine.SerializeField] private List<UnityEngine.GameObject> joints;
    [UnityEngine.SerializeField] private int activeJoint = 0;

    private IJoint<Matrix4x4> transJoint;
    private IJoint<Quaternion> rotJoint;

    [UnityEngine.Header("VFX")]
    [UnityEngine.SerializeField] private UnityEngine.GameObject particles;

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

        StartCoroutine(ParticleVFX());

        if (joints[activeJoint].TryGetComponent(out transJoint)) return;
        if (joints[activeJoint].TryGetComponent(out rotJoint)) return;

        throw new System.Exception("Invalid joint");
    }

    private IEnumerator ParticleVFX()
    {
        UnityEngine.GameObject instance = 
            Instantiate(particles, joints[activeJoint].GetComponent<Transform>().position, Quaternion.identity);

        yield return new UnityEngine.WaitForSeconds(0.2f);

        Destroy(instance);

        yield return null;
    }
}