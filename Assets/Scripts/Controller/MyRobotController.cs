using System.Collections.Generic;

public class MyRobotController : UnityEngine.MonoBehaviour
{
    [UnityEngine.SerializeField] public List<IJoint<Transformation>> myJoints;


    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < myJoints.Count; i++)
        {
            if (myJoints[i] != null)
                myJoints[i].JointUpdate();
        }
    }
}
