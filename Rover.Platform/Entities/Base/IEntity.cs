﻿using System;
using Rover.Platform.Data;

namespace Rover.Platform.Entities.Base {

    /// <summary>
    /// Базовый интерфейс сущности
    /// </summary>
    public interface IEntity {

        /// <summary>
        /// Идентификатор
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Размер сущности
        /// </summary>
        Vector Size { get; }

        /// <summary>
        /// Координата сущности
        /// </summary>
        Vector Position { get; }

    }

}