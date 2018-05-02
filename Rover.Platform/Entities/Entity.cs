using System;
using Rover.Platform.Data;
using Rover.Platform.Entities.Base;

namespace Rover.Platform.Entities {

    /// <summary>
    /// Базовый класс сущности
    /// </summary>
    public abstract class Entity : IEntity {

        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Размер сущности
        /// </summary>
        public Vector Size { get; protected set; }

        /// <summary>
        /// Координата сущности
        /// </summary>
        public Vector Position { get; protected set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        protected Entity() : this(Guid.NewGuid()) {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        protected Entity(Guid id) {
            Id = id;
            Size = new Vector();
            Position = new Vector();
        }

    }

}