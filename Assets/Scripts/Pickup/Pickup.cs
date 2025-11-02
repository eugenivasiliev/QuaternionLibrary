using System.Collections.Generic;
using Geometry;
using Math;

public class Pickup : UnityEngine.MonoBehaviour
{
    [UnityEngine.SerializeField] private Transform Transform;

    [UnityEngine.Header("Target")]
    [UnityEngine.SerializeField] private string targetTag;
    [UnityEngine.SerializeField] private Transform target = null;
    [UnityEngine.SerializeField] private Vector3 targetOffset;

    [UnityEngine.SerializeField] private List<Transform> collisions = new List<Transform>();

    [UnityEngine.Header("Input")]
    [UnityEngine.SerializeField] private string engageKeyId;

    private void Update()
    {
        if (target != null)
        {
            //Update target if it exists
            target.position = this.Transform.position + (this.Transform.rotation * targetOffset);
            target.rotation = this.Transform.rotation;
            target.Refresh();
        }

        if (!UnityEngine.Input.GetKeyDown(engageKeyId)) return;
        
        if(target != null)
        {
            //If target already existed, remove
            target.gameObject.GetComponent<UnityEngine.Rigidbody>().useGravity = true;
            target.enabled = false;
            target = null;
            return;
        }

        //Pick up new target
        foreach (Transform t in collisions)
            if (t.gameObject.tag == targetTag) {
                target = t;
                target.gameObject.GetComponent<UnityEngine.Rigidbody>().useGravity = false;
                target.enabled = true;
                target.Setup();
                return;
            }
    }

    private void OnTriggerEnter(UnityEngine.Collider other) 
    {
        if (!other.TryGetComponent(out Transform transform)) return;
        collisions.Add(transform);
    }
    private void OnTriggerExit(UnityEngine.Collider other)
    {
        if (!other.TryGetComponent(out Transform transform)) return;
        collisions.Remove(transform);
    }
}
