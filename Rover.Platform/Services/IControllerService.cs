using Rover.Platform.Entities.Base;

namespace Rover.Platform.Services {

    public interface IControllerService : IService {

        IMoveable Moveable { get; set; }

    }

}