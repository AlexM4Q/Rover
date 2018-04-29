using Rover.Platform.View.Data;

namespace Rover.Platform.View.Entities {

    /// <summary>
    /// Базовый интерфейс чего-то рисовабельного
    /// </summary>
    public interface IDrawable {

        /// <summary>
        /// Отрисовка
        /// </summary>
        /// <param name="drawableBytes">Холст</param>
        void Draw(DrawableBytes drawableBytes);

    }

}