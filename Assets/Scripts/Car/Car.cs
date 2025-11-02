using Geometry;
using Math;

public class Car : UnityEngine.MonoBehaviour
{
    [UnityEngine.SerializeField] private Transform Transform;
    [UnityEngine.SerializeField] private Vector3 cameraOffset = 10d * Vector3.up + 10d * Vector3.back;
    CyclicDouble rotationAngle = CyclicDouble.cyclicAngleDouble;

    [UnityEngine.Header("Obstacles")]
    [UnityEngine.SerializeField] private string obstacleTag;

    private void Update()
    {
        UnityEngine.Camera.main.transform.position = this.Transform.position + this.Transform.rotation * cameraOffset;
        UnityEngine.Camera.main.transform.LookAt(this.transform);

        this.Transform.position += this.Transform.rotation * (UnityEngine.Input.GetAxis("Vertical") * Vector3.forward);
        rotationAngle -= UnityEngine.Input.GetAxis("Horizontal") * 0.1d;
        this.Transform.rotation = new Quaternion(Vector3.up, rotationAngle);
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag != obstacleTag) return;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

}
