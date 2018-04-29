using Rover.Platform.Logic.Data;

namespace Rover.Platform.Logic.Entities.Base {

    /// <summary>
    /// Подвижная сущность
    /// </summary>
    public interface IMoveable : IEntity {

        /// <summary>
        /// Скорость
        /// </summary>
        Vector Velocity { get; }
        
        void Move(Vector direction);

    }

}