using System.Collections.Generic;
using Math;

public class MyRobotController : UnityEngine.MonoBehaviour
{
    [UnityEngine.SerializeField] private List<UnityEngine.GameObject> myJoints;

    void Start()
    {

    }

    void Update()
    {
        for (int i = 0; i < myJoints.Count; i++)
        {
            if (myJoints[i] == null)
            {
                myJoints[i].GetComponent<IJoint<Math.Quaternion>>().JointUpdate();
            }
        }
    }
}
