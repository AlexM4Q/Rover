using System.Collections.Generic;
using Rover.Platform.Entities;
using Rover.Platform.Entities.Base;
using Rover.Platform.Services.Base;

namespace Rover.Platform.Services {

    public class HeroService : IService {

        public void Update(IEnumerable<IEntity> entities) {
            foreach (var entity in entities) {
                if (entity is Hero hero) {
                    hero.Move();
                }
            }
        }

    }

}