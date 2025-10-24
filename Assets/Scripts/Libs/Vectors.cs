namespace Math
{
    public struct Vector2
    {
        public double x, y;

        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2 operator +(Vector2 l, Vector2 r) => new Vector2(l.x + r.x, l.y + r.y);
        public static Vector2 operator -(Vector2 v) => new Vector2(-v.x, -v.y);
        public static Vector2 operator -(Vector2 l, Vector2 r) => l + (-r);
        public static Vector2 operator *(double d, Vector2 v) => new Vector2(d * v.x, d * v.y);
        public static Vector2 operator /(Vector2 v, double d) => (1 / d) * v;
        public static double operator *(Vector2 l, Vector2 r) => l.x * r.x + l.y * r.y;

        public double sqrMagnitude { get { return this.x * this.x + this.y * this.y; } }
        public double magnitude { get { return System.Math.Sqrt(this.sqrMagnitude); } }

        public Vector2 normalized { get { return this / this.magnitude; } }
        public void Normalize() => this = this.normalized;

        public static double Dot(Vector2 v1, Vector2 v2) => v1 * v2;
        public double Dot(Vector2 v) => this * v;
        public static double Angle(Vector2 v1, Vector2 v2) => (v1 * v2) / (v1.magnitude * v2.magnitude);
        public double Angle(Vector2 v) => Vector2.Angle(this, v);
        public static Vector2 Project(Vector2 v1, Vector2 v2) => ((v1 * v2) / v2.sqrMagnitude) * v2;
        public Vector2 Project(Vector2 v) => ((this * v) / v.sqrMagnitude) * v;

        #region CONSTS
        public static Vector2 zero
        {
            get
            {
                return new Vector2(0, 0);
            }
        }
        public static Vector2 up
        {
            get
            {
                return new Vector2(0, 1);
            }
        }
        public static Vector2 down
        {
            get
            {
                return new Vector2(0, -1);
            }
        }
        public static Vector2 right
        {
            get
            {
                return new Vector2(1, 0);
            }
        }
        public static Vector2 left
        {
            get
            {
                return new Vector2(-1, 0);
            }
        }
        #endregion
    }

    public struct Vector3 
    { 
        public double x, y, z;

        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector3 operator+ (Vector3 l, Vector3 r) => new Vector3(l.x + r.x, l.y + r.y, l.z + r.z);
        public static Vector3 operator- (Vector3 v) => new Vector3(-v.x, -v.y, -v.z);
        public static Vector3 operator -(Vector3 l, Vector3 r) => l + (-r);
        public static Vector3 operator* (double d, Vector3 v) => new Vector3(d * v.x, d * v.y, d * v.z);
        public static Vector3 operator /(Vector3 v, double d) => (1 / d) * v;
        public static double operator* (Vector3 l, Vector3 r) => l.x * r.x + l.y * r.y + l.z * r.z;

        public double sqrMagnitude { get { return this.x * this.x + this.y * this.y + this.z * this.z; } }
        public double magnitude { get { return System.Math.Sqrt(this.sqrMagnitude); } }

        public Vector3 normalized { get { return this / this.magnitude; } }
        public void Normalize() => this = this.normalized;

        public static double Dot(Vector3 v1, Vector3 v2) => v1 * v2;
        public double Dot(Vector3 v) => this * v;
        public static Vector3 Cross(Vector3 v1, Vector3 v2) => new Vector3(v1.y * v2.z - v1.z * v2.y, v1.z * v2.x - v1.x * v2.z, v1.x * v2.z - v1.z * v2.x);
        public Vector3 Cross(Vector3 v) => Vector3.Cross(this, v);
        public static double Angle(Vector3 v1, Vector3 v2) => (v1 * v2) /(v1.magnitude *  v2.magnitude);
        public double Angle(Vector3 v) => Vector3.Angle(this, v);
        public static Vector3 Project(Vector3 v1, Vector3 v2) => ((v1 * v2) / v2.sqrMagnitude) * v2;
        public Vector3 Project(Vector3 v) => ((this * v) / v.sqrMagnitude) * v;

        public static implicit operator UnityEngine.Vector3(Vector3 v) => new UnityEngine.Vector3((float)v.x, (float)v.y, (float)v.z);

        #region CONSTS
        public static Vector3 zero
        {
            get 
            { 
                return new Vector3(0, 0, 0); 
            }
        }
        public static Vector3 up
        {
            get 
            { 
                return new Vector3(0, 1, 0); 
            }
        }
        public static Vector3 down
        {
            get 
            { 
                return new Vector3(0, -1, 0); 
            }
        }
        public static Vector3 right
        {
            get 
            { 
                return new Vector3(1, 0, 0); 
            }
        }
        public static Vector3 left
        {
            get 
            { 
                return new Vector3(-1, 0, 0); 
            }
        }
        public static Vector3 forward
        {
            get 
            { 
                return new Vector3(0, 0, 1); 
            }
        }
        public static Vector3 back
        {
            get 
            { 
                return new Vector3(0, 0, -1); 
            }
        }
        #endregion
    }
}