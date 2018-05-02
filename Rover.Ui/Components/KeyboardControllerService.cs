using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Rover.Platform.Entities.Base;
using Rover.Platform.Services;
using Rover.Platform.Services.Base;
using Vector = Rover.Platform.Data.Vector;

namespace Rover.Ui.Components {

    public class KeyboardControllerService : IControllerService {

        public IMoveable Moveable { get; set; }

        private Vector _previous;

        public void Update(IEnumerable<IEntity> entities) {
            Application.Current.Dispatcher.Invoke(() => {
                if (Moveable == null) return;

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

                if (direction.Equals(_previous)) return;

                Moveable.Direction = _previous = direction;
            });
        }

    }

}