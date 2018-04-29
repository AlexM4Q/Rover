using System.Collections.Generic;
using System.Linq;
using Rover.Platform.Logic.Entities.Base;
using Rover.Platform.Logic.Services;
using Rover.Platform.View.Data;
using Rover.Platform.View.Entities;

namespace Rover.Platform.View.Services {

    public class DrawerService : IService {

        public DrawableBytes DrawableBytes { get; set; }

        public void Init(int widht, int height) {
            DrawableBytes = new DrawableBytes(widht, height);
        }

        public void Update(IReadOnlyCollection<IEntity> entities) {
            foreach (var entity in entities) {
                if (entity is IDrawable drawable) {
                    drawable.Draw(DrawableBytes);
                }
            }
        }

    }

}