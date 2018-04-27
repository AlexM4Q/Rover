using Rover.Platform.Entities.Data;

namespace Rover.Platform.Entities.Base {

    public abstract class MoveableEntity : Entity, IMoveable {

        public Vector Velocity { get; protected set; }

    }

}