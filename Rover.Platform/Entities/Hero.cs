using System.Drawing;
using Rover.Platform.Entities.Base;
using Rover.Platform.Entities.Controller;
using Rover.Platform.Entities.Data;

namespace Rover.Platform.Entities {

    public class Hero : MoveableEntity, IControllable {

        public override void Draw(DrawableBytes drawableBytes) {
            drawableBytes.SetPixel((int) Position.X, (int) Position.Y, Color.White);

            for (int x = 90; x < 100; x++) {
                for (int y = 90; y < 100; y++) {
                    drawableBytes.SetPixel(x, y, Color.White);
                }
            }
        }

        public void Move(Vector direction) {
            Position += direction;
        }

    }

}