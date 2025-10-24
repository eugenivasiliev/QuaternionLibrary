namespace Math
{
    public static class Functions
    {
        public static double Min(double a, double b) => (a < b) ? a : b;
        public static double Max(double a, double b) => (a > b) ? a : b;
        public static double Clamp(double val, double min, double max) => Min(Max(val, min), max);

        public static Vector2 lerp(Vector2 a, Vector2 b, double t) => t * a + (1 - t) * b;
        public static Vector3 lerp(Vector3 a, Vector3 b, double t) => t * a + (1 - t) * b;
        public static Quaternion lerp(Quaternion a, Quaternion b, double t) => t * a + (1 - t) * b;

        public static Vector2 slerp(Vector2 a, Vector2 b, double t) 
        {
            double omega = Vector2.Angle(a, b);
            return (System.Math.Sin(omega * t) / System.Math.Sin(omega)) * a + (System.Math.Cos(omega * (1-t)) / System.Math.Cos(omega)) * b;
        }
        public static Vector3 slerp(Vector3 a, Vector3 b, double t) 
        {
            double omega = Vector3.Angle(a, b);
            return (System.Math.Sin(omega * t) / System.Math.Sin(omega)) * a + (System.Math.Cos(omega * (1 - t)) / System.Math.Cos(omega)) * b;
        }
        public static Quaternion slerp(Quaternion a, Quaternion b, double t)
        {
            double omega = Quaternion.Angle(a, b);
            return (System.Math.Sin(omega * t) / System.Math.Sin(omega)) * a + (System.Math.Cos(omega * (1 - t)) / System.Math.Cos(omega)) * b;
        }
    }
}
