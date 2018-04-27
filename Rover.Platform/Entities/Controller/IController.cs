using Rover.Platform.Entities.Components;

namespace Rover.Platform.Entities.Controller {

    public interface IController : IWorldComponent {

        IControllable Controllable { get; set; }

    }

}