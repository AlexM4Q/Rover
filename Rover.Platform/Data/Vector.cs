using System;

namespace Rover.Platform.Data {

    [Serializable]
    public class Vector {

        public double X { get; set; }

        public double Y { get; set; }

        public Vector(double x = 0, double y = 0) {
            X = x;
            Y = y;
        }

        public static Vector operator +(Vector v1, Vector v2) => new Vector(v1.X + v2.X, v1.Y + v2.Y);
        public static Vector operator -(Vector v1, Vector v2) => new Vector(v1.X - v2.X, v1.Y - v2.Y);
        public static Vector operator *(Vector v1, Vector v2) => new Vector(v1.X * v2.X, v1.Y * v2.Y);
        public static Vector operator /(Vector v1, Vector v2) => new Vector(v1.X / v2.X, v1.Y / v2.Y);

        public override bool Equals(object obj) {
            return obj is Vector other && X.Equals(other.X) && Y.Equals(other.Y);
        }

        public override int GetHashCode() {
            unchecked {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }

    }

}