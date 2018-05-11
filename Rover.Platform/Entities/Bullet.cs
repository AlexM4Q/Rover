using System;
using System.Drawing;
using Rover.Platform.Data;
using Rover.Platform.Entities.Base;

namespace Rover.Platform.Entities {

    [Serializable]
    public class Bullet : Shell, IDrawable {

        public Bullet(Vector direction) {
            Direction = direction;
            Size = new Vector(5, 5);
            Velocity = new Vector(20, 20);
        }

        public void Draw(DrawableBytes drawableBytes) {
            for (var x = (int) Position.X; x < (int) Position.X + (int) Size.X; x++) {
                for (var y = (int) Position.Y; y < (int) Position.Y + (int) Size.Y; y++) {
                    drawableBytes.SetPixelIfContains(x, y, Color.Blue);
                }
            }
        }

    }

}