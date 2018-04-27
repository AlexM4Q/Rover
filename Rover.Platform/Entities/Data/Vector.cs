namespace Rover.Platform.Entities.Data {

    public class Vector {

        public double X { get; set; }

        public double Y { get; set; }

        public Vector(double x = 0, double y = 0) {
            X = x;
            Y = y;
        }

        public static Vector operator +(Vector v1, Vector v2) => new Vector(v1.X + v2.X, v1.Y + v2.Y);

    }

}