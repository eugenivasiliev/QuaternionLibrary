using System;
using Unity.VisualScripting;
using UnityEngine;

public class PointTest : MonoBehaviour
{
    [NonSerialized] public float speed = 5.0f;
    [NonSerialized] public Physics.Quaternion q = new Physics.Quaternion(1, 0, 0, 0);

    void Start()
    {
        //this.transform.rotation = q.ToUnity();
    }

    void Update()
    {
        //Physics.Quaternion rotation = new Physics.Quaternion(1, 0, 0, 0);

        //if (Input.GetKey(KeyCode.A)) rotation.Rotate(Physics.Vector3.up, Time.deltaTime * speed);
        //if (Input.GetKey(KeyCode.D)) rotation.Rotate(Physics.Vector3.up, -Time.deltaTime * speed);
        //if (Input.GetKey(KeyCode.W)) rotation.Rotate(Physics.Vector3.right, Time.deltaTime * speed);
        //if (Input.GetKey(KeyCode.S)) rotation.Rotate(Physics.Vector3.right, -Time.deltaTime * speed);

        //q.Rotate(rotation);
        //this.transform.rotation = q.ToUnity();

        //Debug.Log(q.eulerAngles);
        //Debug.Log(rotation.eulerAngles);
    }
}