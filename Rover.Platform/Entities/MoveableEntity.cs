using System;
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
        public Vector Velocity { get; set; }

        /// <summary>
        /// Направление
        /// </summary>
        public Vector Direction { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        protected MoveableEntity(Guid id) : base(id) {
        }

        public abstract void Move();

    }

}