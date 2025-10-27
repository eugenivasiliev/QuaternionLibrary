namespace Math
{
    public struct HomogenousVector2
    {
        public double x, y, z;

        public HomogenousVector2(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => $"({x}, {y}, {z})";

        public static bool operator== (HomogenousVector2 lhs, HomogenousVector2 rhs) => 
            (lhs.x / lhs.z) == (rhs.x / rhs.z) && (lhs.y / lhs.z) == (rhs.y / rhs.z);
        public static bool operator !=(HomogenousVector2 lhs, HomogenousVector2 rhs) =>
            (lhs.x / lhs.z) != (rhs.x / rhs.z) || (lhs.y / lhs.z) != (rhs.y / rhs.z);

        public static implicit operator Vector2 (HomogenousVector2 v) => new Vector2(v.x / v.z, v.y / v.z);
        public static implicit operator HomogenousVector2(Vector2 v) => new HomogenousVector2(v.x, v.y, 1);
    }

    public struct HomogenousVector3
    {
        public double x, y, z, w;

        public HomogenousVector3(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => $"({x}, {y}, {z}, {w})";

        public static bool operator ==(HomogenousVector3 lhs, HomogenousVector3 rhs) =>
            (lhs.x / lhs.w) == (rhs.x / rhs.w) && (lhs.y / lhs.w) == (rhs.y / rhs.w) && (lhs.z / lhs.w) == (rhs.z / rhs.w);
        public static bool operator !=(HomogenousVector3 lhs, HomogenousVector3 rhs) =>
            (lhs.x / lhs.w) != (rhs.x / rhs.w) || (lhs.y / lhs.w) != (rhs.y / rhs.w) || (lhs.z / lhs.w) != (rhs.z / rhs.w);

        public static implicit operator Vector3(HomogenousVector3 v) => new Vector3(v.x / v.w, v.y / v.w, v.z / v.w);
        public static implicit operator HomogenousVector3(Vector3 v) => new HomogenousVector3(v.x, v.y, v.z, 1);
    }
}