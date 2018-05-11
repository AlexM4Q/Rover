using System.Collections.Generic;
using Rover.Platform.Entities.Base;
using Rover.Platform.Services.Base;

namespace Rover.Platform.Services {

    public class MoverService : IService {

        public void Update(IEnumerable<IEntity> entities) {
            foreach (var entity in entities) {
                if (entity is IUpdatable updatable) {
                    updatable.Update();
                }
            }
        }

    }

}