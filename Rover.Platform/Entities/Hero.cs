using System;
using System.Drawing;
using Rover.Platform.Constants;
using Rover.Platform.Data;
using Rover.Platform.Entities.Base;

namespace Rover.Platform.Entities {

    [Serializable]
    public class Hero : MoveableEntity, IDrawable, IControllable {

        public FireType FireType { get; set; } = FireType.Bullet;

        public bool IsFire { get; set; }

        private long _fireDelayTicks;

        public long FireDelaySeconds {
            get => _fireDelayTicks / TimeSpan.TicksPerSecond;
            set => _fireDelayTicks = value * TimeSpan.TicksPerSecond;
        }

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
            Size = new Vector(15, 15);
            Velocity = new Vector(10, 10);
        }

        public void Draw(DrawableBytes drawableBytes) {
            for (var x = (int) Position.X; x < (int) Position.X + (int) Size.X; x++) {
                for (var y = (int) Position.Y; y < (int) Position.Y + (int) Size.Y; y++) {
                    drawableBytes.SetPixelIfContains(x, y, Color.Red);
                }
            }
        }

        public override void Update() {
            base.Update();

            if (IsFire) {
                var now = DateTime.Now.Ticks;
                if (now - _lastFireTicks > _fireDelayTicks) {
                    _lastFireTicks = now;
                    World.AddEntity(new Bullet(Angular) {Position = Position});
                }
            }
        }

    }

}