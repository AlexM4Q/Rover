using System.Collections.Generic;
using Rover.Platform.Entities.Base;

namespace Rover.Platform.Services.Base {

    public interface IService {

        void Update(IEnumerable<IEntity> entities = null);

    }

}