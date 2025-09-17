using UnityEngine;

namespace Physics
{
    public struct Quaternion
    {
        public double a, b, c, d; //real, i, j, k

        public Quaternion(double a, double b, double c, double d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        public Quaternion(double roll, double pitch, double yaw)
        {
            double cr = System.Math.Cos(roll * 0.5);
            double sr = System.Math.Sin(roll * 0.5);
            double cp = System.Math.Cos(pitch * 0.5);
            double sp = System.Math.Sin(pitch * 0.5);
            double cy = System.Math.Cos(yaw * 0.5);
            double sy = System.Math.Sin(yaw * 0.5);

            this.a = cr * cp * cy + sr * sp * sy;
            this.b = sr * cp * cy - cr * sp * sy;
            this.c = cr * sp * cy + sr * cp * sy;
            this.d = cr * cp * sy - sr * sp * cy;
        }

        public Quaternion(Vector3 axis, double angle)
        {
            double angle_2 = angle * 0.5f;
            Vector3 n_axis = axis.normalized;
            double s = System.Math.Sin(angle_2);

            this.a = System.Math.Cos(angle_2);
            this.b = s * n_axis.x;
            this.c = s * n_axis.y;
            this.d = s * n_axis.z;
        }

        static public Quaternion operator +(Quaternion q1, Quaternion q2) => new Quaternion(q1.a + q2.a, q1.b + q2.b, q1.c + q2.c, q1.d + q2.d);

        static public Quaternion operator -(Quaternion q) => new Quaternion(-q.a, -q.b, -q.c, -q.d);

        static public Quaternion operator -(Quaternion q1, Quaternion q2) => q1 + -q2;

        static public Quaternion operator *(Quaternion q1, Quaternion q2) => 
            new Quaternion(
                q1.a * q2.a - q1.b * q2.b - q1.c * q2.c - q1.d * q2.d, //real
                q1.a * q2.b + q1.b * q2.a + q1.c * q2.d - q1.d * q2.c, //i
                q1.a * q2.c + q1.c * q2.a + q1.d * q2.b - q1.b * q2.d, //j
                q1.a * q2.d + q1.d * q2.a + q1.b * q2.c - q1.c * q2.b  //k
            );

        static public Quaternion operator *(double d, Quaternion q) => new Quaternion(d * q.a, d * q.b, d * q.c, d * q.d);
        static public Quaternion operator /(Quaternion q, double d) => (1.0f / d) * q;

        public Quaternion conjugated { get { return new Quaternion(this.a, -this.b, -this.c, -this.d); } }
        public void Conjugate() => this = this.conjugated;

        public double sqrMagnitude { get { return this.a * this.a + this.b * this.b + this.c * this.c + this.d * this.d; } }
        public double SqrMagnitude() => this.sqrMagnitude;

        public double magnitude { get { return System.Math.Sqrt(this.sqrMagnitude); } }
        public double Magnitude() => this.magnitude;

        public Quaternion normalized { get { return this / this.magnitude; } }
        public void Normalize() => this = this.normalized;

        public Quaternion inverse { get { return this.conjugated / this.sqrMagnitude; } }
        public void Invert() => this = this.inverse;

        public void Rotate(Quaternion rotation)
        {
            this = this * rotation;
        }
        public void Rotate(Vector3 axis, double angle)
        {
            this.Rotate(new Quaternion(axis, angle));
        }

        public Vector3 eulerAngles
        {
            get
            {
                Vector3 angles;

                // roll
                double sinr_cosp = 2 * (this.a * this.b + this.c * this.d);
                double cosr_cosp = 1 - 2 * (this.b * this.b + this.c * this.c);
                angles.x = (float)System.Math.Atan2(sinr_cosp, cosr_cosp);

                // pitch
                double sinp = System.Math.Sqrt(1 + 2 * (this.a * this.c - this.b * this.d));
                double cosp = System.Math.Sqrt(1 - 2 * (this.a * this.c - this.b * this.d));
                angles.y = 2 * (float)System.Math.Atan2(sinp, cosp) - System.MathF.PI / 2;

                // yaw
                double siny_cosp = 2 * (this.a * this.d + this.b * this.c);
                double cosy_cosp = 1 - 2 * (this.c * this.c + this.d * this.d);
                angles.z = (float)System.Math.Atan2(siny_cosp, cosy_cosp);

                return angles;
            }
        }

        public UnityEngine.Quaternion ToUnity() => new UnityEngine.Quaternion((float)this.a, (float)this.b, (float)this.c, (float)this.d);
    }
}
