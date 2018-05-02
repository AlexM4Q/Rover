using System;
using Rover.Platform.Data;
using Rover.Platform.Entities.Base;

namespace Rover.Platform.Adapters {

    public class MoveAdapter : IMoveable {

        public Vector Direction {
            get => throw new NotImplementedException();
            set => _onDirectionChanged?.Invoke(value);
        }

        private readonly Action<Vector> _onDirectionChanged;

        public MoveAdapter(Action<Vector> onDirectionChanged) {
            _onDirectionChanged = onDirectionChanged;
        }

    }

}