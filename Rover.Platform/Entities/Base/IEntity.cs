using Rover.Platform.Entities.Data;

namespace Rover.Platform.Entities.Base {

    public interface IEntity : IDrawable {

        Vector Size { get; }

        Vector Position { get; }

    }

}