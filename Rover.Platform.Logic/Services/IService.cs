using System.Collections.Generic;
using Rover.Platform.Logic.Entities.Base;

namespace Rover.Platform.Logic.Services {

    public interface IService {

        void Update(IReadOnlyCollection<IEntity> entities);

    }

}