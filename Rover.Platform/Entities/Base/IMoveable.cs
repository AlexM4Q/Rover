using Rover.Platform.Entities.Data;

namespace Rover.Platform.Entities.Base {

    public interface IMoveable : IEntity {

        Vector Velocity { get; }

    }

}