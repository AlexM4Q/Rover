using System;
using System.Drawing;
using Rover.Platform.Constants;
using Rover.Platform.Data;
using Rover.Platform.Entities.Base;
using Rover.Platform.Factories;

namespace Rover.Platform.Entities {

    [Serializable]
    public class Hero : MoveableEntity, IDrawable, IControllable {

        public Color Color { get; set; }

        public bool IsFire { get; set; }

        public ShellType ShellType { get; set; } = ShellType.BulletBomb;

        public long FireDelayTicks { get; set; } = 1000000L;

        private long _lastFireTicks;

        /// <summary>
        /// Конструктор
        /// </summary>
        public Hero() : this(Guid.NewGuid()) {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        public Hero(Guid id) : base(id) {
            Color = Color.Red;
            Size = new Vector(15, 15);
            Velocity = new Vector(10, 10);
        }

        public void Draw(DrawableBytes drawableBytes) {
            for (var x = (int) Position.X; x < (int) Position.X + (int) Size.X; x++) {
                for (var y = (int) Position.Y; y < (int) Position.Y + (int) Size.Y; y++) {
                    drawableBytes.SetPixelIfContains(x, y, Color);
                }
            }
        }

        public override void Update() {
            base.Update();

            if (IsFire) {
                var now = DateTime.Now.Ticks;
                if (now - _lastFireTicks > FireDelayTicks) {
                    _lastFireTicks = now;
                    World.AddEntity(ShellType.CreateShell(Position, Angular));
                }
            }
        }

    }

}