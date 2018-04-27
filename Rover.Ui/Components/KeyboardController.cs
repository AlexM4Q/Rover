using System.Windows;
using System.Windows.Input;
using Rover.Platform.Entities.Controller;
using Vector = Rover.Platform.Entities.Data.Vector;

namespace Rover.Ui.Components {

    public class KeyboardController : IController {

        public IControllable Controllable { get; set; }

        public void Update() {
            Application.Current.Dispatcher.Invoke(() => {
                if (Controllable == null) return;

                var direction = new Vector();
                if (Keyboard.IsKeyDown(Key.A)) {
                    direction.X = -1;
                } else if (Keyboard.IsKeyDown(Key.D)) {
                    direction.X = 1;
                }

                if (Keyboard.IsKeyDown(Key.W)) {
                    direction.Y = -1;
                } else if (Keyboard.IsKeyDown(Key.S)) {
                    direction.Y = 1;
                }

                Controllable.Move(direction);
            });
        }

    }

}