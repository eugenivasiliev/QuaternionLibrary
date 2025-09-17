using UnityEngine;

public class PhysicsTest : MonoBehaviour
{
    Physics.Quaternion q = new Physics.Quaternion(1, 0, 0, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.transform.rotation = q.ToUnity();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Tick");

        Physics.Quaternion rotation = new Physics.Quaternion(1, 0, 0, 0);

        if (Input.GetKey(KeyCode.A)) rotation.Rotate(Vector3.up, 0.1);
        if (Input.GetKey(KeyCode.D)) rotation.Rotate(Vector3.up, -0.1);
        if (Input.GetKey(KeyCode.W)) rotation.Rotate(Vector3.right, 0.1);
        if (Input.GetKey(KeyCode.S)) rotation.Rotate(Vector3.right, -0.1);

        q.Rotate(rotation);
        this.transform.rotation = q.ToUnity();

        Debug.Log(q.eulerAngles);
        Debug.Log(rotation.eulerAngles);
    }
}
