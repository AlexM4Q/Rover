using Rover.Platform.Entities.Data;

namespace Rover.Platform.Entities.Base {

    public abstract class Entity : IEntity {

        public Vector Size { get; protected set; }

        public Vector Position { get; protected set; }

        protected Entity() {
            Size = new Vector();
            Position = new Vector();
        }

        public abstract void Draw(DrawableBytes drawableBytes);

    }

}