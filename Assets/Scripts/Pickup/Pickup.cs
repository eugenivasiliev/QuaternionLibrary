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
        if(target != null)
            target.position = this.Transform.position + (this.Transform.rotation * targetOffset);

        if (!UnityEngine.Input.GetKey(engageKeyId)) return;
        
        if(target != null)
        {
            target = null;
            return;
        }

        foreach (Transform t in collisions)
            if (t.gameObject.tag == targetTag) {
                target = t; return;
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
