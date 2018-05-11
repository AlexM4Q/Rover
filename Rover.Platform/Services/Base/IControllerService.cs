using Rover.Platform.Entities.Base;

namespace Rover.Platform.Services.Base {

    public interface IControllerService : IService {

        IControllable Controllable { get; set; }

    }

}