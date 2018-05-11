using System;
using Rover.Platform.Data;
using Rover.Platform.Entities.Base;

namespace Rover.Platform.Entities {

    /// <summary>
    /// Базовый класс сущности
    /// </summary>
    [Serializable]
    public abstract class Entity : IEntity {

        /// <summary>
        /// Мир во всём
        /// </summary>
        protected static World World => World.Instance;

        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Размер сущности
        /// </summary>
        public Vector Size { get; set; }

        /// <summary>
        /// Координата сущности
        /// </summary>
        public Vector Position { get; set; }

        protected Entity() : this(Guid.NewGuid()) {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        protected Entity(Guid id) {
            Id = id;
            Size = new Vector(1, 1);
            Position = new Vector();
        }

    }

}