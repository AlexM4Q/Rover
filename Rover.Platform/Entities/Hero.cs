using System;
using System.Drawing;
using Rover.Platform.Data;
using Rover.Platform.Entities.Base;

namespace Rover.Platform.Entities {

    public class Hero : MoveableEntity, IDrawable {

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
            Velocity = new Vector(1, 1);
        }

        public void Draw(DrawableBytes drawableBytes) {
            for (var x = (int) Position.X; x < (int) Position.X + (int) Size.X; x++) {
                for (var y = (int) Position.Y; y < (int) Position.Y + (int) Size.Y; y++) {
                    if (drawableBytes.Contains(x, y)) {
                        drawableBytes.SetPixel(x, y, Color.Red);
                    }
                }
            }
        }

        public override void Move() {
            Position += Velocity * Direction;
        }

    }

}