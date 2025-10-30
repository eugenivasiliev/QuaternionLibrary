using System.Collections.Generic;
using Math;

public class MyRobotController : UnityEngine.MonoBehaviour
{
    [UnityEngine.SerializeField] private List<UnityEngine.GameObject> myJoints;

    void Update()
    {
        for (int i = 0; i < myJoints.Count; i++)
        {
            if (myJoints[i].GetComponent<IJoint<Math.Matrix4x4>>() != null)
                myJoints[i].GetComponent<IJoint<Math.Matrix4x4>>().JointUpdate();
            if (myJoints[i].GetComponent<IJoint<Math.Quaternion>>() != null)
                myJoints[i].GetComponent<IJoint<Math.Quaternion>>().JointUpdate();
        }
    }
}