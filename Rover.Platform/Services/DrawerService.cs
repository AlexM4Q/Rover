using System.Collections.Generic;
using Rover.Platform.Data;
using Rover.Platform.Entities.Base;

namespace Rover.Platform.Services {

    public class DrawerService : IService {

        public DrawableBytes DrawableBytes { get; set; }

        public void Init(int widht, int height) {
            DrawableBytes = new DrawableBytes(widht, height);
        }

        public void Update(IEnumerable<IEntity> entities) {
            foreach (var entity in entities) {
                if (entity is IDrawable drawable) {
                    drawable.Draw(DrawableBytes);
                }
            }
        }

    }

}