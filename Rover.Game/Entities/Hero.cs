using System.Drawing;
using Rover.Platform.Data;
using Rover.Platform.Entities;
using Rover.Platform.Entities.Base;

namespace Rover.Game.Entities {

    public class Hero : MoveableEntity, IDrawable {

        public void Draw(DrawableBytes drawableBytes) {
            drawableBytes.SetPixel((int) Position.X, (int) Position.Y, Color.White);
        }

        public override void Move(Vector direction) {
            Position += direction;
        }

    }

}