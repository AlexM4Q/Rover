using System.Collections.Generic;
using Rover.Platform.Entities;
using Rover.Platform.Entities.Base;
using Rover.Platform.Services.Base;

namespace Rover.Platform.Services {

    public class RemoverService : IService {

        public void Update(IEnumerable<IEntity> entities) {
            foreach (var entity in entities) {
                switch (entity) {
                    case Bullet bullet:
                        if (bullet.Position.X > 1000 || bullet.Position.Y > 1000) {
                            bullet.Destroy();
                        }

                        break;
                }
            }
        }

    }

}