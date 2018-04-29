using Rover.Platform.Logic.Entities.Base;

namespace Rover.Platform.Logic.Services {

    public interface IControllerService : IService {

        IMoveable Moveable { get; set; }

    }

}