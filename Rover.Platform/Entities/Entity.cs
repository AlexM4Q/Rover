using System;
using Rover.Platform.Data;
using Rover.Platform.Entities.Base;

namespace Rover.Platform.Entities {

    /// <summary>
    /// Базовый класс сущности
    /// </summary>
    public abstract class Entity : IEntity {

        /// <summary>
        /// Мир во всём
        /// </summary>
        protected World World => World.Instance;

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

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        protected Entity(Guid id) {
            Id = id;
            Size = new Vector(1, 1);
            Position = new Vector();
        }

        public abstract void Update();

    }

}