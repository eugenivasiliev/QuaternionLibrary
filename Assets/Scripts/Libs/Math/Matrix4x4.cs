using JetBrains.Annotations;
using System.Numerics;

namespace Math
{
    [System.Serializable]
    public class Matrix4x4 : Transformation
    {
        public double M11;
        public double M12;
        public double M13;
        public double M14;
        public double M21;
        public double M22;
        public double M23;
        public double M24;
        public double M31;
        public double M32;
        public double M33;
        public double M34;
        public double M41;
        public double M42;
        public double M43;
        public double M44;

        public Matrix4x4()
        {
            M11 = 0; M12 = 0; M13 = 0; M14 = 0;
            M21 = 0; M22 = 0; M23 = 0; M24 = 0;
            M31 = 0; M32 = 0; M33 = 0; M34 = 0;
            M41 = 0; M42 = 0; M43 = 0; M44 = 0;
        }

        public Matrix4x4(double M11, double M12, double M13, double M14, 
            double M21, double M22, double M23, double M24, 
            double M31, double M32, double M33, double M34, 
            double M41, double M42, double M43, double M44)
        {
            this.M11 = M11; this.M12 = M12; this.M13 = M13; this.M14 = M14;
            this.M21 = M21; this.M22 = M22; this.M23 = M23; this.M24 = M24;
            this.M31 = M31; this.M32 = M32; this.M33 = M33; this.M34 = M34;
            this.M41 = M41; this.M42 = M42; this.M43 = M43; this.M44 = M44;
        }

        public readonly static Matrix4x4 Identity = new Matrix4x4();

        public static Matrix4x4 CreateTranslation(Vector3 translation) =>
            new Matrix4x4(
                1, 0, 0, translation.x,
                0, 1, 0, translation.y,
                0, 0, 1, translation.z,
                0, 0, 0, 1
                );

        public static Matrix4x4 CreateRotationX(double angle) =>
            new Matrix4x4(
                1, 0, 0, 0,
                0, Math.Cos(angle), -Math.Sin(angle), 0,
                0, Math.Sin(angle), Math.Cos(angle), 0,
                0, 0, 0, 1
                );

        public static Matrix4x4 CreateRotationY(double angle) =>
            new Matrix4x4(
                Math.Cos(angle), 0, -Math.Sin(angle), 0,
                0, 1, 0, 0,
                Math.Sin(angle), 0, Math.Cos(angle), 0,
                0, 0, 0, 1
                );

        public static Matrix4x4 CreateRotationZ(double angle) =>
            new Matrix4x4(
                Math.Cos(angle), -Math.Sin(angle), 0, 0,
                Math.Sin(angle), Math.Cos(angle), 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
                );

        public static Matrix4x4 CreateRotation(double a, Vector3 axis)
        {
            Vector3 u = axis.normalized;
            double c = Math.Cos(a);
            double c_1 = 1 - c;
            double s = Math.Sin(a);
            return new Matrix4x4(
                u.x * u.x * c_1 + c, u.x * u.y * c_1 - u.z * s, u.x * u.z * c_1 + u.y * s, 0,
                u.x * u.y * c_1 + u.z * s, u.y * u.y * c_1 + c, u.y * u.z * c_1 - u.x * s, 0,
                u.x * u.z * c_1 - u.y * s, u.y * u.z * c_1 + u.x * s, u.z * u.z * c_1 + c, 0,
                0, 0, 0, 1
                );
        }

        public static HomogenousVector3 operator *(Matrix4x4 m, HomogenousVector3 hv) =>
            new HomogenousVector3(
                m.M11 * hv.x + m.M12 * hv.y + m.M13 * hv.z + m.M14 * hv.w,
                m.M21 * hv.x + m.M22 * hv.y + m.M23 * hv.z + m.M24 * hv.w,
                m.M31 * hv.x + m.M32 * hv.y + m.M33 * hv.z + m.M34 * hv.w,
                m.M41 * hv.x + m.M42 * hv.y + m.M43 * hv.z + m.M44 * hv.w
                );
        public static Vector3 operator *(Matrix4x4 m, Vector3 v) => (Vector3)(m * (HomogenousVector3)v);
    }
}
