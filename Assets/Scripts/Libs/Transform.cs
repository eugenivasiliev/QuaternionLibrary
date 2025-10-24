using Math;

namespace Geometry
{
    public class Transform
    {
        public Vector3 position = Vector3.zero;
        public Quaternion rotation = Quaternion.identity;
        public Vector3 eulerAngles
        {
            get { return Constants.Deg2Rad * rotation.eulerAngles; }
            set
            {
                Vector3 reducedVal = value;
                reducedVal.x %= 360;
                reducedVal.y %= 360;
                reducedVal.z %= 360;
                rotation = new Quaternion(reducedVal.x, reducedVal.y, reducedVal.z, true);
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
            this.rotation = rotation;
            this.angularVelocity = angularVelocity;
        }
    }
}