using Rover.Platform.Data;

namespace Rover.Platform.Entities.Base {

    /// <summary>
    /// Подвижная сущность
    /// </summary>
    public interface IMoveable {

        /// <summary>
        /// Направление
        /// </summary>
        Vector Direction { get; set; }

    }

}