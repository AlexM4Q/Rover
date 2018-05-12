using System;
using System.Drawing;
using Rover.Platform.Data;
using Rover.Platform.Entities.Base;

namespace Rover.Platform.Entities {

    public class BulletBomb : Shell, IDrawable {

        public Color Color { get; set; }

        public long DetonationDelayTicks { get; set; } = 10000000L;

        private readonly long _creationTicks;

        public BulletBomb() {
            Color = Color.BlueViolet;
            Size = new Vector(5, 5);
            _creationTicks = DateTime.Now.Ticks;
        }

        public override void Update() {
            base.Update();

            if (DateTime.Now.Ticks - _creationTicks >= DetonationDelayTicks) {
                World.AddEntity(new Bullet {
                    Position = Position,
                    Direction = Direction
                });
                Destroy();
            }
        }

        public void Draw(DrawableBytes drawableBytes) {
            for (var x = (int) Position.X; x < (int) Position.X + (int) Size.X; x++) {
                for (var y = (int) Position.Y; y < (int) Position.Y + (int) Size.Y; y++) {
                    drawableBytes.SetPixelIfContains(x, y, Color);
                }
            }
        }

    }

}