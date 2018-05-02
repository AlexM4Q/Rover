using System;
using System.Drawing;
using Rover.Platform.Data;
using Rover.Platform.Entities.Base;

namespace Rover.Platform.Entities {

    public class Hero : MoveableEntity, IDrawable {

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        public Hero(Guid id) : base(id) {
            Velocity = new Vector(1, 1);
        }

        public void Draw(DrawableBytes drawableBytes) {
            drawableBytes.SetPixel((int) Position.X, (int) Position.Y, Color.White);
        }

        public override void Move() {
            Position += Velocity * Direction;
        }

    }

}