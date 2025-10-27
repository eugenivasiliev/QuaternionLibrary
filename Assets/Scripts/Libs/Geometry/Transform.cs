using Math;
using Unity.VisualScripting;

namespace Geometry
{
    public class Transform : UnityEngine.MonoBehaviour
    {
        public Transform parent;
        public System.Collections.Generic.List<Transform> children;

        public Vector3 position = Vector3.zero;
        public Quaternion localRotation = Quaternion.identity;
        public Quaternion rotation { 
            get 
            { 
                if(parent != null) return parent.localRotation * localRotation;
                return localRotation;
            } 
            set 
            {
                foreach (Transform t in children)
                    t.rotation = value * (localRotation.inverse * t.rotation);
                localRotation = value;
            } 
        }
        public Vector3 eulerAngles
        {
            get { return Constants.Deg2Rad * localRotation.eulerAngles; }
            set
            {
                Vector3 reducedVal = value;
                reducedVal.x %= 360;
                reducedVal.y %= 360;
                reducedVal.z %= 360;
                localRotation = new Quaternion(reducedVal.x, reducedVal.y, reducedVal.z, true);
            }
        }
        public Vector3 scale = Vector3.zero;

        public Vector3 velocity = Vector3.zero;
        public Vector3 acceleration = Vector3.zero;

        public Vector3 angularVelocity = Vector3.zero;
        public Vector3 angularAcceleration = Vector3.zero;

        public Transform() { }
        public Transform(Vector3 position, Vector3 velocity)
        {
            this.position = position;
            this.velocity = velocity;
        }
        public Transform(Quaternion rotation, Vector3 angularVelocity)
        {
            this.localRotation = rotation;
            this.angularVelocity = angularVelocity;
        }

        public Transform(Vector3 position, Quaternion rotation, Vector3 scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
        }

        public static implicit operator Transform(UnityEngine.Transform transform) =>
            new Transform(transform.position, transform.rotation, transform.lossyScale);

        private void Start()
        {
            this.position = this.transform.position;
            this.rotation = this.transform.rotation;
            this.scale = this.transform.lossyScale;
        }

        private void Update()
        {
            this.transform.position = this.position;
            this.transform.rotation = this.rotation;
        }

    }
}