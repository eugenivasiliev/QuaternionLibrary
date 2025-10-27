using System;

namespace Math
{
    [Serializable]
    public struct ClampedDouble
    {
        public readonly double min;
        public readonly double max;

        public ClampedDouble(double value)
        {
            min = 0;
            max = 1;
            this.value = 0;
            this.Value = value;
        }

        public ClampedDouble(double value, double min, double max)
        {
            this.min = min;
            this.max = max;
            this.value = 0;
            this.Value = value;
        }

        private double value;
        [field: UnityEngine.SerializeField]
        private double Value
        {
            get => value;
            set => this.value = Math.Clamp(value, min, max);
        }

        public static implicit operator double(ClampedDouble cD) => cD.Value;

        public static ClampedDouble operator +(ClampedDouble cD, double d) => new ClampedDouble(cD.Value + d, cD.min, cD.max);
        public static ClampedDouble operator -(ClampedDouble cD, double d) => new ClampedDouble(cD.Value - d, cD.min, cD.max);
        public static ClampedDouble operator +(ClampedDouble a, ClampedDouble b) => new ClampedDouble(a.Value + b.Value, a.min, a.max);
        public static ClampedDouble operator -(ClampedDouble a, ClampedDouble b) => new ClampedDouble(a.Value - b.Value, a.min, a.max);
        public static ClampedDouble operator -(ClampedDouble cD) => new ClampedDouble(-cD.Value, cD.min, cD.max);
    }
}