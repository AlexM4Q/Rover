using Rover.Platform.Logic.Data;
using Rover.Platform.Logic.Entities.Base;

namespace Rover.Platform.Logic.Entities {

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