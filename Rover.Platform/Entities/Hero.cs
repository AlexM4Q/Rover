using System;
using System.Drawing;
using Rover.Platform.Data;
using Rover.Platform.Entities.Base;

namespace Rover.Platform.Entities {

    public class Hero : MoveableEntity, IDrawable, IControllable {

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
            Velocity = new Vector(10, 10);
            Size = new Vector(15, 15);
        }

        public void Draw(DrawableBytes drawableBytes) {
            for (var x = (int) Position.X; x < (int) Position.X + (int) Size.X; x++) {
                for (var y = (int) Position.Y; y < (int) Position.Y + (int) Size.Y; y++) {
                    drawableBytes.SetPixelIfContains(x, y, Color.Red);
                }
            }
        }

        public void Fire() {
            World.Entities.Add(new Bullet(Angular) {Position = Position});
        }

    }

}