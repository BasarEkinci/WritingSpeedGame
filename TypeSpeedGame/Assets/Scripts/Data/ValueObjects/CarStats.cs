using System;

namespace Data.ValueObjects
{
    [Serializable]
    public struct CarStats
    {
        public float MaxSpeed;
        public float Acceleration;
        public float Deceleration;
    }
}