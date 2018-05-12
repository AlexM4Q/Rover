using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Rover.Platform.Entities.Base;
using Rover.Platform.Services.Base;
using Vector = Rover.Platform.Data.Vector;

namespace Rover.Ui.Components {

    public class KeyboardControllerService : IControllerService {

        public IControllable Controllable { get; set; }

        public void Update(IEnumerable<IEntity> entities = null) {
            if (Controllable == null) return;

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

                Controllable.Direction = direction;
                Controllable.IsFire = Keyboard.IsKeyDown(Key.Space);
            });
        }

    }

}