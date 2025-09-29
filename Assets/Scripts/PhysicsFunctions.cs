using System;

namespace Physics
{
    public class Functions
    {
        public Vector2 lerp(Vector2 a, Vector2 b, double t) => t * a + (1 - t) * b;
        public Vector3 lerp(Vector3 a, Vector3 b, double t) => t * a + (1 - t) * b;
        public Quaternion lerp(Quaternion a, Quaternion b, double t) => t * a + (1 - t) * b;

        public Vector2 slerp(Vector2 a, Vector2 b, double t) 
        {
            double omega = Vector2.Angle(a, b);
            return (System.Math.Sin(omega * t) / System.Math.Sin(omega)) * a + (System.Math.Cos(omega * (1-t)) / System.Math.Cos(omega)) * b;
        }
        public Vector3 slerp(Vector3 a, Vector3 b, double t) 
        {
            double omega = Vector3.Angle(a, b);
            return (System.Math.Sin(omega * t) / System.Math.Sin(omega)) * a + (System.Math.Cos(omega * (1 - t)) / System.Math.Cos(omega)) * b;
        }
        public Quaternion slerp(Quaternion a, Quaternion b, double t)
        {
            double omega = Quaternion.Angle(a, b);
            return (System.Math.Sin(omega * t) / System.Math.Sin(omega)) * a + (System.Math.Cos(omega * (1 - t)) / System.Math.Cos(omega)) * b;
        }
    }
}
