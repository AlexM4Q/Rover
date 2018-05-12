using System.Drawing;
using Rover.Platform.Data;

namespace Rover.Platform.Entities.Base {

    /// <summary>
    /// Базовый интерфейс чего-то рисовабельного
    /// </summary>
    public interface IDrawable {

        /// <summary>
        /// Цвет
        /// </summary>
        Color Color { get; set; }

        /// <summary>
        /// Отрисовка
        /// </summary>
        /// <param name="drawableBytes">Холст</param>
        void Draw(DrawableBytes drawableBytes);

    }

}