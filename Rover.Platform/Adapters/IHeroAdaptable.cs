using Rover.Platform.Data;

namespace Rover.Platform.Adapters {

    public interface IHeroAdaptable {

        void Move(Vector direction);

        void Fire(bool isFire);

    }

}