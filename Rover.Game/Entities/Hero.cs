using System.Drawing;
using Rover.Platform.Logic.Data;
using Rover.Platform.Logic.Entities;
using Rover.Platform.View.Data;
using Rover.Platform.View.Entities;

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