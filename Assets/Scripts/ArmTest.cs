using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ArmTest : MonoBehaviour
{
    [SerializeField] private PointTest[] points;
    private bool passToNext = false;
    private int indexControlling = 0;

    void Start()
    {
        foreach (var point in points)
        {
            point.transform.rotation = point.q.ToUnity();
        }
    }

    void Update()
    {
        Physics.Quaternion rotation = new Physics.Quaternion(1, 0, 0, 0);

        if (Input.GetKey(KeyCode.A)) rotation.Rotate(Physics.Vector3.up, Time.deltaTime * points[indexControlling].speed);
        if (Input.GetKey(KeyCode.D)) rotation.Rotate(Physics.Vector3.up, -Time.deltaTime * points[indexControlling].speed);
        if (Input.GetKey(KeyCode.W)) rotation.Rotate(Physics.Vector3.right, Time.deltaTime * points[indexControlling].speed);
        if (Input.GetKey(KeyCode.S)) rotation.Rotate(Physics.Vector3.right, -Time.deltaTime * points[indexControlling].speed);

        points[indexControlling].q.Rotate(rotation);
        points[indexControlling].transform.rotation = points[indexControlling].q.ToUnity();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            passToNext = true;
        }

        if (passToNext)
        {
            if (indexControlling == points.Length - 1)
                indexControlling = 0;
            else
                indexControlling++;
            passToNext = false;
        }
    }
}
