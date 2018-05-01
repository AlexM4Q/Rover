using Rover.Platform.Data;
using Rover.Platform.Entities.Base;

namespace Rover.Platform.Entities {

    /// <summary>
    /// Базовый класс подвижной сущности
    /// </summary>
    public abstract class MoveableEntity : Entity, IMoveable {

        /// <summary>
        /// Скорость
        /// </summary>
        public Vector Velocity { get; protected set; }

        public abstract void Move(Vector direction);

    }

}