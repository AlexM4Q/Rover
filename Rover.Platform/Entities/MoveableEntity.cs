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
        /// Направление в вращении
        /// </summary>
        public Vector Angular { get; set; }

        private Vector _direction;

        /// <summary>
        /// Направление в движении
        /// </summary>
        public Vector Direction {
            get => _direction;
            set {
                _direction = value;
                if (Math.Abs(value.X) > 0 || Math.Abs(value.Y) > 0) {
                    Angular = value;
                }
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        protected MoveableEntity() : this(Guid.NewGuid()) {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        protected MoveableEntity(Guid id) : base(id) {
            Velocity = new Vector();
            Direction = new Vector();
            Angular = new Vector(1, 0);
        }

        public override void Update() {
            Position += Velocity * Direction;
        }

    }

}